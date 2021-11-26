$(document).ready(function () {
    var simulacaoJson = $('#simulacao-json').html();
    var simulacaoObjeto = JSON.parse(simulacaoJson);
    var desmembramentoParcelas = JSON.parse(simulacaoObjeto.DesmembramentoParcelasJson);
    var conteudoTabela = document.getElementById("lista-parcelas");

    //Preenchimento dos campos de acordo com o json de simulação
    if (simulacaoObjeto) {

        $('#nome-completo').val(simulacaoObjeto.NomeCompleto);
        $('#celular').val(simulacaoObjeto.Celular);
        $('#email').val(simulacaoObjeto.Email);
        $('#valor').val(simulacaoObjeto.Valor.toFixed(2));

        conteudoTabela.innerHTML = "";

        for (var i = 0; i < desmembramentoParcelas.length; i++) {
            var tabela = "";
            if (desmembramentoParcelas[i].NumeroParcela == simulacaoObjeto.Parcelas) {
                tabela += "<tr id='" + desmembramentoParcelas[i].NumeroParcela + "' class='table-active' role='button'>";
            } else {
                tabela += "<tr id='" + desmembramentoParcelas[i].NumeroParcela + "' role='button'>";
            }

            tabela += "<td>" + desmembramentoParcelas[i].NumeroParcela + " x </td>";
            tabela += "<td>" + desmembramentoParcelas[i].ValorParcela.toFixed(2) + "</td>";
            tabela += "</tr>"

            conteudoTabela.innerHTML += tabela;
        }

        //Função de clique da tabela para alterar o parcelamento escolhido
        $('tr').click(function (elemento) {
            $('tr').removeClass('table-active');
            elemento.currentTarget.classList.add('table-active');
        });
    }

    //Evento de clique do botão prosseguir
    $('#btn-prosseguir').click(function () {
        //Atualizar o objeto/json no localStorage
        var parcelaString = $('.table-active')[0].id;
        simulacaoObjeto.Parcelas = parseInt(parcelaString);
        simulacaoJson = JSON.stringify(simulacaoObjeto);
        window.localStorage.setItem("PAYX_SIMULACAO", simulacaoJson);

        //Enviar os dados para a alteração no lado do servidor
        $.ajax({
            url: "Simulacao/AlterarSimulacao",
            type: "POST",
            contentType: "application/json",
            dataType: "json",
            data: simulacaoJson,
            success: function (data) {
                if (data == 'USER_LOGADO') {
                    window.location.href = "/Usuario/Index";
                }
                else {
                    window.location.href = "/Usuario/Login";
                }
            },
            error: function (data) {
                $('#erro').html('Erro ao gerar transação: ' + data);
            }
        });
        //A tela de transação fará o preenchimento dos seus campos de acordo com o json e a partir dela faremos a integração com a Juno 
    });
});