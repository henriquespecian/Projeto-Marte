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

        public JsonResult Salvar(List<SondasEntidade> ListaSondas, int x, int y)
        {
            try
            {

                var DirecaoAtual = "";

                //Percorre as sondas
                foreach (var sonda in ListaSondas)
                {
                    //Verifica se a posição está dentro do limite definido
                    if (sonda.PosicaoInicialX > x || sonda.PosicaoInicialX > y)
                        throw new Exception("Posição de Sonda fora dos limites");

                    char[] m = sonda.Movimento.ToUpper().ToCharArray();

                    DirecaoAtual = sonda.DirecaoInicial.ToUpper();

                    //Executa os movimentos
                    foreach(char c in m)
                    {
                        //Verifica se a posição está dentro do limite definido
                        if (sonda.PosicaoInicialX > x || sonda.PosicaoInicialX > y)
                            throw new Exception("Posição de Sonda fora dos limites");

                        //Executa cada movimento
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

                return Json(new { Sucesso = true, Mensagem = "", ListaSondas = ListaSondas });
            }
            catch (Exception ex)
            {
                return Json(new { Sucesso = false, Mensagem = ex.Message });
            }            
        }
    }
}