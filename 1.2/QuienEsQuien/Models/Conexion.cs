using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.IO;
using QuienesQuien.Models;

namespace QuienesQuien.Models
{
    public class Conexion
    {
        private static string SC = "Server=10.128.8.16;Database=QEQB07;User Id=QEQB07;Password=QEQB07;";

        public SqlConnection Conectar()
        {
            SqlConnection Conexion = new SqlConnection(SC);
            Conexion.Open();
            return Conexion;
        }

        public void Desconectar(SqlConnection Conn)
        {
            Conn.Close();
        }

        public Session Login(string user, string pass)
        {
            Session x = new Session();

            SqlConnection Conexion = Conectar();
            SqlCommand Comando = Conexion.CreateCommand();

            Comando.CommandText = "sp_Login";
            Comando.CommandType = System.Data.CommandType.StoredProcedure;
            Comando.Parameters.AddWithValue("@pUser", user);
            Comando.Parameters.AddWithValue("@pPass", pass);
            SqlDataReader DataReader = Comando.ExecuteReader();

            while (DataReader.Read())
            {
                int Existe = Convert.ToInt32(DataReader["Existe"]);
                bool Admin = Convert.ToBoolean(DataReader["Admin"]);

                if (Existe == 1)
                {
                    x.NombreUser = user;
                    x.Admin = Admin;
                }
                else if (Existe == 0)
                {
                    x.NombreUser = "-1";
                    x.Admin = false;
                }
            }

            return x;
        }

        public int Register(string user, string pass)
        {
            SqlConnection Conexion = Conectar();
            SqlCommand Comando = Conexion.CreateCommand();

            Comando.CommandText = "sp_Registro";
            Comando.CommandType = System.Data.CommandType.StoredProcedure;
            Comando.Parameters.AddWithValue("@pNombre", user);
            Comando.Parameters.AddWithValue("@pContraseña", pass);
            int x = Comando.ExecuteNonQuery();
            return x;
        }
    }
}