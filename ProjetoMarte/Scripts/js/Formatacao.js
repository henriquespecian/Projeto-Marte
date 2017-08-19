function mascara(num, id) {

    switch (id) {
        case 0:
            var er = /[^0-9]/;
            break;
        case 1:
            var er = /[^l|r|m|L|R|M]/;
            break;
        case 2:
            var er = /[^n|s|e|w|N|S|E|W]/;
            break;
    }    
        
    er.lastIndex = 0;
    var campo = num;
    if (er.test(campo.value)) {
        campo.value = "";
    }
}

