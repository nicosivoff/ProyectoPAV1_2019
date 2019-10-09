using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrabajoPractico.Entities;
using System.Data;

namespace TrabajoPractico.DataAccessLayer
{
    class EmpleadoDao
    {
        DBHelper oBD = new DBHelper();

        public IList<Empleado> GetEmpleados(string condiciones)
        {
            List<Empleado> listadoEmpleados = new List<Empleado>();

            String strSql = "SELECT legajo,nombre,apellido FROM Empleado WHERE borrado=0";

            strSql += condiciones;
            var resultadoConsulta = (DataRowCollection)oBD.consultar(strSql).Rows;

            foreach (DataRow row in resultadoConsulta)
            {
                listadoEmpleados.Add(MappingEmpleado(row));
            }

            return listadoEmpleados;
        }
        public bool crear(Empleado oEmpleado)
        {
            string str_sql = "INSERT INTO Empleado (legajo,nombre,apellido,borrado)" +
                            " VALUES (" + "'" + oEmpleado.Legajo + "'" + "," +
                            "'" + oEmpleado.Nombre + "'" + "," +
                            "'" + oEmpleado.Apellido + "'" + "," + ",0)";
            oBD.consultar(str_sql);
            return true;
        }

        public bool actualizar(Empleado oEmpleado)
        {
            string str_sql = "UPDATE Empleado SET legajo=" + "'" + oEmpleado.Legajo + "'" +
                              ",nombre=" + "'" + oEmpleado.Nombre + "'" +
                              ",apellido=" + "'" + oEmpleado.Apellido + "'" +
                             " WHERE legajo=" + oEmpleado.Legajo;

            oBD.consultar(str_sql);
            return true;
        }



        private Empleado MappingEmpleado(DataRow row)
        {
            Empleado oEmpleado = new Empleado();
            oEmpleado.Legajo = Convert.ToInt32(row["legajo"].ToString());
            oEmpleado.Nombre = row["nombre"].ToString();
            oEmpleado.Apellido = row["apellido"].ToString();
      
            return oEmpleado;
        }

        public IList<Empleado> GetAll()
    {
        List<Empleado> listadoEmpleado = new List<Empleado>();

        String strSql = string.Concat("SELECT legajo,nombre,apellido FROM Empleado WHERE borrado = 0 ");

        var resultadoConsulta = oBD.consultar(strSql);

        foreach (DataRow row in resultadoConsulta.Rows)
        {
            listadoEmpleado.Add(MappingEmpleado(row));
        }

        return listadoEmpleado;
    }

        public IList<Empleado> GetConFiltros(string condiciones)
    {
        List<Empleado> listadoEmpleado = new List<Empleado>();

        String strSql = string.Concat("SELECT legajo, nombre, apellido FROM Empleado WHERE borrado=0");

        strSql += condiciones;
        var resultadoConsulta = oBD.consultar(strSql);

        foreach (DataRow row in resultadoConsulta.Rows)
        {
            listadoEmpleado.Add(MappingEmpleado(row));
        }

        return listadoEmpleado;
    }
        internal bool Create(Empleado oEmpleado)
    {
        //CON PARAMETROS
        //string str_sql = "     INSERT INTO Usuarios (usuario, password, email, id_perfil, estado, borrado)" +
        //                 "     VALUES (@usuario, @password, @email, @id_perfil, 'S', 0)";

        // var parametros = new Dictionary<string, object>();
        //parametros.Add("usuario", oUsuario.NombreUsuario);
        //parametros.Add("password", oUsuario.Password);
        //parametros.Add("email", oUsuario.Email);
        //parametros.Add("id_perfil", oUsuario.Perfil.IdPerfil);

        // Si una fila es afectada por la inserción retorna TRUE. Caso contrario FALSE
        //con parametros
        //return (DBHelper.GetDBHelper().EjecutarSQLConParametros(str_sql, parametros) == 1);

        //SIN PARAMETROS

        string str_sql = "INSERT INTO Empleado (legajo,nombre,apellido,borrado) VALUES(" + "'" + oEmpleado.Legajo + "',"+
                         "'" + oEmpleado.Nombre + "',"+
                         "'" + oEmpleado.Apellido + "',0)";
        oBD.actualizar(str_sql);
        
        return true;
    }
        internal bool Update(Empleado oEmpleado)
    {
        string str_sql = "UPDATE Empleado SET legajo=" + oEmpleado.Legajo +
                              ",nombre=" + "'" + oEmpleado.Nombre + "'" +
                              ",apellido=" + "'" + oEmpleado.Apellido + "'" +
                             " WHERE legajo=" + oEmpleado.Legajo;
        oBD.actualizar(str_sql);
        return true;
    }

        internal bool Delete(Empleado oEmpleado)
    {
        string str_sql = "UPDATE Empleado " +
                         "SET borrado=1" +
                         " WHERE legajo=" + "'" + oEmpleado.Legajo + "'";
        oBD.actualizar(str_sql);
        return true;
    }
        public bool GetEmpleadoSinParametros(int legajo)
    {
        //Construimos la consulta sql para buscar el usuario en la base de datos.
        String strSql = string.Concat(" SELECT legajo,nombre,apellido FROM Empleado WHERE borrado=0 ",
                                      "AND legajo=", legajo);


        //Usando el método GetDBHelper obtenemos la instancia unica de DBHelper (Patrón Singleton) y ejecutamos el método ConsultaSQL()
        var resultado = oBD.consultar(strSql);

        // Validamos que el resultado tenga al menos una fila.
        if (resultado.Rows.Count > 0)
        {
            return true;
        }

        return false;
    }

    }
}
