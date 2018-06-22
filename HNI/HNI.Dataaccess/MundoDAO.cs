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
    public class MundoDAO
    {

        public Distancia Buscar_Distancia(int Id, int Id2)
        {


            using (SqlConnection conn = new SqlConnection(@"Initial Catalog=HNI;Data Source = localhost; Integrated Security=SSPI"))
            {
                string strSQL = @"SELECT * FROM Distancia where Lugar1 = '" + Id + "'and Lugar2 = '" + Id2 + "';";

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
                        var D = new Distancia()
                        {


                            Inicial = new Lugar
                            {
                          Id =  Convert.ToInt32(row["Lugar1"])
                            },
                            Final = new Lugar
                            {
                                Id = Convert.ToInt32(row["Lugar2"])
                            },
                            Passos = Convert.ToInt32(row["Passos"]),
                            CrtInicial = Convert.ToInt32(row["CriaturaNumeroInicial"]),
                            CrtFinal = Convert.ToInt32(row["CriaturaNumeroIFinal"]),
                            Id = Convert.ToInt32(row["Id"]),
                        };
                        return D;

                    }
                }
            }
            Distancia DI = new Distancia();
            return DI;


        }

    }
}
