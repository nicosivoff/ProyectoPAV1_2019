﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.OleDb;

namespace TrabajoPractico
{
    class Datos
    {
        private OleDbConnection conexion = new OleDbConnection();
        private OleDbCommand comando = new OleDbCommand();
        private string cadenaConexion = @"Provider=SQLNCLI11;Data Source=(localdb)\Servidor;User ID=lucas;Initial Catalog=Canario;password=39622720a";
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
    }
}
