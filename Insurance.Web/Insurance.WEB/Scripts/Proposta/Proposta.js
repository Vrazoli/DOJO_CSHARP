radioAtual = null;

function selecionarRadio() {
    if (radioAtual !== null) {
        radioAtual.checked = false;
        
    }
    radioAtual = this;
}

bAindaHaCampos = true;
cont = 1;
for (; bAindaHaCampos;) {
    radioAtual = document.getElementById("radio " + cont);
    
    if (radioAtual !== null) {
     
        radioAtual.onclick = selecionarRadio;
    }
    else {
        bAindaHaCampos = false;
    
    }
    cont++;
}

$("BTNConfirmaProposta").on("click", function () {
    if (radioAtual !== null) {
        data = {
            idProposta: $(radioAtual.id.toString).find("input [type=hidden]").val()
        }
        $.ajax({
            type: "POST",
            url: "Proposta/selecionarProposta",
            contentType: "application/json;charset=utf-8",
            data: JSON.stringify({ dado: data }),
            dataType: "json",
            async: true,
            cache: false
        })
    }

    else {
        alert("Você precisa selecionar uma opção para prosseguir");
    }
});




//
