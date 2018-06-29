using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HNI.Models;
using System.Data.SqlClient;
using System.Data;

namespace HNI.Dataaccess
{
    public class PersonagemDAO
    {
        public void Inserir(Personagem obj,int identi)
        {
            {
                using (SqlConnection conn =
                    new SqlConnection(@"Initial Catalog=HNI;
                        Data Source=localhost;
                        Integrated Security=SSPI;"))
                {
                    string strSQL = @"INSERT INTO Personagem (Nome,Classe,Imagem,Genero,Ouro,Mana,Hp,AtkF,AtkM,Def,Nivel,[Exp],Id_Usuario,Identi)
                                 VALUES (@nome,@classe,@imagem,@genero,@ouro,@mana,@hp,@atkf,@atkm,@def,@nivel,@exp,@usuario,@Identi);";

                    using (SqlCommand cmd = new SqlCommand(strSQL))
                    {
                        cmd.Connection = conn;

                        cmd.Parameters.Add("@nome", SqlDbType.VarChar).Value = obj.Nome;
                        cmd.Parameters.Add("@imagem", SqlDbType.VarChar).Value = obj.Imagem;
                        cmd.Parameters.Add("@classe", SqlDbType.VarChar).Value = obj.Classe.Id;
                        cmd.Parameters.Add("@genero", SqlDbType.VarChar).Value = obj.Genero;
                        cmd.Parameters.Add("@ouro", SqlDbType.VarChar).Value = obj.Ouro;
                        cmd.Parameters.Add("@mana", SqlDbType.VarChar).Value = obj.Mana;
                        cmd.Parameters.Add("@hp", SqlDbType.VarChar).Value = obj.Hp;
                        cmd.Parameters.Add("@atkf", SqlDbType.VarChar).Value = obj.AtkF;
                        cmd.Parameters.Add("@atkm", SqlDbType.VarChar).Value = obj.AtkM;
                        cmd.Parameters.Add("@def", SqlDbType.VarChar).Value = obj.Def;
                        cmd.Parameters.Add("@nivel", SqlDbType.VarChar).Value = obj.Nivel;
                        cmd.Parameters.Add("@exp", SqlDbType.VarChar).Value = obj.Exp;
                        cmd.Parameters.Add("@usuario", SqlDbType.VarChar).Value = obj.Usuario.Id;
                        cmd.Parameters.Add("@Identi", SqlDbType.VarChar).Value = identi;
                        conn.Open();

                        cmd.ExecuteNonQuery();

                        conn.Close();
                    }
                }
            }
        }

        public Personagem Buscar_Id(Personagem obj)
        {


            using (SqlConnection conn = new SqlConnection(@"Initial Catalog=HNI;Data Source = localhost; Integrated Security=SSPI"))
            {
                string strSQL = @"SELECT * FROM Personagem where Nome = '" + obj.Nome + "' and Classe ='"+obj.Classe.Id+ "'and Nivel = ' "+obj.Nivel+"' and Id_Usuario ='"+obj.Usuario.Id+"'";

                using (SqlCommand cmd = new SqlCommand(strSQL))
                {
                    conn.Open();
                    cmd.Connection = conn;
                    cmd.CommandText = strSQL;
                    var dataReader = cmd.ExecuteReader();
                    var dt = new DataTable();
                    dt.Load(dataReader);
                    conn.Close();

                    foreach (DataRow row in dt.Rows)
                    {
                        var P = new Personagem()
                        {
                            Id = Convert.ToInt32(row["Id"]),
                        };
                        return P;

                    }
                }
            }
            Personagem Pa = new Personagem();
            return Pa;


        }

        public Personagem BuscarP(int Id)
        {


            using (SqlConnection conn = new SqlConnection(@"Initial Catalog=HNI;Data Source = localhost; Integrated Security=SSPI"))
            {
                string strSQL = @"SELECT * FROM Personagem where Id = '" + Id + "'" ;

                using (SqlCommand cmd = new SqlCommand(strSQL))
                {
                    conn.Open();
                    cmd.Connection = conn;
                    cmd.CommandText = strSQL;
                    var dataReader = cmd.ExecuteReader();
                    var dt = new DataTable();
                    dt.Load(dataReader);
                    conn.Close();

                    foreach (DataRow row in dt.Rows)
                    {
                        var P = new Personagem()
                        {
                            Id = Convert.ToInt32(row["Id"]),
                            Nome = row["Nome"].ToString(),
                            Imagem = row["Imagem"].ToString(),
                            Classe = new Classe()
                            {
                                Id = Convert.ToInt32(row["Classe"]),
                            },
                            Genero = row["Genero"].ToString(),
                            Ouro = Convert.ToInt32(row["Ouro"]),
                            Mana = Convert.ToInt32(row["Mana"]),
                            Hp   =  Convert.ToInt32(row["Hp"]),
                            AtkF =  Convert.ToInt32(row["AtkF"]),
                            AtkM = Convert.ToInt32(row["AtkM"]),
                            Def = Convert.ToInt32(row["Def"]),
                           Nivel = Convert.ToInt32(row["Nivel"]),
                            Exp = Convert.ToInt32(row["Exp"]),
                            Usuario = new Usuario
                            {
                                Id = Convert.ToInt32(row["Id_Usuario"]),
                            }
                    };
                        return P;

                    }
                }
            }
            Personagem Pa = new Personagem();
            return Pa;


        }

        public Personagem Buscar(int Id , int Identi)
        {


            using (SqlConnection conn = new SqlConnection(@"Initial Catalog=HNI;Data Source = localhost; Integrated Security=SSPI"))
            {
                string strSQL = @"SELECT * FROM Personagem where Usuario = '" + Id + "' and Identi ='"+Identi+"'";

                using (SqlCommand cmd = new SqlCommand(strSQL))
                {
                    conn.Open();
                    cmd.Connection = conn;
                    cmd.CommandText = strSQL;
                    var dataReader = cmd.ExecuteReader();
                    var dt = new DataTable();
                    dt.Load(dataReader);
                    conn.Close();

                    foreach (DataRow row in dt.Rows)
                    {
                        var P = new Personagem()
                        {
                            Id = Convert.ToInt32(row["Id"]),
                            Nome = row["Nome"].ToString(),
                            Imagem = row["Imagem"].ToString(),
                            Classe = new Classe()
                            {
                                Id = Convert.ToInt32(row["Classe"]),
                            },
                            Genero = row["Genero"].ToString(),
                            Ouro = Convert.ToInt32(row["Ouro"]),
                            Mana = Convert.ToInt32(row["Mana"]),
                            Hp = Convert.ToInt32(row["Hp"]),
                            AtkF = Convert.ToInt32(row["AtkF"]),
                            AtkM = Convert.ToInt32(row["AtkM"]),
                            Def = Convert.ToInt32(row["Def"]),
                            Nivel = Convert.ToInt32(row["Nivel"]),
                            Exp = Convert.ToInt32(row["Exp"]),
                            Usuario = new Usuario
                            {
                                Id = Convert.ToInt32(row["Id_Usuario"]),
                            }
                        };
                        return P;

                    }
                }
            }
            Personagem Pa = new Personagem();
            Pa.Nome = "N";
            return Pa;


        }
        public void Status_Atualizacao(int Id,int Nivel, int Exp, int Ouro, int Mana, int Hp, int AtkF, int AtkM, int Def)
        {
            {
                using (SqlConnection conn =
                    new SqlConnection(@"Initial Catalog=HNI;
                        Data Source=localhost;
                        Integrated Security=SSPI;"))
                {
                    string strSQL = @"UPDATE Personagem SET Nivel ='"+Nivel+"',Exp ='"+Exp+"',Ouro ='"+Ouro+"',Mana = '"+Mana+ "',Hp = '" + Hp+ "',AtkF = '" + AtkF + "',AtkM = '" + AtkM + "',Def= '" + Def + "' where Id ='"+Id+"'";
                     

                    using (SqlCommand cmd = new SqlCommand(strSQL))
                    {
                        cmd.Connection = conn;
                        conn.Open();

                        cmd.ExecuteNonQuery();

                        conn.Close();
                    }
                }
            }
        }

    }
}
