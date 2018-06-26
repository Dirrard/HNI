using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HNI.Models;
using HNI.Dataaccess;

namespace HNI.Controllers
{
    public class HNIController : Controller
    {
        // GET: HNI
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Carregar_Jogo()
        {
            return View();
        }
        public ActionResult Cadastro()
        {
            return View();
        }
        public ActionResult Termo()
        {
            return View();
        }
        public ActionResult Jogo()
        {
            return View();
        }
        public ActionResult Loja()
        {
            return View();
        }
        public ActionResult Lugar()
        {
            return View();
        }
        public ActionResult Batalha()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult Login_Erro()
        {
            return View();
        }
        public ActionResult Ajuda()
        {
            return View();
        }
        public ActionResult Criar_Personagem()
        {
            return View();
        }
        public ActionResult Escolha()
        {
            return View();
        }
        public ActionResult Cadastro_Erro()
        {
            return View();
        }
        public ActionResult Salvar_U(Usuario obj)
        {
            if (obj.Termo == true && obj.Senha == obj.ConfSenha)
            {
                new UsuarioDAO().Inserir(obj);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return RedirectToAction("Cadastro_Erro", "HNI");
            }

        }
        public ActionResult Login_U(Usuario obj)
        {
            Usuario u = new Usuario();
            u = new UsuarioDAO().Login(obj);
            if (u.Termo == true)
            {
                Response.Cookies.Add(new HttpCookie("Usuario", Convert.ToString(u.Id)));
                return RedirectToAction("Jogo", "HNI");

            }
            else
            {
                return RedirectToAction("Login_Erro", "HNI");
            }

        }
        public ActionResult Criar_P(Personagem obj)
        {
            obj.Ouro = 100;
            obj.Nivel = 1;
            obj.Exp = 0;
            ClasseDAO ca = new ClasseDAO();
            Classe c = new Classe();
            c = ca.Buscar(obj);
            UsuarioDAO ud = new UsuarioDAO();
            HttpCookie cookie = Request.Cookies.Get("Usuario");
            Int32 u = Convert.ToInt32(cookie.Value);
            obj.Usuario = ud.Buscar(u);
            PersonagemDAO p = new PersonagemDAO();
            obj.AtkF = c.AtkF;
            obj.AtkM = c.AtkM;
            obj.Def = c.Def;
            obj.Imagem = c.Imagem;
            obj.Mana = c.Mana;
            obj.Hp = c.Hp;
            obj.Genero = "Masculino";
            p.Inserir(obj);
            Personagem Person = new Personagem();
            Person = p.Buscar_Id(obj);
            Response.Cookies.Add(new HttpCookie("Personagem", Convert.ToString(Person.Id)));
            Response.Cookies.Add(new HttpCookie("Questao", Convert.ToString(1)));
            Response.Cookies.Add(new HttpCookie("Cena", Convert.ToString(1)));
            return RedirectToAction("Escolha", "HNI");

        }
        public ActionResult Escolher(int resposta)
        {
            HttpCookie cookie = Request.Cookies.Get("Questao");
            HttpCookie cookiec = Request.Cookies.Get("Cena");
            int Q;
            int C;
            Cena Cena = new Cena();
            EscolhaDAO ES = new EscolhaDAO();
            C = Convert.ToInt32(cookiec.Value);
            Cena = ES.Buscar_Cena(C);
            Q = Convert.ToInt32(cookie.Value);
            Q = (Q * 10) + resposta;
            if (Q < Cena.Fim)
            {
                if (resposta == 0)
                {
                    Q = (Q / 100);
                    Response.Cookies.Add(new HttpCookie("Questao", Convert.ToString(Q)));
                    return RedirectToAction("Escolha", "HNI");
                }
                else
                {
                    Response.Cookies.Add(new HttpCookie("Questao", Convert.ToString(Q)));
                    return RedirectToAction("Escolha", "HNI");
                }
            }
            else
            {
                Q = Cena.Identidade + 1;
                Response.Cookies.Add(new HttpCookie("Questao", Convert.ToString(Q)));
                Response.Cookies.Add(new HttpCookie("Passos", Convert.ToString(0)));
                Response.Cookies.Add(new HttpCookie("Cena", Convert.ToString(Q)));
                return RedirectToAction("Lugar", "HNI");
            }

        }
        public ActionResult Bestiario()
        {
            
            return View();
        }
        public ActionResult Salvar()
        {
            SaveDAO S = new SaveDAO();
            EscolhaDAO ES = new EscolhaDAO();
            Questao Qu = new Questao();
            HttpCookie cookieq = Request.Cookies.Get("Questao");
            HttpCookie cookiep = Request.Cookies.Get("Personagem");
            HttpCookie cookiec = Request.Cookies.Get("Cena");
            HttpCookie cookieu = Request.Cookies.Get("Usuario");
            int Q = Convert.ToInt32(cookieq.Value);
            int U = Convert.ToInt32(cookieq.Value);
            int P = Convert.ToInt32(cookiep.Value);
            int C = Convert.ToInt32(cookiec.Value);
            Qu = ES.Buscar_Questao(Q);
            S.Salvar(C,Qu.Id,P,U);
            
            return RedirectToAction("Salvado", "HNI");
        }
        public ActionResult Salvado()
        {
            return View();
        }
        public ActionResult Item_Loja(int o)
        {
            Response.Cookies.Add(new HttpCookie("Operacao", Convert.ToString(o)));
            return RedirectToAction("Loja", "HNI");

        }
        public ActionResult Operacao(int iitem)
        {
            HttpCookie cookieO = Request.Cookies.Get("Operacao");
            HttpCookie cookieP = Request.Cookies.Get("Personagem");
            int P;
            int O;
            int V;
            int Qtd;
            Personagem Per = new Personagem();
            PersonagemDAO PD = new PersonagemDAO();
            LojaDAO Loja= new LojaDAO();
            Item item = new Item();
            O = Convert.ToInt32(cookieO.Value);
            P = Convert.ToInt32(cookieP.Value);
            Per=PD.BuscarP(P);
            item = Loja.Buscar_Item(iitem);
            if (O == 1)
            {
                V = Per.Ouro - item.Valor;
                if (V >= 0)
                {
                    Loja.Comprar(V,Per.Id);
                   Qtd = Loja.Verificar(item.Id, Per.Id);
                    Loja.Pegar(item.Id,Per.Id,Qtd+1);
                    return RedirectToAction("Loja", "HNI");
                }
                else
                {
                    return RedirectToAction("Loja", "HNI");
                }
            }
            else
            {
                return RedirectToAction("Loja", "HNI");
            }
        }
        public ActionResult Mover(int A)
        {
            HttpCookie cookie = Request.Cookies.Get("Lugar");
            HttpCookie cookieQ = Request.Cookies.Get("Questao");
            HttpCookie cookieP = Request.Cookies.Get("Passos");
            MundoDAO MD = new MundoDAO();
            EscolhaDAO ED = new EscolhaDAO();
            Lugar L = new Lugar();
            Distancia D = new Distancia();
            int Q;
            int Ini;
            int P;
            Q = Convert.ToInt32(cookieQ.Value);
            Ini = Convert.ToInt32(cookie.Value);
            P = Convert.ToInt32(cookieP.Value);
            L = ED.Buscar_Lugar_Id(Q);
            L = ED.Buscar_Lugar(L.Id);
            D = MD.Buscar_Distancia(Ini, L.Id);
            int R;
            int R2;
            int C;
            Random rnd = new Random();
            R = rnd.Next(1,200);

            if (R <= 50)
            {
                C = rnd.Next(D.CrtInicial,(D.CrtFinal+1));
                if (C != 0)
                {
                    if (C == 17)
                    {
                        R2 = rnd.Next(1,5000);
                        if (R2 <= 5)
                        {
                            Response.Cookies.Add(new HttpCookie("Criatura", Convert.ToString(C)));
                            return RedirectToAction("Batalha", "HNI");
                        }
                        else
                        {
                            if (P >= D.Passos)
                            {
                                return RedirectToAction("Escolha", "HNI");
                            }
                            else
                            {
                                P = P + A;
                                Response.Cookies.Add(new HttpCookie("Passos", Convert.ToString(P)));
                                return RedirectToAction("Lugar", "HNI");
                            }
                        }
                    }
                    else
                    {
                        Response.Cookies.Add(new HttpCookie("Criatura", Convert.ToString(C)));
                        return RedirectToAction("Batalha", "HNI");
                    }

                }
                else
                {
                    if (P >= D.Passos)
                    {
                        return RedirectToAction("Escolha", "HNI");
                    }
                    else
                    {
                        P = P + A;
                        Response.Cookies.Add(new HttpCookie("Passos", Convert.ToString(P)));
                        return RedirectToAction("Lugar", "HNI");
                    }
                }
            }
            else
            {
                if (P >= D.Passos)
                {
                    return RedirectToAction("Escolha", "HNI");
                }
                else
                {
                    P = P + A;
                    Response.Cookies.Add(new HttpCookie("Passos", Convert.ToString(P)));
                    return RedirectToAction("Lugar", "HNI");
                }
            }
        }
    }

}