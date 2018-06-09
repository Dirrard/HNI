using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HNI.Models;
using HNI.Dataaccess;
namespace Teste
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void LoginTest()
        {
            UsuarioDAO UD = new UsuarioDAO();
            Usuario U = new Usuario();
            Usuario U2 = new Usuario();
            U.Email = "diegocastilho6@gmail.com";
            U.Senha = "diego123";

            U2 = UD.Login(U);
            Assert.IsTrue(U2.Termo);
           
        }
    }
}
