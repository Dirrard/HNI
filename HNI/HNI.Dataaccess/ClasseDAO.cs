﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HNI.Models;
using System.Data.SqlClient;
using System.Data;

namespace HNI.Dataaccess
{
    public class ClasseDAO
    {
        public Classe Buscar(Personagem p)
        {
           

            using (SqlConnection conn = new SqlConnection(@"Initial Catalog=HNI;Data Source = localhost; Integrated Security=SSPI"))
            {
                string strSQL = @"SELECT * FROM Classe where Id = '" + p.Classe.Id + "'";

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
                        var c = new Classe()
                        {
                            Id = Convert.ToInt32(row["Id"]),
                            Nome = row["Nome"].ToString(),
                            Imagem = row["Imagem"].ToString(),
                            Desc = row["Desc"].ToString(),
                            Mana = Convert.ToInt32(row["Mana"]),
                            Hp = Convert.ToInt32(row["Hp"]),
                            AtkF = Convert.ToInt32(row["AtkF"]),
                            AtkM = Convert.ToInt32(row["AtkM"]),
                            Def = Convert.ToInt32(row["Def"]),
                            Nivel = Convert.ToInt32(row["Nivel"]),
                        };
                        return c;

                    }
                }
            }
            Classe ca = new Classe();
            return ca;


        }
    }
}