using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrabajoPractico.Entities;
using System.Data;

namespace TrabajoPractico.DataAccessLayer
{
    class UsuarioDao
    {
        DBHelper oBD = new DBHelper();

        public IList<Usuario> GetUsuarios(string condiciones)
        {
            List<Usuario> listadoUsuarios = new List<Usuario>();

            String strSql = "SELECT u.idUsuario, u.contraseña. u.perfil, p.nombre, u.email"
                            + " FROM Usuario u, Perfil p"
                            + " WHERE u.perfil=p.idPerfil"
                            + " AND u.borrado = 0";

            strSql += condiciones;
            var resultadoConsulta = (DataRowCollection)oBD.consultar(strSql).Rows;

            foreach (DataRow row in resultadoConsulta)
            {
                listadoUsuarios.Add(MappingUsuario(row));
            }

            return listadoUsuarios;
        }
        public bool crear(Usuario oUsuario)
        {
            string str_sql = "INSERT INTO Usuario (idUsuario, contraseña, idPerfil, email, borrado)" +
                            " VALUES (" +
                            "'" + oUsuario.IdUsuario + "'" + "," +
                            "'" + oUsuario.Contraseña + "'" + "," +
                            "'" + oUsuario.Perfil.IdPerfil + "'" + "," +
                            "'" + oUsuario.Email + "'" + "," + ",0)";
            oBD.consultar(str_sql);
            return true;
        }

        public bool actualizar(Usuario oUsuario)
        {
            string str_sql = "UPDATE Usuario " +
                             "SET idUsuario=" + "'" + oUsuario.IdUsuario + "'" + "," +
                             " contraseña=" + "'" + oUsuario.Contraseña + "'" + "," +
                             " email=" + "'" + oUsuario.Email + "'" + "," +
                             " perfil=" + oUsuario.Perfil.IdPerfil +
                             " WHERE idUsuario=" + oUsuario.IdUsuario;

            oBD.consultar(str_sql);
            return true;
        }



        private Usuario MappingUsuario(DataRow row)
        {
            Usuario oUsuario = new Usuario();
            oUsuario.IdUsuario = row["idUsuario"].ToString();
            oUsuario.Email = row["email"].ToString();
            oUsuario.Contraseña = row["contraseña"].ToString();
            oUsuario.Perfil = new Perfil();
            oUsuario.Perfil.IdPerfil = Convert.ToInt32(row["perfil"].ToString());
            oUsuario.Perfil.Nombre = row["nombre"].ToString();
      
            return oUsuario;
        }

    public IList<Usuario> GetAll()
    {
        List<Usuario> listadoUsuarios = new List<Usuario>();

        String strSql = string.Concat(" SELECT idUsuario, ",
                                      "        email, ",
                                      "        contraseña, ",
                                      "        perfil, ",
                                      "        p.nombre",
                                      " FROM Usuario u",
                                      " INNER JOIN Perfil p ON u.perfil= p.idPerfil",
                                      " WHERE u.borrado=0");

        var resultadoConsulta = oBD.consultar(strSql);

        foreach (DataRow row in resultadoConsulta.Rows)
        {
            listadoUsuarios.Add(MappingUsuario(row));
        }

        return listadoUsuarios;
    }

    public IList<Usuario> GetConFiltros(string condiciones)
    {
        List<Usuario> listadoUsuarios = new List<Usuario>();

        String strSql = string.Concat(" SELECT idUsuario, ",
                                      "        email, ",
                                      "        contraseña, ",
                                      "        perfil, ",
                                      "        p.nombre",
                                      " FROM Usuario u",
                                      " INNER JOIN Perfil p ON u.perfil= p.idPerfil",
                                      " WHERE u.borrado=0");

        strSql += condiciones;
        var resultadoConsulta = oBD.consultar(strSql);

        foreach (DataRow row in resultadoConsulta.Rows)
        {
            listadoUsuarios.Add(MappingUsuario(row));
        }

        return listadoUsuarios;
    }
    internal bool Create(Usuario oUsuario)
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

        string str_sql = "INSERT INTO Usuario (idUsuario, contraseña, email, perfil, borrado)" +
                        " VALUES (" +
                        "'" + oUsuario.IdUsuario + "'" + "," +
                        "'" + oUsuario.Contraseña + "'" + "," +
                        "'" + oUsuario.Email + "'" + "," +
                        oUsuario.Perfil.IdPerfil + ",0)";
        oBD.actualizar(str_sql);
        
        return true;
    }
    internal bool Update(Usuario oUsuario)
    {
        string str_sql = "UPDATE Usuario " +
                         "SET contraseña=" + "'" + oUsuario.Contraseña + "'" + "," +
                         " email=" + "'" + oUsuario.Email + "'" + "," +
                         " perfil=" + oUsuario.Perfil.IdPerfil +
                         " WHERE idUsuario=" + "'" + oUsuario.IdUsuario + "'";
        oBD.actualizar(str_sql);
        return true;
    }

    internal bool Delete(Usuario oUsuario)
    {
        string str_sql = "UPDATE Usuario " +
                         "SET borrado=1" +
                         " WHERE idUsuario=" + "'" + oUsuario.IdUsuario + "'";
        oBD.actualizar(str_sql);
        return true;
    }
    public bool GetUserSinParametros(string idUsuario)
    {
        //Construimos la consulta sql para buscar el usuario en la base de datos.
        String strSql = string.Concat(" SELECT email,",
                                      " contraseña,",
                                      " perfil,",
                                      " p.nombre",
                                      " FROM Usuario u",
                                      " INNER JOIN Perfil p ON u.perfil= p.idPerfil ",
                                      " WHERE u.borrado =0 ",
                                      "AND u.idUsuario= '", idUsuario , "'" );


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