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
        public ActionResult Escolha_01_Resposta00_Cena_01()
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

                return RedirectToAction("Jogo", "HNI");
            }
            else
            {
                return RedirectToAction("Login_Erro", "HNI");
            }
     
        }
    }

}