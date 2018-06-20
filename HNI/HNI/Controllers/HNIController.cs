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
            int Q;
            Q = Convert.ToInt32(cookie.Value);

            Q = (Q * 10) + resposta;
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
    }

}