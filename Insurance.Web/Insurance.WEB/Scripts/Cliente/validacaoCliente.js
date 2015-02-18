function removerClasseAviso() {
    $("#TXTSobrenome").removeClass("campoInvalido");
    $("#TXTIdade").removeClass("campoInvalido");
    $("#TXTCPF").removeClass("campoInvalido");
    $("#TXTRG").removeClass("campoInvalido");
    $("#TXTNome").removeClass("campoInvalido");
}




function TestaCPF(strCPF) {
    var Soma; var Resto;
    Soma = 0;
    if (strCPF == "00000000000")
        return false;
    for (i = 1; i <= 9; i++)
        Soma = Soma + parseInt(strCPF.substring(i - 1, i)) * (11 - i);
    Resto = (Soma * 10) % 11; if ((Resto == 10) || (Resto == 11)) Resto = 0;
    if (Resto != parseInt(strCPF.substring(9, 10)))
        return false;
    Soma = 0;
    for (i = 1; i <= 10; i++)
        Soma = Soma + parseInt(strCPF.substring(i - 1, i)) * (12 - i);
    Resto = (Soma * 10) % 11; if ((Resto == 10) || (Resto == 11)) Resto = 0;
    if (Resto != parseInt(strCPF.substring(10, 11)))
        return false;
    return true;
}

function isInteger(valor) {
    return valor % 1 === 0;
}




$("#BTNConfirmar").on("click", function () {


    removerClasseAviso();
    camposValidos = true;
    msg = "";
    removerClasseAviso();
    idade = $("#TXTIdade").val().trim();
    CPF = $("#TXTCPF").val().trim();
    sobrenome = $("#TXTSobrenome").val().trim();
    RG = $("#TXTRG").val().trim();
    nome = $("#TXTNome").val().trim();




    if (idade == "") {
        camposValidos = false;
        msg += "A idade Não pode estar em branco ";
        $("#TXTIdade").addClass("campoInvalido");
    }
    else {
        if (isNaN(idade)) {
            camposValidos = false;
            msg += "A idade deve ser numérica, ";
            $("#TXTIdade").addClass("campoInvalido");
        }
        else {
            if (!isInteger(idade)) {
                msg += "A idade deve ser um numero inteiro, ";
                $("#TXTIdade").addClass("campoInvalido");
                camposValidos = false;
            }

            else {

                if (parseInt(idade, 10) < 18) {
                    msg += "Menores de idade nao podem se cadastrar, ";
                    $("#TXTIdade").addClass("campoInvalido");
                    camposValidos = false;
                }
            }
        }

    }
    if (nome == "") {
        camposValidos = false;
        msg += "O nome nao pode estar em branco, ";
        $("#TXTNome").addClass("campoInvalido");
    }

    if (sobrenome == "") {
        camposValidos = false;
        msg += "O sobrenome nao pode estar em branco, ";
        $("#TXTSobrenome").addClass("campoInvalido");
    }

    if (RG == "") {
        camposValidos = false;
        msg += "O RG não pode estar em branco, ";
        $("#TXTRG").addClass("campoInvalido");
    }

    if (CPF == "") {
        camposValidos = false;
        msg += "O CPF não pode estar em branco, ";
        $("#TXTCPF").addClass("campoInvalido");
    }

    else {
        if (!TestaCPF(CPF)) {
            camposValidos = false;
            msg += "O CPF possui uma numeração inválida, ";
            $("#TXTCPF").addClass("campoInvalido");
        }
    }

    if (camposValidos) {

        data = {
            Nome: $("#TXTNome").val(),
            Sobrenome: $("#TXTSobrenome").val(),
            Idade: $("#TXTIdade").val(),
            CPF: $("#TXTCPF").val(),
            RG: $("#TXTRG").val(),
            Sexo: $("DDLSexo").val()
        }
        $.ajax({
            type: "POST",
            url: "Cadastro/Cadastrar",
            contentType: "application/json;charset=utf-8",
            data: JSON.stringify({ dado: data }),
            dataType: "json",
            async: true,
            cache: false
        }).done(function (response) {
            var result = $.parseJSON(response.d);
            if (response.sucess) {
                $("#divMensagem").html("Operação realizada com sucesso.");
            } else {
                $("#divMensagem").html("Ocorreu um erro. </br>" + response.message);
            }
            $("#divMensagem").show();
            $("#divFormCadastro").hide();
        }).fail(function (response) {
            $("#divMensagem").html("Operação não pode ser efetuada.");
            $("#divMensagem").show();
            $("#divFormCadastro").hide();
        });
    }

    else {

        alert(msg);
    }
});