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
    }
}
