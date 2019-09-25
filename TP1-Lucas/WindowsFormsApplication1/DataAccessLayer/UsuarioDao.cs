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
            oUsuario.IdUsuario = Convert.ToInt32(row["idUsuario"].ToString());
            oUsuario.Perfil = new Perfil();
            oUsuario.Perfil.IdPerfil = Convert.ToInt32(row["idPerfil"].ToString());
            oUsuario.Perfil.Nombre = row["nombre"].ToString();
            oUsuario.Email = row["email"].ToString();

            return oUsuario;
        }
        public IList<Usuario> GetByFiltersConParametros(Dictionary<string, object> parametros)
        {
                        
            List<Usuario> lst = new List<Usuario>();
            String strSql = string.Concat(" SELECT idUsuario, ",
                                              " legajo",
                                              "email",
                                              "contraseña",
                                              "   FROM Usuarios u",
                                              "  INNER JOIN Perfil p ON u.perfil= p.idPerfil",
                                              "WHERE u.borrado = 0");


            if (parametros.ContainsKey("idPerfil"))
            strSql += " AND (u.perfil = @idPerfil) ";


            if (parametros.ContainsKey("usuario"))
            strSql += " AND (u.idUsuario LIKE '%' + @usuario + '%') ";

         var resultado = DBHelper.GetDBHelper().ConsultaSQLConParametros(strSql, parametros);
             
           
            foreach (DataRow row in resultado.Rows)
                lst.Add(ObjectMapping(row));

            return lst;
    }

    private Usuario ObjectMapping(DataRow row)
    {
        Usuario oUsuario = new Usuario
        {
            IdUsuario = Convert.ToInt32(row["idUsuario"].ToString()),
            Email = row["email"].ToString(),
            Contraseña = row.Table.Columns.Contains("contraseña") ? row["contraseña"].ToString() : null,
            Perfil = new Perfil()
            {
                IdPerfil = Convert.ToInt32(row["idPerfil"].ToString()),
                Nombre = row["nombre"].ToString(),
            }
        };
    

        return oUsuario;
    }
    public IList<Usuario> GetByFiltersSinParametros(String condiciones)
        {

            List<Usuario> lst = new List<Usuario>();
            String strSql = string.Concat(" SELECT idUsuario, ",
                                              "        email",
                                              //"        p.idperfil, ",
                                              //"        p.nombre as perfil ",
                                              "   FROM Usuario u",
                                              "  INNER JOIN Perfil p ON u.perfil= p.idperfil ",
                                              "  WHERE u.borrado =0");


           // if (parametros.ContainsKey("idPerfil"))
             //   strSql += " AND (u.id_perfil = @idPerfil) ";


           // if (parametros.ContainsKey("usuario"))
            //    strSql += " AND (u.usuario LIKE '%' + @usuario + '%') ";

            var resultado = DBHelper.GetDBHelper().consultar(strSql);


            foreach (DataRow row in resultado.Rows)
                lst.Add(ObjectMapping(row));

            return lst;
        }
    public IList<Usuario> GetAll()
    {
        List<Usuario> listadoUsuarios = new List<Usuario>();

        String strSql = string.Concat(" SELECT idUsuario, ",
                                      "        email, ",
                                      "        contraseña, ",
                                      "        p.idPerfil, ",
                                      "        p.nombre as perfil",
                                      "   FROM Usuario u",
                                      "  INNER JOIN Perfil p ON u.perfil= p.idPerfil WHERE u.borrado=0 ");

        var resultadoConsulta = DBHelper.GetDBHelper().consultar(strSql);

        foreach (DataRow row in resultadoConsulta.Rows)
        {
            listadoUsuarios.Add(ObjectMapping(row));
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


        return (DBHelper.GetDBHelper().EjecutarSQL(str_sql) == 1);
    }
    internal bool Update(Usuario oUsuario)
    {
        //SIN PARAMETROS

        string str_sql = "UPDATE Usuario " +
                         "SET contraseña=" + "'" + oUsuario.Contraseña + "'" + "," +
                         " email=" + "'" + oUsuario.Email + "'" + "," +
                         " perfil=" + oUsuario.Perfil.IdPerfil +
                         " WHERE idUsuario=" + oUsuario.IdUsuario;

        return (DBHelper.GetDBHelper().EjecutarSQL(str_sql) == 1);
    }
    public Usuario GetUserSinParametros(string idUsuario)
    {
        //Construimos la consulta sql para buscar el usuario en la base de datos.
        String strSql = string.Concat(" SELECT  email, ",
                                      "        contraseña, ",
                                      "        p.idPerfil, ",
                                      "        p.nombre as perfil ",
                                      "   FROM Usuario u",
                                      "  INNER JOIN Perfil p ON u.perfil= p.idPerfil ",
                                      "  WHERE u.borrado =0 ");

        strSql += " AND idUsuario=" + "'" + idUsuario + "'";


        //Usando el método GetDBHelper obtenemos la instancia unica de DBHelper (Patrón Singleton) y ejecutamos el método ConsultaSQL()
        var resultado = DBHelper.GetDBHelper().consultar(strSql);

        // Validamos que el resultado tenga al menos una fila.
        if (resultado.Rows.Count > 0)
        {
            return ObjectMapping(resultado.Rows[0]);
        }

        return null;
    }

    }
}