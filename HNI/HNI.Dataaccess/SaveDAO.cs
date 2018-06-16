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
   public class SaveDAO
    {
        public void Salvar(int C, int Q, int P , int U)
        {
            {
                using (SqlConnection conn =
                    new SqlConnection(@"Initial Catalog=HNI;
                        Data Source=localhost;
                        Integrated Security=SSPI;"))
                {
                    string strSQL = @"INSERT INTO Momento (Cena,Questao,Usuario,Personagem)
                    VALUES (@Cena,@Questao,@Usuario,@Personagem);
                            "; 

                    using (SqlCommand cmd = new SqlCommand(strSQL))
                    {
                        cmd.Connection = conn;

                        cmd.Parameters.Add("@Cena", SqlDbType.VarChar).Value = C;
                        cmd.Parameters.Add("@Questao", SqlDbType.VarChar).Value = Q;
                        cmd.Parameters.Add("@Personagem", SqlDbType.VarChar).Value = P;
                        cmd.Parameters.Add("@Usuario", SqlDbType.VarChar).Value = U;

                        conn.Open();

                       cmd.ExecuteNonQuery();

                        conn.Close();
                    }
                }
            }
        }


    }
}
