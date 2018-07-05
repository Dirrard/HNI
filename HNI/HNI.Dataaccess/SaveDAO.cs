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
        public void Salvar(int C, int Q, int P, int U)
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
        public Momento Carregar(int Id)
        {


            using (SqlConnection conn = new SqlConnection(@"Initial Catalog=HNI;Data Source = localhost; Integrated Security=SSPI"))
            {
                string strSQL = @"SELECT * FROM Momento where Personagem= '" + Id + "'";

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
                        var A = new Momento()
                        {
                            Questao = new Questao()
                            {
                                Id = Convert.ToInt32(row["Questao"]),
                            },
                            Lugar = new Lugar()
                            {
                                Id = Convert.ToInt32(row["Lugar"]),
                            },
                            Cena = new Cena()
                            {
                                Id = Convert.ToInt32(row["Cena"]),
                            }

                        };
                        return A;

                    }
                }
            }
            Momento E = new Momento();
            E.Cena = new Cena()
            {
                Id = 0,
            };
            E.Questao = new Questao()
            {
                Id = 0,
            };
            E.Lugar = new Lugar()
            {
                Id = 0,
            };

            return E;


        }
        public void Deletar(int Id)
        {


            using (SqlConnection conn = new SqlConnection(@"Initial Catalog=HNI;Data Source = localhost; Integrated Security=SSPI"))
            {
                string strSQL = @"Delete FROM Momento where Id = '" + Id + "'";

                using (SqlCommand cmd = new SqlCommand(strSQL))
                {
                    conn.Open();
                    cmd.Connection = conn;
                    cmd.CommandText = strSQL;
                    var dataReader = cmd.ExecuteReader();
                    var dt = new DataTable();
                    dt.Load(dataReader);
                    conn.Close();

                }
            }
        }


    }
}
