using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjetoMarte.Models;
using ProjetoMarte.Entidades;

namespace ProjetoMarte.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public string MudaDirecao (string direcaoAtual, string direcao)
        {
            switch (direcaoAtual)
            {
                case "N":
                    if (direcao == "L")
                        direcaoAtual = "W";
                    else
                        direcaoAtual = "E";
                    break;
                case "S":
                    if (direcao == "L")
                        direcaoAtual = "E";
                    else
                        direcaoAtual = "W";
                    break;
                case "E":
                    if (direcao == "L")
                        direcaoAtual = "N";
                    else
                        direcaoAtual = "S";
                    break;
                case "W":
                    if (direcao == "L")
                        direcaoAtual = "S";
                    else
                        direcaoAtual = "N";
                    break;

            }

            return direcaoAtual;
        }

        public JsonResult Salvar(CoordenadasModel model)
        {
            try
            {
                var a = new SondasEntidade
                {
                    PosicaoInicialX = 1,
                    PosicaoInicialY = 2,
                    DirecaoInicial = "N",
                    Movimento = "LMLMLMLMM"
                };

                var d = new SondasEntidade
                {
                    PosicaoInicialX = 3,
                    PosicaoInicialY = 3,
                    DirecaoInicial = "E",
                    Movimento = "MMRMMRMRRM"
                };

                model.ListaSondas = new List<SondasEntidade>();
                model.ListaSondas.Add(a);
                model.ListaSondas.Add(d);

                var DirecaoAtual = "";

                foreach (var sonda in model.ListaSondas)
                {

                    if (sonda.PosicaoInicialX > model.EntradaX || sonda.PosicaoInicialX > model.EntradaY)
                        throw new Exception("Posição de Sonda fora dos limites");

                    char[] m = sonda.Movimento.ToCharArray();

                    DirecaoAtual = sonda.DirecaoInicial;

                    //Verificar e executar cada movimentos
                    foreach(char c in m)
                    {
                        if (sonda.PosicaoInicialX > model.EntradaX || sonda.PosicaoInicialX > model.EntradaY)
                            throw new Exception("Posição de Sonda fora dos limites");

                        //Verificar se essa posição existe
                        switch (c)
                        {
                            case 'L':
                                {
                                    DirecaoAtual = MudaDirecao(DirecaoAtual, "L");
                                }
                                break;
                            case 'R': 
                                {
                                    DirecaoAtual = MudaDirecao(DirecaoAtual, "R");
                                }
                                break;
                            case 'M':
                                {
                                    switch (DirecaoAtual)
                                    {
                                        case "N":
                                            sonda.PosicaoInicialY = sonda.PosicaoInicialY + 1;
                                            break;
                                        case "S":
                                            sonda.PosicaoInicialY = sonda.PosicaoInicialY - 1;
                                            break;
                                        case "E":
                                            sonda.PosicaoInicialX = sonda.PosicaoInicialX + 1;
                                            break;
                                        case "W":
                                            sonda.PosicaoInicialX = sonda.PosicaoInicialX - 1;
                                            break;
                                    }
                                }
                                break;
                        }
                    }

                    sonda.DirecaoInicial = DirecaoAtual;
                }               

                return Json(new { Sucesso = true, Mensagem = model.ListaSondas });
            }
            catch (Exception ex)
            {
                return Json(new { Sucesso = true, Mensagem = ex.Message });
            }            
        }
    }
}