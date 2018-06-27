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
   public class AtkEDAO
    {

        public AtkE Buscar(int I)
        {


            using (SqlConnection conn = new SqlConnection(@"Initial Catalog=HNI;Data Source = localhost; Integrated Security=SSPI"))
            {
                string strSQL = @"SELECT * FROM AtkE where Id = '" + I + "'";

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
                            Id = Convert.ToInt32(row["Id"]),
                            Nome = row["Nome"].ToString(),
                            Imagem = row["Imagem"].ToString(),
                            Mana = Convert.ToInt32(row["Mana"]),
                            Hp = Convert.ToInt32(row["Hp"]),
                            AtkF = Convert.ToInt32(row["AtkF"]),
                            AtkM = Convert.ToInt32(row["AtkM"]),
                            Def = Convert.ToInt32(row["Def"]),
                            
                        };
                        return A;

                    }
                }
            }
            AtkE E= new AtkE();
            E.Imagem = "AtkE_Vazio";
            return E;


        }
    }
}
