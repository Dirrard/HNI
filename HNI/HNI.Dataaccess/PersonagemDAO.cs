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
        public void Inserir(Personagem obj)
        {
            {
                using (SqlConnection conn =
                    new SqlConnection(@"Initial Catalog=HNI;
                        Data Source=localhost;
                        Integrated Security=SSPI;"))
                {
                    string strSQL = @"INSERT INTO Personagem (Nome,Classe,Imagem,Genero,Ouro,Mana,Hp,AtkF,AtkM,Def,Nivel,[Exp],Id_Usuario)
                                 VALUES (@nome,@classe,@imagem,@genero,@ouro,@mana,@hp,@atkf,@atkm,@def,@nivel,@exp,@usuario);";

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
                        conn.Open();

                        cmd.ExecuteNonQuery();

                        conn.Close();
                    }
                }
            }
        }
    }
}
