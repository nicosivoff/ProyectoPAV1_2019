using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrabajoPractico.Entities;
using System.Data;

namespace TrabajoPractico.DataAccessLayer
{
    class PerfilDao
    {
        DBHelper oBD = new DBHelper();

        public IList<Perfil> GetPerfiles(string condiciones)
        {
            List<Perfil> listadoPerfiles = new List<Perfil>();

            String strSql = "SELECT idPerfil,nombre FROM Perfil WHERE borrado=0";

            strSql += condiciones;
            var resultadoConsulta = (DataRowCollection)oBD.consultar(strSql).Rows;

            foreach (DataRow row in resultadoConsulta)
            {
                listadoPerfiles.Add(MappingPerfil(row));
            }

            return listadoPerfiles;
        }
        public bool crear(Perfil oPerfil)
        {
            string str_sql = "INSERT INTO Perfil (nombre, borrado)" +
                            " VALUES (" + "'" + oPerfil.Nombre + "'" + "," + ",0)";
            oBD.consultar(str_sql);
            return true;
        }

        public bool actualizar(Perfil oPerfil)
        {
            string str_sql = "UPDATE Perfil " + "SET nombre=" + "'" + oPerfil.Nombre + "'" +
                             " WHERE nombre=" + oPerfil.Nombre;

            oBD.consultar(str_sql);
            return true;
        }



        private Perfil MappingPerfil(DataRow row)
        {
            Perfil oPerfil = new Perfil();
            oPerfil.IdPerfil = Convert.ToInt32(row["idPerfil"].ToString());
            oPerfil.Nombre = row["nombre"].ToString();
      
            return oPerfil;
        }

        public IList<Perfil> GetAll()
    {
        List<Perfil> listadoPerfil = new List<Perfil>();

        String strSql = string.Concat("SELECT idPerfil,nombre FROM Perfil WHERE borrado=0");

        var resultadoConsulta = oBD.consultar(strSql);

        foreach (DataRow row in resultadoConsulta.Rows)
        {
            listadoPerfil.Add(MappingPerfil(row));
        }

        return listadoPerfil;
    }

        public IList<Perfil> GetConFiltros(string condiciones)
    {
        List<Perfil> listadoPerfil = new List<Perfil>();

        String strSql = string.Concat("SELECT idPerfil,nombre FROM Perfil WHERE borrado=0");

        strSql += condiciones;
        var resultadoConsulta = oBD.consultar(strSql);

        foreach (DataRow row in resultadoConsulta.Rows)
        {
            listadoPerfil.Add(MappingPerfil(row));
        }

        return listadoPerfil;
    }
        internal bool Create(Perfil oPerfil)
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

        string str_sql = "INSERT INTO Perfil (nombre, borrado) VALUES("+"'"+oPerfil.Nombre+"',0)";
        oBD.actualizar(str_sql);
        
        return true;
    }
        internal bool Update(Perfil oPerfil)
    {
        string str_sql = "UPDATE Perfil " +
                         "SET nombre=" + "'" + oPerfil.Nombre + "'" + " WHERE idPerfil=" + "'" + oPerfil.IdPerfil + "'";
        oBD.actualizar(str_sql);
        return true;
    }

        internal bool Delete(Perfil oPerfil)
    {
        string str_sql = "UPDATE Perfil " +
                         "SET borrado=1" +
                         " WHERE nombre=" + "'" + oPerfil.Nombre + "'";
        oBD.actualizar(str_sql);
        return true;
    }
        public bool GetPerfilSinParametros(string nombre)
    {
        //Construimos la consulta sql para buscar el usuario en la base de datos.
        String strSql = string.Concat(" SELECT idPerfil,nombre FROM Perfil WHERE borrado =0 ",
                                      "AND nombre= '", nombre , "'" );


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
