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
        public ActionResult Inventario()
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
            if (obj.DataNasc >= )

                if (!ValidarEmail(obj.Email))
                {
                    ViewBag.ErroMns = " Erro na validação de Email";
                    return View("Cadastro");
                }

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
            AtkE A = new AtkE();
            AtkEDAO AD = new AtkEDAO();
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
            A = ca.Buscar_AtkE(c.Id, 1);
            if (A.Nome == "E")
            {
                AD.Aprender(A.Id, Person.Id, 1);
            }
            A = ca.Buscar_AtkE(c.Id, 2);
            if (A.Nome == "E")
            {
                AD.Aprender(A.Id, Person.Id, 2);
            }
            A = ca.Buscar_AtkE(c.Id, 3);
            if (A.Nome == "E")
            {
                AD.Aprender(A.Id, Person.Id, 3);
            }
            A = ca.Buscar_AtkE(c.Id, 4);
            if (A.Nome == "E")
            {
                AD.Aprender(A.Id, Person.Id, 4);
            }

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
            S.Salvar(C, Qu.Id, P, U);

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
            LojaDAO Loja = new LojaDAO();
            Item item = new Item();
            O = Convert.ToInt32(cookieO.Value);
            P = Convert.ToInt32(cookieP.Value);
            Per = PD.BuscarP(P);
            item = Loja.Buscar_Item(iitem);
            if (O == 1)
            {
                V = Per.Ouro - item.Valor;
                if (V >= 0)
                {
                    Loja.Comprar(V, Per.Id);
                    Qtd = Loja.Verificar(item.Id, Per.Id);
                    Loja.Pegar(item.Id, Per.Id, Qtd + 1);
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
            R = rnd.Next(1, 200);

            if (R <= 50)
            {
                Response.Cookies.Add(new HttpCookie("Dano da Criatura", Convert.ToString(0)));
                Response.Cookies.Add(new HttpCookie("Dano do Personagem", Convert.ToString(0)));
                Response.Cookies.Add(new HttpCookie("Utilização do Personagem", Convert.ToString(0)));
                Response.Cookies.Add(new HttpCookie("Utilização da Criatura", Convert.ToString(0)));
                C = rnd.Next(D.CrtInicial, (D.CrtFinal + 1));
                if (C != 0)
                {
                    if (C == 17)
                    {
                        R2 = rnd.Next(1, 5000);
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


        public ActionResult Batalhar(int Acao)
        {
            HttpCookie cookieC = Request.Cookies.Get("Criatura");
            HttpCookie cookieP = Request.Cookies.Get("Personagem");
            HttpCookie cookieDC = Request.Cookies.Get("Dano da Criatura");
            HttpCookie cookieDP = Request.Cookies.Get("Dano do Personagem");
            HttpCookie cookieUC = Request.Cookies.Get("Utilização da Criatura");
            HttpCookie cookieUP = Request.Cookies.Get("Utilização do Personagem");

            PersonagemDAO PD = new PersonagemDAO();
            CriaturaDAO CD = new CriaturaDAO();
            Personagem P = new Personagem();
            Criatura C = new Criatura();
            int p;
            int c;
            int DC;
            int UC;
            int UP;
            int DP;
            int M;
            int R;
            int R2;
            Random rnd = new Random();

            p = Convert.ToInt32(cookieP.Value);
            c = Convert.ToInt32(cookieC.Value);
            DC = Convert.ToInt32(cookieDC.Value);
            UC = Convert.ToInt32(cookieUC.Value);
            UP = Convert.ToInt32(cookieUP.Value);
            DP = Convert.ToInt32(cookieDP.Value);
            P = PD.Buscar_Id(P);
            C = CD.Buscar(c);


            if (Acao == 1)
            {

                M = ((P.AtkF * 20) / 100);
                R = rnd.Next(M, (P.AtkF + 1));
                M = ((C.Def) * 30 / 100);
                R2 = rnd.Next(M, (C.Def + 1));
                R = R - R2;
                if (R > 0)
                {
                    DP = DP + R;
                    C.Hp = C.Hp - DP;
                    if (C.Hp > 0)
                    {

                        Response.Cookies.Add(new HttpCookie("Dano do Personagem", Convert.ToString(DP)));
                        return RedirectToAction("CriaturaAcao", "HNI", new { @Def = 0 });
                    }
                    else
                    {
                        P.Exp = P.Exp + C.Exp;
                        P.Nivel = P.Nivel * 100;
                        P.Ouro = P.Ouro + C.Ouro;
                        if (P.Exp == P.Nivel)
                        {
                            P.Nivel = (P.Nivel / 100) + 1;
                            P.Exp = (0);
                            return RedirectToAction("Passar_Nivel", "HNI");
                        }
                        PD.Status_Atualizacao(P.Id, P.Nivel, P.Exp, P.Ouro, P.Mana, P.Hp, P.AtkF, P.AtkM, P.Def);
                        return RedirectToAction("Lugar", "HNI");
                    }
                }
                else
                {
                    return RedirectToAction("CriaturaAcao", "HNI", new { @Def = 0 });
                }
            }
            if (Acao == 2)
            {
                M = (P.Def * 4 / 10);
                int Def = rnd.Next(M, (P.Def + 1));
                return RedirectToAction("CriaturaAcao", "HNI", new { @Def = Def });
            }
            if (Acao == 3)
            {
                int F;
                F = rnd.Next(1, 101);
                if (F <= 10)
                {
                    return RedirectToAction("Lugar", "HNI");

                }
                return RedirectToAction("CriaturaAcao", "HNI", new { @Def = 0 });
            }
            else
            {
                return RedirectToAction("CriaturaAcao", "HNI", new { @Def = 0 });
            }
        }



        public ActionResult CriaturaAcao(int Def)
        {
            HttpCookie cookieC = Request.Cookies.Get("Criatura");
            HttpCookie cookieP = Request.Cookies.Get("Personagem");
            HttpCookie cookieDC = Request.Cookies.Get("Dano da Criatura");
            HttpCookie cookieDP = Request.Cookies.Get("Dano do Personagem");
            HttpCookie cookieUC = Request.Cookies.Get("Utilização da Criatura");
            HttpCookie cookieUP = Request.Cookies.Get("Utilização do Personagem");

            PersonagemDAO PD = new PersonagemDAO();
            CriaturaDAO CD = new CriaturaDAO();
            Personagem P = new Personagem();
            Criatura C = new Criatura();
            int p;
            int c;
            int DC;
            int UC;
            int UP;
            int DP;
            int M;
            int R;
            Random rnd = new Random();

            p = Convert.ToInt32(cookieP.Value);
            c = Convert.ToInt32(cookieC.Value);
            DC = Convert.ToInt32(cookieDC.Value);
            UC = Convert.ToInt32(cookieUC.Value);
            UP = Convert.ToInt32(cookieUP.Value);
            DP = Convert.ToInt32(cookieDP.Value);
            P = PD.Buscar_Id(P);
            C = CD.Buscar(c);

            R = rnd.Next(1, 5);

            if (R <= 3)
            {
                M = (C.AtkF / 100);
                R = rnd.Next(M, (C.AtkF + 1));
                DC = DC + R;
                DC = DC - Def;
                P.Hp = P.Hp - DC;

                if (P.Hp > 0)
                {
                    Response.Cookies.Add(new HttpCookie("Dano da Criatura", Convert.ToString(DC)));
                    return RedirectToAction("Batalha", "HNI");
                }
                else
                {
                    return RedirectToAction("Perda", "HNI");
                }
            }
            if (R == 4)
            {
                AtkEDAO AD = new AtkEDAO();
                BatalhaDAO BD = new BatalhaDAO();
                AtkE A = new AtkE();
                A = BD.Buscar_Id_Atke_Criatura(C.Id, 1);
                if (A.Nome == "E")
                {
                    int I;
                    int AF;
                    int AFR;
                    int AM;
                    int AMR;

                    I = A.Id;
                    A = AD.Buscar(I);
                    M = (C.AtkM / 10);
                    AF = (A.AtkF / 50);
                    AM = (A.AtkM / 50);

                    R = rnd.Next(M, (C.AtkM + 1));
                    AFR = rnd.Next(AF, (A.AtkF + 1));
                    AMR = rnd.Next(AM, (A.AtkM + 1));

                    DC = DC + R + AFR + AMR;
                    DC = DC - Def;
                    P.Hp = P.Hp - DC;
                    UC = UC + A.Mana;
                    C.Mana = C.Mana - UC;
                    if (C.Mana > 0)
                    {
                        if (P.Hp > 0)
                        {
                            Response.Cookies.Add(new HttpCookie("Utilização da Criatura", Convert.ToString(UC)));
                            Response.Cookies.Add(new HttpCookie("Dano da Criatura", Convert.ToString(DC)));
                            return RedirectToAction("Batalha", "HNI");
                        }
                        else
                        {
                            return RedirectToAction("Perda", "HNI");
                        }
                    }
                    else
                    {
                        return RedirectToAction("CriaturaAcao", "HNI", new { @Def = Def });
                    }

                }
                else
                {

                    return RedirectToAction("CriaturaAcao", "HNI", new { @Def = Def });
                }
            }
            else
            {
                return RedirectToAction("Batalha", "HNI");

            }


        }

        public ActionResult AtaqueE(int Id)
        {
            HttpCookie cookieC = Request.Cookies.Get("Criatura");
            HttpCookie cookieP = Request.Cookies.Get("Personagem");
            HttpCookie cookieDC = Request.Cookies.Get("Dano da Criatura");
            HttpCookie cookieDP = Request.Cookies.Get("Dano do Personagem");
            HttpCookie cookieUC = Request.Cookies.Get("Utilização da Criatura");
            HttpCookie cookieUP = Request.Cookies.Get("Utilização do Personagem");

            PersonagemDAO PD = new PersonagemDAO();
            CriaturaDAO CD = new CriaturaDAO();
            Personagem P = new Personagem();
            Criatura C = new Criatura();
            int p;
            int c;
            int DC;
            int UC;
            int UP;
            int DP;
            int M;
            int R;
            int R2;
            Random rnd = new Random();

            p = Convert.ToInt32(cookieP.Value);
            c = Convert.ToInt32(cookieC.Value);
            DC = Convert.ToInt32(cookieDC.Value);
            UC = Convert.ToInt32(cookieUC.Value);
            UP = Convert.ToInt32(cookieUP.Value);
            DP = Convert.ToInt32(cookieDP.Value);
            P = PD.Buscar_Id(P);
            C = CD.Buscar(c);
            AtkEDAO AD = new AtkEDAO();
            BatalhaDAO BD = new BatalhaDAO();
            AtkE A = new AtkE();
            A = BD.Buscar_Id_Atke_Personagem(P.Id, Id);
            if (A.Nome == "E")
            {
                int I;
                int AF;
                int AFR;
                int AM;
                int AMR;

                I = A.Id;
                A = AD.Buscar(I);
                M = (P.AtkM / 10);
                AF = (A.AtkF / 50);
                AM = (A.AtkM / 50);

                R = rnd.Next(M, (C.AtkM + 1));
                AFR = rnd.Next(AF, (A.AtkF + 1));
                AMR = rnd.Next(AM, (A.AtkM + 1));
                M = ((C.Def) * 30 / 100);
                R2 = rnd.Next(M, (C.Def + 1));
                DP = DP + R + AFR + AMR;
                DP = DP - R2;
                C.Hp = C.Hp - DP;
                UP = UP + A.Mana;
                M = P.Mana - UP;

                if (M > 0)
                {
                    if (C.Hp > 0)
                    {
                        DC = DC - A.Hp;
                        Response.Cookies.Add(new HttpCookie("Dano da Criatura", Convert.ToString(DC)));
                        Response.Cookies.Add(new HttpCookie("Utilização do Personagem", Convert.ToString(UP)));
                        Response.Cookies.Add(new HttpCookie("Dano do Personagem", Convert.ToString(DP)));
                        return RedirectToAction("CriaturaAcao", "HNI", new { @Def = A.Def });

                    }
                    else
                    {

                        P.Exp = P.Exp + C.Exp;
                        P.Nivel = P.Nivel * 100;
                        P.Ouro = P.Ouro + C.Ouro;
                        if (P.Exp == P.Nivel)
                        {
                            P.Nivel = (P.Nivel / 100) + 1;
                            P.Exp = (0);
                            return RedirectToAction("Passar_Nivel", "HNI");
                        }
                        PD.Status_Atualizacao(P.Id, P.Nivel, P.Exp, P.Ouro, P.Mana, P.Hp, P.AtkF, P.AtkM, P.Def);
                        return RedirectToAction("Lugar", "HNI");
                    }
                }
                else
                {
                    return RedirectToAction("CriaturaAcao", "HNI", new { @Def = 0 });
                }

            }
            else
            {

                return RedirectToAction("CriaturaAcao", "HNI", new { @Def = 0 });
            }
        }


        public ActionResult Passar_Nivel()
        {
            return RedirectToAction("Inventario", "HNI");
        }

        public ActionResult Perda()
        {
            HttpCookie cookie = Request.Cookies.Get("Questao");
            HttpCookie cookiec = Request.Cookies.Get("Cena");
            HttpCookie cookieP = Request.Cookies.Get("Personagem");
            PersonagemDAO PD = new PersonagemDAO();
            Personagem P = new Personagem();
            int p;
            int c;
            int q;
            p = Convert.ToInt32(cookieP.Value);
            c = Convert.ToInt32(cookiec.Value);
            q = Convert.ToInt32(cookie.Value);
            P.Ouro = P.Ouro - 1000;
            if (P.Ouro < 0)
            {
                P.Ouro = 0;
            }
            c = c - 1;
            q = q - 1;
            PD.Status_Atualizacao(P.Id, P.Nivel, P.Exp, P.Ouro, P.Mana, P.Hp, P.AtkF, P.AtkM, P.Def);
            Response.Cookies.Add(new HttpCookie("Questao", Convert.ToString(q)));
            Response.Cookies.Add(new HttpCookie("Cena", Convert.ToString(c)));
            return View();
        }

        private bool ValidarEmail(string email)
        {
            if (String.IsNullOrEmpty(email))
                return false;
            if (!email.Contains("@") || !email.Contains("."))
                return false;
            string[] strCamposEmail = email.Split(new String[] { "@" }, StringSplitOptions.RemoveEmptyEntries);
            if (strCamposEmail.Length != 2)
                return false;
            if (strCamposEmail[0].Length < 3)
                return false;
            if (!strCamposEmail[1].Contains("."))
                return false;
            strCamposEmail = strCamposEmail[1].Split(new String[] { "." }, StringSplitOptions.RemoveEmptyEntries);
            if (strCamposEmail.Length < 2)
                return false;
            if (strCamposEmail[0].Length < 1)
                return false;
            return true;
        }

    }


}