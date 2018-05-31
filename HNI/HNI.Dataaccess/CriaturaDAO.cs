using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Data.Sql;
using HNI.Models;


namespace HNI.Dataaccess
{
    public class CriaturaDAO
    {
        public Criatura Buscar(int c)
        {


            using (SqlConnection conn = new SqlConnection(@"Initial Catalog=HNI;Data Source = localhost; Integrated Security=SSPI"))
            {
                string strSQL = @"SELECT * FROM Criatura where Id = '" + c + "'";

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
                        var cri = new Criatura()
                        {
                            Id = Convert.ToInt32(row["Id"]),
                            Nome = row["Nome"].ToString(),
                            Imagem = row["Imagem"].ToString(),
                            Descricao = row["Desc"].ToString(),
                            Mana = Convert.ToInt32(row["Mana"]),
                            Hp = Convert.ToInt32(row["Hp"]),
                            AtkF = Convert.ToInt32(row["AtkF"]),
                            AtkM = Convert.ToInt32(row["AtkM"]),
                            Def = Convert.ToInt32(row["Def"]),
                            Exp = Convert.ToInt32(row["Exp"]),
                            Ouro = Convert.ToInt32(row["Ouro"])
                            
                        };
                        return cri;

                    }
                }
            }
            Criatura ca = new Criatura();
            return ca;


        }
    }
}
