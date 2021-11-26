var dadosEndereco;

$(function () {
    $('[data-toggle="tooltip"]').tooltip();
});

function buscarCidadePorEstado(estado) {
    $('.spinner-container').removeAttr('hidden');
    $('#combo-cidade').html('');
    $('#combo-cidade').html('<option value="" selected>Carregando...</option>');

    axios.get('Cidades', {
        params: {
            estado: estado
        }
    }).then(function (response) {
        var comboCidade = document.getElementById('combo-cidade');
        comboCidade.innerHTML = '<option value="" selected>*Selecione a cidade</option>';

        $.each(response.data, function (indice, valor) {
            comboCidade.innerHTML += '<option class="form-control" value="' + valor.Id + '">' + valor.NomeCidade + '</option>';
        });
    }).catch(function (error) {
        $('#combo-cidade').html('');
        $('#combo-cidade').html('<option value="" selected>*Primeiro selecione um estado</option>');
    }).then(function () {
        if (dadosEndereco) {
            console.log(dadosEndereco.localidade);
            $("#combo-cidade option:contains(" + dadosEndereco.localidade.toUpperCase() + ")").attr("selected", true);
            dadosEndereco = null;
        }
        $('.spinner-container').attr('hidden', true);
    });
}

$('#Cep').change(function () {
    $('.spinner-container').removeAttr('hidden');
    var cep = $('#Cep').val().replaceAll(".", "").replaceAll("-", "");
    if (cep.length != 8) {
        $('#validacao-cep').html("Por favor, informe um CEP válido.");
        $('#btn-registrar').prop("disabled", true);
        $('.spinner-container').attr('hidden', true);
    }
    else {
        $('#validacao-cep').html("");
        $('#btn-registrar').prop("disabled", false);

        $.ajax({
            url: "https://viacep.com.br/ws/" + cep + "/json/",
            type: "GET",
            dataType: "json",
            success: function (data) {
                dadosEndereco = data;
                $("#Estado").val(data.uf);
                buscarCidadePorEstado(data.uf);
                $("#Logradouro").val(data.logradouro);
                $("#Complemento").val(data.complemento);
                $("#Bairro").val(data.bairro);
                $("#Numero ").focus();
            }
        });
    }
});

$('#Cpf').blur(function () {
    var cpf = $('#Cpf').val();

    var bool = validarCPF(cpf);

    if (cpf.length < 14 || !bool) {
        $('#validacao-cpf').html("Por favor, informe um CPF válido.");
        $('#btn-registrar').prop("disabled", true);
    }
    else {
        $('#validacao-cpf').html("");
        $('#btn-registrar').prop("disabled", false);
    }
});

$('#Estado').change(function () {
    var estado = $('#Estado option:selected').val();

    if (!estado) {
        $('#combo-cidade').html('');
        $('#combo-cidade').html('<option value="" selected>* Primeiro selecione um estado</option>');
    }
    else {
        buscarCidadePorEstado(estado);
    }
});

