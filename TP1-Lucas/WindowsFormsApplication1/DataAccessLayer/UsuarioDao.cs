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
                             " id_perfil=" + oUsuario.Perfil.IdPerfil +
                             " WHERE id_usuario=" + oUsuario.IdUsuario;

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
    }
}
