using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;

namespace TrabajoPractico.DataAccessLayer
{
    class DBHelper
    {
        enum ResultadoTransaccion
        {
            exito, fracaso
        }

        private OleDbConnection conexion = new OleDbConnection();
        private OleDbCommand comando = new OleDbCommand();
        private static DBHelper instance = new DBHelper();
        private OleDbTransaction transaccion = null;
        private ResultadoTransaccion miEstado = ResultadoTransaccion.exito;

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
        public DataTable consultar(string consultaSQL)
        {
            DataTable tabla = new DataTable();
            this.conectar();
            comando.CommandText = consultaSQL;
            tabla.Load(comando.ExecuteReader());
            this.desconectar();
            return tabla;
        }
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
        public int EjecutarSQLConParametros(string strSql, Dictionary<string, object> parametros = null)
        {

            OleDbTransaction t = null/* TODO Change to default(_) if this is not a reference type */;
            int rtdo = 0;

            // Try Catch Finally
            // Trata de ejecutar el código contenido dentro del bloque Try - Catch
            // Si hay error lo capta a través de una excepción
            // Si no hubo error
            try
            {
                
                // Abre la conexión
                conectar();
                comando.CommandText = strSql;
                //Agregamos a la colección de parámetros del comando los filtros recibidos
                foreach (var item in parametros)
                {
                    comando.Parameters.AddWithValue(item.Key, item.Value);
                }

                // Retorna el resultado de ejecutar el comando
                rtdo = comando.ExecuteNonQuery();
                t.Commit();
            }
            catch (Exception ex)
            {
                if (t != null)
                    t.Rollback();
            }
            finally
            {
                // Cierra la conexión 
                if (conexion.State == ConnectionState.Open)
                    conexion.Close();
                conexion.Dispose();
            }
            return rtdo;
        }
        public DataTable ConsultaSQLConParametros(string sqlStr, Dictionary<string, object> prs)
        {
            DataTable tabla = new DataTable();

            try
            {
                conectar();


                comando.CommandType = CommandType.Text;
                comando.CommandText = sqlStr;

                //Agregamos a la colección de parámetros del comando los filtros recibidos
                foreach (var item in prs)
                {
                    comando.Parameters.AddWithValue(item.Key, item.Value);
                }

                tabla.Load(comando.ExecuteReader());
                return tabla;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                desconectar();
            }
        }
        public int EjecutarSQL(string strSql)
        {   
            
            // Se utiliza para sentencias SQL del tipo “Insert/Update/Delete”
            OleDbTransaction t = null/* TODO Change to default(_) if this is not a reference type */;
            int rtdo = 0;

            // Try Catch Finally
            // Trata de ejecutar el código contenido dentro del bloque Try - Catch
            // Si hay error lo capta a través de una excepción
            // Si no hubo error
            try
            {
                // Establece que conexión usar
                conectar();
                // Abre la conexión
                t = conexion.BeginTransaction();
                comando.Transaction = t;
                comando.CommandType = CommandType.Text;
                // Establece la instrucción a ejecutar
                comando.CommandText = strSql;
                // Retorna el resultado de ejecutar el comando
                rtdo = comando.ExecuteNonQuery();
                t.Commit();
            }
            catch (Exception ex)
            {
                if (t != null)
                    t.Rollback();
            }
            finally
            {
                // Cierra la conexión 
                if (conexion.State == ConnectionState.Open)
                    conexion.Close();
                conexion.Dispose();
            }
            return rtdo;
        }


        public void EjecutarSQLConTransaccion(string strSql)
    {   
        //  Se utiliza para sentencias SQL del tipo Insert, Update, Delete con transaccion.
        try
        {
            comando.CommandType = CommandType.Text;
            comando.CommandText = strSql;
            comando.ExecuteNonQuery();
        }
        catch 
        {
            miEstado = ResultadoTransaccion.fracaso;
        }
    }

        public void conectarConTransaccion()
        {
            miEstado = ResultadoTransaccion.exito;
            conexion.ConnectionString = cadenaConexion;
            conexion.Open();
            transaccion = conexion.BeginTransaction();
            comando.Transaction = transaccion;
            comando.Connection = conexion;
        }

        public void desconectarConTransaccion()
        {
                if (miEstado == ResultadoTransaccion.exito)
                {
                    transaccion.Commit();
                    MessageBox.Show("La trasacción resultó con éxito...");
                }
                else
                {
                    transaccion.Rollback();
                    MessageBox.Show("La trasacción no pudo realizarce...");
                }

            if ((conexion.State == ConnectionState.Open))
            {
                conexion.Close();
            }

            // Dispose() libera los recursos asociados a la conexón
            conexion.Dispose();

        }
    }
    
    
}
