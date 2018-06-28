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
    public class BatalhaDAO
    {
        public AtkE Buscar_Id_Atke_Personagem(int i , int N)
        { 


            using (SqlConnection conn = new SqlConnection(@"Initial Catalog=HNI;Data Source = localhost; Integrated Security=SSPI"))
            {
                string strSQL = @"SELECT * FROM AtkexPerson where Personagem_Id = '" + i + "' and Identi ='"+N+"'";

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
                        var A = new AtkE()
                        {
                            Id = Convert.ToInt32(row["AtkE_Id"]),
                        };
                        A.Nome = "E";
                        return A;

                    }
                }
            }
            AtkE E = new AtkE();
            E.Nome = "N";
            return E;


        }
        public AtkE Buscar_Id_Atke_Criatura(int i, int N)
        {


            using (SqlConnection conn = new SqlConnection(@"Initial Catalog=HNI;Data Source = localhost; Integrated Security=SSPI"))
            {
                string strSQL = @"SELECT * FROM AtkexCriat where Criat_Id = '" + i + "' and Identi ='" + N + "'";

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
                        var A = new AtkE()
                        {
                            Id = Convert.ToInt32(row["AtkE_Id"]),
                        };
                        A.Nome = "E";
                        return A;

                    }
                }
            }
            AtkE E = new AtkE();
            E.Nome = "N";
            return E;


        }

    }
}
