//var ListaSondas = [];

//var j = 0;


//function Sondas(PosicaoInicialX, PosicaoInicialY, CodSondasImplantadas, Movimento) {
//    this.PosicaoInicialX = PosicaoInicialX;
//    this.PosicaoInicialY = PosicaoInicialY;
//    this.CodSondasImplantadas = CodSondasImplantadas;
//    this.Movimento = Movimento;
//}

//function adicionarSonda() {

//    var s = new Sondas(
//        $("#PosicaoInicialX").val(), 
//        $("#PosicaoInicialY").val(),
//        $("#CodSondasImplantadas").val(),
//        $("#Movimento").val()
//    );  

//    ListaSondas.push(s);  

//    $("#ListaSondas").val(ListaSondas);

//    console.log(ListaSondas);
//    console.log(j);
//    console.log(ListaSondas.length);

//    j++;

//}



function carregarJs() {
    $('#formEntrada').submit(function (ev) {

        var model = $('#formEntrada').serialize();

        //adicionarSonda();
        //adicionarSonda();
        //adicionarSonda();

        //model.ListaSondas = ListaSondas;

        //console.log(model.ListaSondas);

        $.ajax({
            url: "/Home/Salvar",
            type: 'POST',
            data: model,
            dataType: 'JSON',
            success: function (data) {

                if (data.Sucesso === true) {

                    window.alert(data.Mensagem);
                    //window.location.href = '/Bebida/Index';
                }
                else {
                    window.alert("Ocorreu um erro no cadastro");
                    //window.location.href = '/Bebida/Index';

                }
            },
            error: function (jqXhr, textStatus, errorThrown) {

            }
        });

        ev.preventDefault();
    });    
}