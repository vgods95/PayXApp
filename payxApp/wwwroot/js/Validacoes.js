function validarEmail(e) {
    var filter = /^\s*[\w\-\+_]+(\.[\w\-\+_]+)*\@[\w\-\+_]+\.[\w\-\+_]+(\.[\w\-\+_]+)*\s*$/;
    return String(e).search(filter) != -1;
}

function validarCamposContato(nome, email, celular, mensagem) {
    if (!nome) {
        $("#validacao-nome-contato").html("Por favor, identifique-se.");
        return false;
    }
    else {
        $("#validacao-nome-contato").html("");
    }

    if (!email || !validarEmail(email)) {
        $("#validacao-email-contato").html("Por favor, informe um e-mail válido.");
        return false;
    }
    else {
        $("#validacao-email-contato").html("");
    }

    if (!celular || celular.length < 15) {
        $("#validacao-celular-contato").html("Por favor, informe um número de celular válido.");
        return false;
    }
    else {
        $("#validacao-celular-contato").html("");
    }

    if (!mensagem || mensagem.length < 15) {
        $("#validacao-mensagem-contato").html("A mensagem deve conter entre 15 e 700 caracteres.");
        return false;
    }
    else {
        $("#validacao-mensagem-contato").html("");
    }

    return true;
}

function validarCamposSimulacao(nome, email, celular, valor, quantidade_parcelas) {
    if (!nome) {
        $("#validacao-nome").html("Por favor, identifique-se.");
        return false;
    }
    else {
        $("#validacao-nome").html("");
    }

    if (!email || !validarEmail(email)) {
        $("#validacao-email").html("Por favor, informe um e-mail válido.");
        return false;
    }
    else {
        $("#validacao-email").html("");
    }

    if (!celular || celular.length < 15) {
        $("#validacao-celular").html("Por favor, informe um número de celular válido.");
        return false;
    }
    else {
        $("#validacao-celular").html("");
    }

    var valorDouble = parseFloat(valor);
    if (!valor || valorDouble == 0) {
        $("#validacao-valor").html("Por favor, informe o valor desejado.");
        return false;
    }
    else {
        $("#validacao-valor").html("");
    }

    if (!quantidade_parcelas) {
        $("#validacao-parcelas").html("Por favor, selecione a quantidade de parcelas.");
        return false;
    }
    else {
        $("#validacao-parcelas").html("");
    }

    return true;
}

function validarCPF(strCPF) {
    cpf = strCPF.replaceAll(".", "").replaceAll("-", "");
    if (
        !cpf ||
        cpf.length != 11 ||
        cpf == "00000000000" ||
        cpf == "11111111111" ||
        cpf == "22222222222" ||
        cpf == "33333333333" ||
        cpf == "44444444444" ||
        cpf == "55555555555" ||
        cpf == "66666666666" ||
        cpf == "77777777777" ||
        cpf == "88888888888" ||
        cpf == "99999999999"
    ) {
        return false
    }
    var soma = 0
    var resto
    for (var i = 1; i <= 9; i++)
        soma = soma + parseInt(cpf.substring(i - 1, i)) * (11 - i)
    resto = (soma * 10) % 11
    if ((resto == 10) || (resto == 11)) resto = 0
    if (resto != parseInt(cpf.substring(9, 10))) return false
    soma = 0
    for (var i = 1; i <= 10; i++)
        soma = soma + parseInt(cpf.substring(i - 1, i)) * (12 - i)
    resto = (soma * 10) % 11
    if ((resto == 10) || (resto == 11)) resto = 0
    if (resto != parseInt(cpf.substring(10, 11))) return false
    return true
}

function validarCNPJ(cnpj) {

    cnpj = cnpj.replace(/[^\d]+/g, '');

    if (cnpj == '') return false;

    if (cnpj.length != 14)
        return false;

    // Elimina CNPJs invalidos conhecidos
    if (cnpj == "00000000000000" ||
        cnpj == "11111111111111" ||
        cnpj == "22222222222222" ||
        cnpj == "33333333333333" ||
        cnpj == "44444444444444" ||
        cnpj == "55555555555555" ||
        cnpj == "66666666666666" ||
        cnpj == "77777777777777" ||
        cnpj == "88888888888888" ||
        cnpj == "99999999999999")
        return false;

    // Valida DVs
    tamanho = cnpj.length - 2
    numeros = cnpj.substring(0, tamanho);
    digitos = cnpj.substring(tamanho);
    soma = 0;
    pos = tamanho - 7;
    for (i = tamanho; i >= 1; i--) {
        soma += numeros.charAt(tamanho - i) * pos--;
        if (pos < 2)
            pos = 9;
    }
    resultado = soma % 11 < 2 ? 0 : 11 - soma % 11;
    if (resultado != digitos.charAt(0))
        return false;

    tamanho = tamanho + 1;
    numeros = cnpj.substring(0, tamanho);
    soma = 0;
    pos = tamanho - 7;
    for (i = tamanho; i >= 1; i--) {
        soma += numeros.charAt(tamanho - i) * pos--;
        if (pos < 2)
            pos = 9;
    }
    resultado = soma % 11 < 2 ? 0 : 11 - soma % 11;
    if (resultado != digitos.charAt(1))
        return false;

    return true;

}