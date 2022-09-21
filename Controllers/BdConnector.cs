using ApiBeisebol.Models;
using ApiTimeBeisebol.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ApiTimeBeisebol.Controllers
{
    public class BdConnector : Controller
    {
        // GET: BdConnector
        public class BdConector
        {
            MySqlConnection conn2;

            //servidor de banco de dados
            static string host = "localhost";
            //nome do banco de dados
            static string database = "dbBeisebol";
            //usuário de conexão do banco de dados
            static string userDB = "root";
            //senha de conexão do banco de dados
            static string password = "12345678";

            //string de conexão ao BD
            public static string strProvider = "server=" + host +
                                                ";Database=" + database +
                                                ";User ID=" + userDB +
                                                ";Password=" + password;

            public static Boolean novo = false;
            public String sql;

            public BdConector()
            {
                //cria conexão
                conn2 = new MySqlConnection(strProvider);
                //Abre uma conexão de banco de dados 
                conn2.Open();

            }

            //------para cada ação criar um metodo no banco-------

            public List<Time> BuscaTodos()
            {
                //Fornece uma maneira de ler os dados do banco
                MySqlDataReader reader;
                sql = "SELECT * FROM tbTime;";
                //efetua comando com a conexao
                MySqlCommand cmd = new MySqlCommand(sql, conn2);
                reader = cmd.ExecuteReader();
                //lista os dados do banco
                List<Time> tim = new List<Time>();
                //verfifica se o data reader tem 1 ou mais resultado
                if (reader.HasRows)
                {
                    // repete enquanto possuir registros a serem lidos
                    while (reader.Read())
                    {
                        tim.Add(new Time(int.Parse(reader["id_time"].ToString()), reader["NomeTime"].ToString(), reader["CidadeTime"].ToString()));
                    }
                }
                return tim;

            }


            //insert
            public void adicionaTime(Time cantada)
            {
                MySqlCommand cmd = new MySqlCommand("INSERT INTO tbTime (NomeTime,CidadeTime) VALUES (@nomeTime , @cidadeTime)", conn2);
                cmd.Parameters.AddWithValue("@nomeTime", cantada.nomeTime);
                cmd.Parameters.AddWithValue("@cidadeTime", cantada.cidadeTime);
                cmd.ExecuteNonQuery();
            }

            //Update
            public void UpdateTime(Time cantada)
            {
                MySqlCommand cmd = new MySqlCommand("update tbCantada set NomeTime=@nomeTime, CidadeTime=@cidadeTime where id_time=@IdTime", conn2);
                cmd.Parameters.AddWithValue("@nomeTime", cantada.nomeTime);
                cmd.Parameters.AddWithValue("@cidadeTime", cantada.cidadeTime);
                cmd.Parameters.AddWithValue("@IdTime", cantada.IdTime);
                cmd.ExecuteNonQuery();
            }

            //delete
            public void RemoveTime(int idTime)
            {
                MySqlCommand cmd = new MySqlCommand("delete from tbTime where  id_time=@IdTime", conn2);
                cmd.Parameters.AddWithValue("@IdTime", idTime);
                cmd.ExecuteNonQuery();
            }

            public void Fechar()
            {
                conn2.Close();
            }
        }
    }
}