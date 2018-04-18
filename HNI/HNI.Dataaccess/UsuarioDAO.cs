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
    class UsuarioDAO
    {
        public void Inserir(Usuario obj)
        {
            {
                using (SqlConnection conn =
                    new SqlConnection(@"Initial Catalog=HNI;
                        Data Source=localhost;
                        Integrated Security=SSPI;"))
                {
                    string strSQL = @"INSERT INTO estado(Nome,Nick,Email,Senha,DataNasc,Genero )
                                 VALUES (@nome,@nick,@email,@senha,@datanasc,@genero);";

                    using (SqlCommand cmd = new SqlCommand(strSQL))
                    {
                        cmd.Connection = conn;

                        cmd.Parameters.Add("@nome", SqlDbType.VarChar).Value = obj.Nome;
                        cmd.Parameters.Add("@nick", SqlDbType.VarChar).Value = obj.Nick;
                        cmd.Parameters.Add("@email", SqlDbType.VarChar).Value = obj.Email;
                        cmd.Parameters.Add("@senha", SqlDbType.VarChar).Value = obj.Senha;
                        cmd.Parameters.Add("@datanasc", SqlDbType.VarChar).Value = obj.DataNasc;
                        cmd.Parameters.Add("@genero", SqlDbType.VarChar).Value = obj.Genero;
                        conn.Open();

                        cmd.ExecuteNonQuery();

                        conn.Close();
                    }
                }
            }
        }


    }
}
