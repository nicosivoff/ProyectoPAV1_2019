using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using TrabajoPractico.DataAccessLayer;
using TrabajoPractico.Entities;

namespace TrabajoPractico.BusinessLayer
{
    class UsuarioService
    {
        private UsuarioDao oUsuarioDao = new UsuarioDao();

        public IList<Usuario> ConsultarUsuarios(string condiciones)
        {
            return oUsuarioDao.GetUsuarios(condiciones);
        }

        public bool crearUsuario(Usuario usuario)
        {
            return oUsuarioDao.crear(usuario);
        }

        public bool actualizarUsuario(Usuario usuario)
        {
            return oUsuarioDao.actualizar(usuario);
        }
        internal IList<Usuario> ConsultarConFiltrosSinParametros(String condiciones)
        {
            return oUsuarioDao.GetByFiltersSinParametros(condiciones);
        }
        public IList<Usuario> ObtenerTodos()
        {
            return oUsuarioDao.GetAll();
        }
        internal bool CrearUsuario(Usuario oUsuario)
        {
            return oUsuarioDao.Create(oUsuario);
        }
        internal bool ActualizarUsuario(Usuario oUsuarioSelected)
        {
            return oUsuarioDao.Update(oUsuarioSelected);
        }

        internal bool ModificarEstadoUsuario(Usuario oUsuarioSelected)
        {
            throw new NotImplementedException();
        }

        internal object ObtenerUsuario(string usuario)
        {
            //SIN PARAMETROS
            return oUsuarioDao.GetUserSinParametros(usuario);

            //CON PARAMETROS
            // return oUsuarioDao.GetUserConParametros(usuario);
        }
    }
}
