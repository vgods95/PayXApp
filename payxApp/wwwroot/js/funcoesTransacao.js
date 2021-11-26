$(document).ready(function () {
    var baseUrl = '';
    var arrayBancos;
    var bancoSelecionado;
    var vencimentoLimite = new Date();
    vencimentoLimite.setDate(vencimentoLimite.getDate() + 2);
    var checkout = new DirectCheckout('EB82ACAB625BF1AAC5F94DC4DD4CB6FE0E0679F9A3163262FEB2C49D8BD5456A', false); /* Em sandbox utilizar o construtor new DirectCheckout('PUBLIC_TOKEN', false); */
    var cardHash = "";
    $('#cardConta').fadeIn("slow");
    $('#cardBoleto').fadeOut("fast");
    var input = $("#doc-destinatario");
    input.mask("999.999.999-99");
    input = $('#cnpj-beneficiario');
    input.mask("99.999.999/9999-99");
    input = $('#ano-vencimento');
    input.mask('9999');
    input = $('#cvv');
    input.mask('9999');
    input = $('#numero-cartao');
    input.mask('9999 9999 9999 9999');
    input = $('#codigo-barras-boleto');
    input.mask('9999999999999999999999999999999999999999999999999999999');

    input = $('#agencia');
    input.mask('99999999999999999999999999999999999999999999999999');
    input = $('#dig-agencia');
    input.mask('9');
    input = $('#numero-conta');
    input.mask('99999999999999999999999999999999999999999999999999');
    input = $('#dig-conta');
    input.mask('9');
    input = $('#operacao');
    input.mask('99999');


    recuperarBancos();

    function recuperarBancos() {
        $.ajax({
            url: baseUrl + "/api/bancos",
            type: "GET",
            dataType: "json",
            success: function (data) {
                arrayBancos = data;
                var datalist = $('#lista-sugestoes');
                $.each(arrayBancos, function (indice, valor) {
                    datalist.append('<option value="' + valor.Codigo + ' - ' + valor.Nome + '">');
                });
            },
            error: function (erro) {
                console.log(erro);
            }
        });
    };

    async function generateHash(cardData) {
        checkout.getCardHash(cardData, function (cardHash) {
            if (cardHash != "") {
                $('#hash-cartao').val(cardHash);
                $('#btn-submit-transacao').trigger("click");
            }
            console.log("44");
        }, function (error) {
            console.log(error);
        });
    };

    function ValidarCartao(cardData) {
        if (!checkout.isValidCardNumber(cardData.cardNumber)) {
            $('#validacao-numero-cartao').html('Numeração do cartão inválida');
            return false;
        }
        else {
            $('#validacao-numero-cartao').html('');
        }

        if (!checkout.isValidExpireDate(cardData.expirationMonth, cardData.expirationYear)) {
            $('#validacao-mes-cartao').html('Data de expiração do cartão inválida');
            return false;
        }
        else {
            $('#validacao-mes-cartao').html('');
        }

        if (!checkout.isValidSecurityCode(cardData.cardNumber, cardData.securityCode)) {
            $('#validacao-cvv-cartao').html('Código de segurança do cartão inválido');
            return false;
        }
        else {
            $('#validacao-cvv-cartao').html('');
        }

        return true;
    };

    $("#valor-solicitado").blur(function () {
        if ($("#valor-solicitado").val()) {
            var valor = $("#valor-solicitado").val().replace(',', '.');
            var novoValor = parseFloat(valor).toFixed(2);
            $("#valor-solicitado").val(novoValor);
        }
    });

    $('#valor-solicitado').change(function () { //Verificar possiblidade de colocar o Loader
        $('#parcelas').html('');
        var valor = parseFloat($('#valor-solicitado').val());
        $('#parcelas').html("<option value='' selected>* Parcelamento (digite um valor)</option>");
        $.ajax({
            url: baseUrl + "/api/parcelas/",
            headers: { 'valorSolicitado': valor },
            type: "GET",
            dataType: "json",
            success: function (data) {
                var selectParcelas = $('#parcelas');
                $.each(data, function (indice, valor) {
                    selectParcelas.append('<option value="' + valor.numeroParcela + '">' + valor.numeroParcela + 'x ' + valor.valorParcela + '</option> ');
                });

                $('#parcelas-json').val(JSON.stringify(data));
            },
            error: function (erro) {
                console.log(erro);
                $('#parcelas-json').val("ERRO");
            }
        });
    });

    $('#campo-banco').blur(function () {
        if ($('#campo-banco').val() == "104 - Caixa Econômica Federal") {
            $("#operacao").attr("hidden", false);
        }
        else {
            $("#operacao").val('');
            $("#operacao").attr("hidden", true);
        }
    });

    $("input[name='tipo-transacao']").change(function () {
        $("#tipo-transacao-transf").removeClass("h6");
        $("#tipo-transacao-bol").removeClass("h6");

        if ($("input[name='tipo-transacao']:checked").val() == 'boleto') {
            $("#tipo-transacao-bol").addClass("h6");
            $('#cardConta').fadeOut("fast");
            $('#cardBoleto').fadeIn("slow");
            $('#tipo-transacao-text').val("boleto");
        } else {
            $("#tipo-transacao-transf").addClass("h6");
            $('#cardConta').fadeIn("slow");
            $('#cardBoleto').fadeOut("fast");
            $('#tipo-transacao-text').val("transf");
        }
    });

    $("input[name='tipo-pessoa']").change(function () {
        $("#tipo-pessoa-fisica").removeClass("h6");
        $("#tipo-pessoa-juridica").removeClass("h6");
        input = $("#doc-destinatario").val('');
        if ($("input[name='tipo-pessoa']:checked").val() == 'fisica') {
            $("#tipo-pessoa-fisica").addClass("h6");
            $("#nome-destinatario").attr('placeholder', 'Nome do destinatário*');
            input = $("#doc-destinatario");
            input.mask("999.999.999-99");
            input.attr('placeholder', 'CPF do destinatário*');
        } else {
            $("#tipo-pessoa-juridica").addClass("h6");
            input = $("#doc-destinatario");
            input.mask("99.999.999/9999-99");
            $("#nome-destinatario").attr('placeholder', 'Razão Social do destinatário*');
            input.attr('placeholder', 'CNPJ do destinatário*');
        }
    });

    $('#btn-confirmar-transacao').click(function () {
        if (validarCamposTransacao()) {
            var numeroCartao = $('#numero-cartao').val().toString().replaceAll(" ", "");
            var titularCartao = $('#titular-cartao').val().toString();
            var mesVencimento = $('#mes-vencimento').val().toString();
            var anoNascimento = $('#ano-vencimento').val().toString();
            var cvv = $('#cvv').val().toString();

            var cardData = {
                cardNumber: numeroCartao,
                holderName: titularCartao,
                securityCode: cvv,
                expirationMonth: mesVencimento,
                expirationYear: anoNascimento
            };

            if (ValidarCartao(cardData)) {
                generateHash(cardData);
            }
        }
    });

    function validarCamposTransacao() {
        var contaValida = null;
        //Validação do valor
        var valor = $('#valor-solicitado').val().toString();
        if (valor) {
            var valorDouble = parseFloat(valor);
            if (!valor || valorDouble == 0) {
                $("#validacao-valor").html("Por favor, informe o valor desejado.");
                return false;
            }
            else {
                $("#validacao-valor").html("");
            }
        }
        else {
            $("#validacao-valor").html("Por favor, informe o valor desejado.");
            return false;
        }

        //Validação das parcelas
        var parcelas = $("#parcelas option:selected").val();
        if (!parcelas) {
            $("#validacao-parcelas").html("Por favor, selecione o parcelamento.");
            return false;
        }
        else {
            $("#validacao-parcelas").html("");
        }

        var tipoTransacao = $('input[name=tipo-transacao]:checked').val();
        //Validação dos dados do Boleto
        if (tipoTransacao == 'boleto') {
            contaValida = true;
            //Código de Barras
            var codigoBarrasBoleto = $('#codigo-barras-boleto').val().toString();
            if (!codigoBarrasBoleto) {
                $("#validacao-codigo-barras-boleto").html("Por favor, informe o código de barras do boleto.");
                return false;
            }
            else {
                if (window.ValidarCodigoBarras(codigoBarrasBoleto)) {
                    $("#validacao-codigo-barras-boleto").html("");
                }
                else {
                    $("#validacao-codigo-barras-boleto").html("Código de barras do boleto inválido.");
                    return false;
                }
            }

            //Descrição do Pagamento
            var descricaoPagamento = $('#descricao-pagamento').val().toString();
            if (!descricaoPagamento) {
                $("#validacao-descricao-boleto").html("Por favor, informe uma descrição para o pagamento.");
                return false;
            }
            else {
                $("#validacao-descricao-boleto").html("");
            }

            //CNPJ do Beneficiário
            var cnpjBeneficiario = $('#cnpj-beneficiario').val().toString();
            if (!cnpjBeneficiario) {
                $("#validacao-cnpj-beneficiario").html("Por favor, informe o CNPJ do beneficiário.");
                return false;
            }
            else {
                if (validarCNPJ(cnpjBeneficiario)) {
                    $("#validacao-cnpj-beneficiario").html("");
                }
                else {
                    $("#validacao-cnpj-beneficiario").html("Por favor, informe um CNPJ válido.");
                    return false;
                }
            }

            //Data de Emissão
            var dataEmissao = $('#data-emissao').val();
            if (!dataEmissao) {
                $("#validacao-data-emissao").html("Por favor, informe a data de emissão do boleto.");
                return false;
            }
            else {
                $("#validacao-data-emissao").html("");
            }

            //Data de Vencimento
            var dataVencimento = $('#data-vencimento').val();
            if (!dataVencimento) {
                $("#validacao-data-vencimento").html("Por favor, informe a data de vencimento do boleto.");
                return false;
            }
            else {
                var dataVencimentoDate = new Date(dataVencimento + " 00:00:00");
                if (dataVencimentoDate < vencimentoLimite) {
                    $("#validacao-data-vencimento").html("A data de vencimento do boleto deve ser maior ou igual a " + vencimentoLimite.getDate().toString() + "/" + (vencimentoLimite.getMonth() + 1).toString() + "/" + vencimentoLimite.getFullYear());
                    return false;
                }
                else {
                    $("#validacao-data-vencimento").html("");
                }
            }

        } //Validação dos dados da transferência
        else {
            //Nome do destinatário
            var nomeDestinatario = $('#nome-destinatario').val().toString();
            if (!nomeDestinatario) {
                $("#validacao-nome").html("Por favor, informe o nome do destinatário.");
                return false;
            }
            else {
                $("#validacao-nome").html("");
            }

            //Documento do destinatário
            var docDestinatario = $('#doc-destinatario').val().toString();
            if (!docDestinatario) {
                $("#validacao-doc").html("Por favor, informe o documento do destinatário.");
                return false;
            }
            else {
                var sucesso = false;
                if (docDestinatario.length == 14) {
                    sucesso = validarCPF(docDestinatario);
                }
                else {
                    sucesso = validarCNPJ(docDestinatario);
                }

                if (sucesso) {
                    $("#validacao-doc").html("");
                }
                else {
                    $("#validacao-doc").html("Documento informado inválido!");
                    return false;
                }
            }

            //Banco selecionado
            bancoSelecionado = $('#campo-banco').val().toString();
            if (!bancoSelecionado) {
                $("#validacao-banco").html("Por favor, selecione o banco.");
                return false;
            }
            else {
                var splitBanco = bancoSelecionado.split(' - ');
                if (splitBanco.length < 2) {
                    bancoSelecionado = null;
                    $("#validacao-banco").html("Por favor, selecione um banco válido.");
                    return false;
                }
                else {
                    var banco = arrayBancos.find(x => x.Codigo == splitBanco[0].trim());

                    if (banco) {
                        bancoSelecionado = banco;
                        $("#codigo-banco").val(bancoSelecionado.Id);
                        $("#validacao-banco").html("");
                    }
                    else {
                        bancoSelecionado = null;
                        $("#validacao-banco").html("Por favor, selecione um banco válido.");
                        return false;
                    }
                }
            }

            //Tipo Conta
            var tipoConta = $('#tipo-conta').val().toString();
            if (!tipoConta) {
                $("#validacao-tipo-conta").html("Por favor, selecione o tipo da conta."); //Verificar a possibilidade de validar os dados da transf.
                return false;
            }
            else {
                $("#validacao-tipo-conta").html("");
            }

            //Agência
            var agencia = $('#agencia').val().toString();
            if (!agencia) {
                $("#validacao-agencia").html("Por favor, informe o número da agência.");
                return false;
            }
            else {
                $("#validacao-agencia").html("");
            }

            //Conta
            var conta = $('#numero-conta').val().toString();
            if (!conta) {
                $("#validacao-conta").html("Por favor, informe o número da conta.");
                return false;
            }
            else {
                $("#validacao-conta").html("");
            }

            //Operacao
            if (bancoSelecionado.Nome == "Caixa Econômica Federal") {
                var operacao = $('#operacao').val().toString();
                if (!operacao) {
                    $("#validacao-operacao").html("Por favor, informe o código da operação.");
                    return false;
                }
                else {
                    $("#validacao-operacao").html("");
                }
            }

            //Validação dos dados informados
            bancoSelecionado = $('#campo-banco').val().toString();
            splitBanco = bancoSelecionado.split(' - ');
            var agencia = $('#agencia').val().toString();

            if (agencia.length == 1) {
                agencia = "000" + agencia;
            }
            else if (agencia.length == 2) {
                agencia = "00" + agencia;
            }
            else if (agencia.length == 3) {
                agencia = "0" + agencia;
            }

            if (splitBanco.length >= 2) {
                var digagencia = $('#dig-agencia').val().toString();
                var digconta = $('#dig-conta').val().toString();

                Moip.BankAccount.validate({
                    bankNumber: splitBanco[0],
                    agencyNumber: agencia,
                    agencyCheckNumber: digagencia,
                    accountNumber: conta,
                    accountCheckNumber: digconta,
                    valid: function () {
                        contaValida = true;
                    },
                    invalid: function (data) {

                        for (var i = 0; i < data.errors.length; i++) {
                            switch (data.errors[i].code) {
                                case "INVALID_AGENCY_NUMBER": //agencia
                                    $("#validacao-agencia").html(data.errors[i].description);
                                    break;
                                case "INVALID_AGENCY_CHECK_NUMBER": //dv agenc
                                    $("#validacao-agencia").html(data.errors[i].description);
                                    break;
                                case "INVALID_ACCOUNT_NUMBER": //num conta
                                    $("#validacao-conta").html(data.errors[i].description);
                                    break;
                                case "INVALID_ACCOUNT_CHECK_NUMBER": //dv conta
                                    $("#validacao-conta").html(data.errors[i].description);
                                    break;
                                case "AGENCY_CHECK_NUMBER_DONT_MATCH": //dv agencia 
                                    $("#validacao-agencia").html(data.errors[i].description);
                                    break;
                                case "ACCOUNT_CHECK_NUMBER_DONT_MATCH": //dv conta
                                    $("#validacao-conta").html(data.errors[i].description);
                                    break;
                                case "INVALID_BANK_NUMBER": //banco selecionado
                                    $("#validacao-banco").html(data.errors[i].description);
                                    break;
                            }
                        }
                        contaValida = false;
                    }
                });
            }
            else {
                bancoSelecionado = null;
                $("#validacao-banco").html("Por favor, selecione um banco válido.");
                return false;
            }
        }

        //Dados do cartão
        var numeroCartao = $('#numero-cartao').val().toString().replaceAll(" ", "");
        if (!numeroCartao) {
            $('#validacao-numero').html("Por favor, informe um número de cartão");
            return false;
        }
        else {
            $('#validacao-numero').html("");
        }


        var titularCartao = $('#titular-cartao').val().toString();
        if (!titularCartao) {
            $('#validacao-titular').html("Por favor, informe o nome do titular do cartão");
            return false;
        }
        else {
            $('#validacao-titular').html("");
        }

        var mesVencimento = $('#mes-vencimento').val().toString();
        if (!mesVencimento) {
            $('#validacao-mes').html("Por favor, informe o mês de vencimento do cartão");
            return false;
        }
        else {
            $('#validacao-mes').html("");
        }

        var anoNascimento = $('#ano-vencimento').val().toString();
        if (!anoNascimento) {
            $('#validacao-ano').html("Por favor, informe o ano de vencimento do cartão");
            return false;
        }
        else {
            $('#validacao-ano').html("");
        }

        var cvv = $('#cvv').val().toString();
        if (!cvv) {
            $('#validacao-cvv').html("Por favor, informe o CVV do cartão");
            return false;
        }
        else {
            $('#validacao-cvv').html("");
        }
        if (contaValida == null) {
            while (contaValida == null) {
                window.setInterval(500);
            }

            if (contaValida != null) {
                return contaValida;
            }
        }
        else {
            return contaValida;
        }
    }

    $('#numero-cartao').change(function () {
        var numeroCartao = $('#numero-cartao').val().toString().replaceAll(" ", "");
        if (checkout.isValidCardNumber(numeroCartao)) {
            var bandeira = checkout.getCardType(numeroCartao);
            if (bandeira) {
                $('#row-bandeira').removeAttr('hidden');
                $('#bandeira-cartao').val(bandeira.toUpperCase());
            }
        }
    });


});