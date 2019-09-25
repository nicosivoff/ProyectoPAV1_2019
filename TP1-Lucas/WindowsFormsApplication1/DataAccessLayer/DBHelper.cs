using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;

namespace TrabajoPractico.DataAccessLayer
{
    class DBHelper
    {
        private OleDbConnection conexion = new OleDbConnection();
        private OleDbCommand comando = new OleDbCommand();
        private string cadenaConexion = @"Provider=SQLNCLI11;Data Source=LAPTOP-TCTA87VI\SQLEXPRESS;Integrated Security=SSPI;Initial Catalog=Canario";
        private void conectar()
        {
            conexion.ConnectionString = cadenaConexion;
            conexion.Open();
            comando.Connection = conexion;
            comando.CommandType = CommandType.Text;
        }
        private void desconectar()
        {
            conexion.Close();
        }

        public DataTable ConsultaSQL(string strSql)
        {
            DataTable tabla = new DataTable();

            try
            {
                this.conectar();
                comando.CommandText = strSql;
                tabla.Load(comando.ExecuteReader());
                return tabla;
            }
            catch (SqlException ex)
            {
                throw (ex);
            }
            finally
            {
                this.desconectar();
            }
        }

        /*public DataTable consultar(string consultaSQL)
        {
            DataTable tabla = new DataTable();
            this.conectar();
            comando.CommandText = consultaSQL;
            tabla.Load(comando.ExecuteReader());
            this.desconectar();
            return tabla;
        }
         */
        public DataTable consultarTabla(string nombreTabla)
        {
            DataTable tabla = new DataTable();
            this.conectar();
            comando.CommandText = "SELECT * FROM " + nombreTabla;
            tabla.Load(comando.ExecuteReader());
            this.desconectar();
            return tabla;
        }
        public void actualizar(string consultaSQL)
        {
            this.conectar();
            comando.CommandText = consultaSQL;
            comando.ExecuteNonQuery();
            this.desconectar();
        }
        public static DBHelper GetDBHelper()
        {
            if (instance == null)
                instance = new DBHelper();
            return instance;
        }
    }
}
