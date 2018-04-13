using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
        public ActionResult Login()
        {
            return View();
        }
    }
}