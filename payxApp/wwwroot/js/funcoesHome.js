$("#valor-simulacao").blur(function () {
    if ($("#valor-simulacao").val()) {
        var valor = $("#valor-simulacao").val().replace(',', '.'); //O parseFloat só considera decimal com ponto e nao com virgula
        var novoValor = parseFloat(valor).toFixed(2);
        $("#valor-simulacao").val(novoValor);
    }
});

$("#btn-simular").click(function () {
    var nome = $("#nome-simulacao").val();
    var email = $("#email-simulacao").val();
    var celular = $("#celular-simulacao").val();
    var valor = $("#valor-simulacao").val();
    var quantidade_parcelas = $("#parcelas-simulacao option:selected").val();

    if (validarCamposSimulacao(nome, email, celular, valor, quantidade_parcelas)) {
        $('#btn-submit-simulacao').trigger("click");
    }
});

$("#btn-contato").click(function () {
    var nome = $("#nome-contato").val();
    var email = $("#email-contato").val();
    var celular = $("#celular-contato").val();
    var mensagem = $("#mensagem-contato").val();

    if (validarCamposContato(nome, email, celular, mensagem)) {
        $('#btn-submit-contato').trigger("click");
    }
});

$(document).ready(function () {
    var tempdata = sessionStorage.getItem("simulacao");
    console.log(tempdata);

    var valorCookie = document.cookie;
    console.log(valorCookie);
});