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
           u= new UsuarioDAO().Login(obj);
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
            c=ca.Buscar(obj);
            UsuarioDAO ud = new UsuarioDAO();
            HttpCookie cookie = Request.Cookies.Get("Usuario");
            Int32 u=Convert.ToInt32(cookie.Value);
            obj.Usuario=ud.Buscar(u);
            PersonagemDAO p = new PersonagemDAO();
            obj.AtkF = c.AtkF;
            obj.AtkM = c.AtkM;
            obj.Def = c.Def;
            obj.Imagem = c.Imagem;
            obj.Mana = c.Mana;
            obj.Hp = c.Hp;
            obj.Genero = "Masculino";
            p.Inserir(obj);
            Response.Cookies.Add(new HttpCookie("Personagem", Convert.ToString(obj.Id)));
            return RedirectToAction("Escolha", "HNI");

        }

    }

}