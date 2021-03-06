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
    public class UsuarioDAO
    {
        public void Inserir(Usuario obj)
        {
            {
                using (SqlConnection conn =
                    new SqlConnection(@"Initial Catalog=HNI;
                        Data Source=localhost;
                        Integrated Security=SSPI;"))
                {
                    string strSQL = @"INSERT INTO Usuario (Nome,Nick,Email,Senha,DataNasc,Genero )
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
        public Usuario Buscar(int i)
        {


            using (SqlConnection conn = new SqlConnection(@"Initial Catalog=HNI;Data Source = localhost; Integrated Security=SSPI"))
            {
                string strSQL = @"SELECT * FROM Usuario where Id = '" + i + "'";

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
                        var u = new Usuario()
                        {
                            Id = Convert.ToInt32(row["Id"]),
                            Nome = row["Nome"].ToString(),
                            Email = row["EMAIL"].ToString(),
                            Senha = row["SENHA"].ToString(),
                            Nick = row["Nick"].ToString(),
                            DataNasc = row["DataNasc"].ToString(),
                            Genero = row["Genero"].ToString()
                        };
                        return u;

                    }
                }
            }
            Usuario ca = new Usuario();
            return ca;


        }
        public Usuario Login(Usuario u)
        {
            using (SqlConnection conn = new SqlConnection(@"Initial Catalog=HNI; Data Source = localhost; Integrated Security=SSPI"))
            {
                string strSQL = @"SELECT * FROM Usuario WHERE Email = '" + u.Email + "' AND Senha= '" + u.Senha + "'";

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
                        var usuario = new Usuario()
                        {
                            Id = Convert.ToInt32(row["ID"]),
                            Email = row["EMAIL"].ToString(),
                            Senha = row["SENHA"].ToString()

                        };
                        usuario.Termo = true;
                        return usuario;
                    }
                }
            }
            Usuario usuarie = new Usuario();
            usuarie.Termo = false;
            return usuarie;
        }
    }
    }

