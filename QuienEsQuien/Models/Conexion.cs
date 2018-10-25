using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.IO;
using QuienEsQuien.Models;

namespace QuienesQuien.Models
{
    public class Conexion
    {
        private static string SC = "Server=10.128.8.16;Database=QEQB07;User Id=QEQB07;Password=QEQB07;";
        //private static string SC = "Server=LAPTOP-BT997U35\\SQLEXPRESS;Database=QEQB07;User Id=ORT;Password=ort;";

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

        public Login Login(string user, string pass)
        {
            Login x = new Login();

            SqlConnection Conexion = Conectar();
            SqlCommand Comando = Conexion.CreateCommand();

            Comando.CommandText = "sp_Login";
            Comando.CommandType = System.Data.CommandType.StoredProcedure;
            Comando.Parameters.AddWithValue("@pUser", user);
            Comando.Parameters.AddWithValue("@pPass", pass);
            SqlDataReader DataReader = Comando.ExecuteReader();

            if (DataReader.Read())
            {
                bool Admin = Convert.ToBoolean(DataReader["Admin"]);
                string Contraseñat = DataReader["Contraseña"].ToString();

                x.Nombre = user;
                x.Admin = Admin;
                x.Contraseña = Contraseñat;
            }
            else
            {
                x.Nombre = "-1";
                x.Admin = false;
                x.Contraseña = "-1";
            }

            Conexion.Close();

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

            Conexion.Close();

            return x;
        }
        ///ABM
        public void InsertarCategoria(Categorias C)
        {

            SqlConnection Conexion = Conectar();
            SqlCommand consulta = Conexion.CreateCommand();
            consulta.CommandText = "sp_AltaCategoria";
            consulta.CommandType = System.Data.CommandType.StoredProcedure;
            consulta.Parameters.AddWithValue("@pNombre", C.Nombre);
            consulta.ExecuteNonQuery();
            Desconectar(Conexion);

        }
        public List<Categorias> ListarCategorias()
        {
            List<Categorias> Categoria = new List<Categorias>();
            SqlConnection conexion = Conectar();
            SqlCommand consulta = conexion.CreateCommand();
            consulta.CommandText = "sp_ListarCategorias";
            consulta.CommandType = System.Data.CommandType.StoredProcedure;
            SqlDataReader dataReader = consulta.ExecuteReader();
            while (dataReader.Read())
            {
                int IdCategoria = Convert.ToInt32(dataReader["IdCategoria"]);
                string NombreCat = (dataReader["Nombre"].ToString());

                Categorias C = new Categorias(IdCategoria, NombreCat);
                Categoria.Add(C);
            }
            Desconectar(conexion);
            return Categoria;
        }
        public Categorias ObtenerCategoria(int IdCategoria)
        {
            Categorias UnaCategoria = new Categorias();
            SqlConnection conexion = Conectar();
            SqlCommand consulta = conexion.CreateCommand();
            consulta.CommandText = "sp_SeleccionarCategoria";
            consulta.CommandType = System.Data.CommandType.StoredProcedure;
            consulta.Parameters.AddWithValue("@pID", IdCategoria);
            SqlDataReader dataReader = consulta.ExecuteReader();
            if (dataReader.Read())
            {
                UnaCategoria.IdCategoria = Convert.ToInt32(dataReader["IdCategoria"]);
                UnaCategoria.Nombre = (dataReader["Nombre"].ToString());

            }

            Desconectar(conexion);
            return UnaCategoria;
        }
        public void ModificarCategoria(Categorias C)
        {

            SqlConnection conexion = Conectar();
            SqlCommand consulta = conexion.CreateCommand();
            consulta.CommandText = "sp_ModificacionCategoria";
            consulta.CommandType = System.Data.CommandType.StoredProcedure;
            consulta.Parameters.AddWithValue("@pID", C.IdCategoria);
            consulta.Parameters.AddWithValue("@pNombre", C.Nombre);
            consulta.ExecuteNonQuery();
            Desconectar(conexion);

        }

        public void EliminarTrabajador(int t)
        {


            SqlConnection conexion = Conectar();
            SqlCommand consulta = conexion.CreateCommand();
            consulta.CommandText = "sp_BajaCategoria";
            consulta.CommandType = System.Data.CommandType.StoredProcedure;
            consulta.Parameters.AddWithValue("@pID", t);
            consulta.ExecuteNonQuery();
            Desconectar(conexion);

        }

        public List<Personajes> ListarPersonajes()
        {
            List<Personajes> Personajes = new List<Personajes>();
            SqlConnection conexion = Conectar();
            SqlCommand consulta = conexion.CreateCommand();
            consulta.CommandText = "sp_ListarPersonajes";
            consulta.CommandType = System.Data.CommandType.StoredProcedure;
            SqlDataReader dataReader = consulta.ExecuteReader();
            while (dataReader.Read())
            {
                int IdPersonaje = Convert.ToInt32(dataReader["IdPersonajes"]);
                string NombreCat = (dataReader["Nombre_personaje"].ToString());
                string Imagen = (dataReader["Imagen"].ToString());
                int IdCategotia = Convert.ToInt32(dataReader["IdCategoria"]);

                Personajes C = new Personajes(IdPersonaje, NombreCat, Imagen, IdCategotia);
                Personajes.Add(C);
            }
            Desconectar(conexion);
            return Personajes;
        }
    }
}