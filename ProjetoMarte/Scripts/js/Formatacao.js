function somenteNumeros(num) {
    var er = /[^0-9]/;
    er.lastIndex = 0;
    var campo = num;
    if (er.test(campo.value)) {
        campo.value = "";
    }
}


function movimentos(le) {
    var er = /[^l|r|m|L|R|M]/;
    er.lastIndex = 0;
    var campo = le;
    if (er.test(campo.value)) {
        campo.value = "";
    }
}

function posicao(le) {
    var er = /[^n|s|e|w|N|S|E|W]/;
    er.lastIndex = 0;
    var campo = le;
    if (er.test(campo.value)) {
        campo.value = "";
    }
}