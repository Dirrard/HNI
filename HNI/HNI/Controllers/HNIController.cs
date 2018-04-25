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
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult Ajuda()
        {
            return View();
        }
        public ActionResult Salvar_U(Usuario obj)
        {
            new UsuarioDAO().Inserir(obj);
            return RedirectToAction("Index", "Home");
        }
        public ActionResult Login_U(Usuario obj)
        {
            new UsuarioDAO().Login(obj);
            return RedirectToAction("Jogo", "HNI");
        }
    }
}