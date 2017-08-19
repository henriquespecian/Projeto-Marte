var ListaSondas = [];

function Sondas(PosicaoInicialX, PosicaoInicialY, DirecaoInicial, Movimento) {
    this.PosicaoInicialX = PosicaoInicialX;
    this.PosicaoInicialY = PosicaoInicialY;
    this.DirecaoInicial = DirecaoInicial;
    this.Movimento = Movimento;
}

function adicionarSonda() {

    var x = document.getElementById("PosicaoInicialX");
    var y = document.getElementById("PosicaoInicialY");
    var d = document.getElementById("DirecaoInicial");
    var m = document.getElementById("Movimento");


    if (x.value != "" && y.value != "" && d.value != "" && m.value != "") {

        var s = new Sondas(x.value, y.value, d.value, m.value);

        ListaSondas.push(s);

        x.value = "";
        y.value = "";
        d.value = "";
        m.value = "";


        alert("Sonda inserida com sucesso!");
    }
    else {
        alert('É necessário preencher todos os campos da sonda')
    }
}


function submit() {

    var x = document.getElementById("EntradaX");
    var y = document.getElementById("EntradaY");

    if (x.value != "" && y.value != "" && ListaSondas.length != 0) {

        $.ajax({
            contentType: 'application/json; charset=utf-8',
            dataType: 'json',
            type: 'POST',
            url: "/Home/Salvar",
            data: JSON.stringify({ 'ListaSondas': ListaSondas, 'x': $("#EntradaX").val(), 'y': $("#EntradaY").val() }),
            success: function (data) {

                if (data.Sucesso === true) {

                    var msg = "";

                    for (var i = 0; i < data.ListaSondas.length; i++) {
                        msg = msg + "Posição da Sonda: " + "[" + (i + 1) + "]"
                            + " " + data.ListaSondas[i].PosicaoInicialX
                            + " " + data.ListaSondas[i].PosicaoInicialY
                            + " " + data.ListaSondas[i].DirecaoInicial
                            + "\n";
                    }

                    window.alert(msg);

                    window.location.href = '/Home/Index';
                }
                else {
                    window.alert(data.Mensagem);

                    window.location.href = '/Home/Index';
                }
            },
            error: function (jqXhr, textStatus, errorThrown) {

            }
        });
    }
    else {
        alert("É necessário definir a malha e adicionar ao menos uma sonda");
    }
}