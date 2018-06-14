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
    public class EscolhaDAO
    {
        public Questao Buscar_Questao(int Id)
        {


            using (SqlConnection conn = new SqlConnection(@"Initial Catalog=HNI;Data Source = localhost; Integrated Security=SSPI"))
            {
                string strSQL = @"SELECT * FROM Questao where Id = '" + Id +"'";

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
                        var Q = new Questao()
                        {
                            Id = Convert.ToInt32(row["Id"]),
                            Cena = new Cena
                            {
                            Id = Convert.ToInt32(row["Cena"])
                            },
                            Descricao= row["Descr"].ToString(),
                            Personagem = new Personagem
                            {
                                Id= Convert.ToInt32(row["Personagem"]),
                            }
                        };
                        return Q;

                    }
                }
            }
           Questao Qu = new Questao();
            return Qu;


        }
        public Resposta Buscar_Respota(int Id,int Identi)
        {


            using (SqlConnection conn = new SqlConnection(@"Initial Catalog=HNI;Data Source = localhost; Integrated Security=SSPI"))
            {
                string strSQL = @"SELECT * FROM Resposta where Questao = '" + Id +"' and Identi = '"+Identi+"'";

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
                        var R = new Resposta()
                        {
                            Id = Convert.ToInt32(row["Id"]),
                            Questao = new Questao
                            {
                                Id = Convert.ToInt32(row["Questao"])
                            },
                            Descricao = row["Descr"].ToString(),
                             Identidade = Convert.ToInt32(row["Identi"]),
                            
                        };
                        R.Existe = true;
                        return R;

                    }
                }
            }
            Resposta Re = new Resposta();
            Re.Existe = false;
            return Re;


        }
        public Lugar Buscar_Lugar(int Id)
        {


            using (SqlConnection conn = new SqlConnection(@"Initial Catalog=HNI;Data Source = localhost; Integrated Security=SSPI"))
            {
                string strSQL = @"SELECT * FROM Lugar where Questao = '" + Id + "'";

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
                        var L = new Lugar()
                        {
                            Id = Convert.ToInt32(row["Id"]),
                            Questao = new Questao
                            {
                                Id = Convert.ToInt32(row["Questao"])
                            },
                            Minimo = Convert.ToInt32(row["CriaturaNumeroInicial"]),
                            Maximo = Convert.ToInt32(row["CriaturaNumeroFinal"]),
                            Imagem = row["Imagem"].ToString()
                        };
                        return L;

                    }
                }
            }
             Lugar Lu = new Lugar();
            return Lu;


        }
    }
}
