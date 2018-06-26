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
    public class LojaDAO
    {
        public Item Buscar_Item_Vendedor(int Id)
        {


            using (SqlConnection conn = new SqlConnection(@"Initial Catalog=HNI;Data Source = localhost; Integrated Security=SSPI"))
            {
                string strSQL = @"SELECT * FROM Item where Id = '" + Id + "';";

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
                        var I = new Item()
                        {
                            Id = Convert.ToInt32(row["Id"]),
                            Imagem = row["Imagem"].ToString(),
                            Nome = row["Nome"].ToString(),
                            Valor = Convert.ToInt32(row["Valor"]),

                        };
                        return I;

                    }
                }
            }
            Item It = new Item();
            return It;


        }

        public void Comprar(int Ouro,int Id)
        {


            using (SqlConnection conn = new SqlConnection(@"Initial Catalog=HNI;Data Source = localhost; Integrated Security=SSPI"))
            {
                string strSQL = @"UPDATE Personagem SET Ouro = '"+ Ouro + "' WHERE Id= '"+Id+"' ;";

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

        public void Pegar(int item , int Id,int qtd)
        {


            using (SqlConnection conn = new SqlConnection(@"Initial Catalog=HNI;Data Source = localhost; Integrated Security=SSPI"))
            {
                string strSQL = @"INSERT INTO ItemxPerson (Item_Id,Personagem_Id,Equipado,Qtd)
                                 VALUES ( '"+item+ "' , '" + Id + "' ," + 'N' + ", '"+qtd+"');";

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

        public Item Buscar_Item(int Id)
        {


            using (SqlConnection conn = new SqlConnection(@"Initial Catalog=HNI;Data Source = localhost; Integrated Security=SSPI"))
            {
                string strSQL = @"SELECT * FROM Item where Id = '" + Id + "';";

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
                        var I = new Item()
                        {
                            Id = Convert.ToInt32(row["Id"]),
                            Imagem = row["Imagem"].ToString(),
                            Nome = row["Nome"].ToString(),
                            Valor = Convert.ToInt32(row["Valor"]),

                        };
                        return I;

                    }
                }
            }
            Item It = new Item();
            return It;


        }

        public int Verificar(int item, int Id)
        {


            using (SqlConnection conn = new SqlConnection(@"Initial Catalog=HNI;Data Source = localhost; Integrated Security=SSPI"))
            {
                string strSQL = @"SELECT Qtd FROM ItemxPerson where Item_Id = '" + item + "' and Personagem_Id = '" + Id + "';";

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
                        int I = Convert.ToInt32(row["Qtd"]);                        
                        return I;

                    }
                }
            }

            return 0;

        }



    }
}
