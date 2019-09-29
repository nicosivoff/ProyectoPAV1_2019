using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrabajoPractico.DataAccessLayer;
using TrabajoPractico.Entities;

namespace TrabajoPractico.BusinessLayer
{
    class PerfilService
    {
        private PerfilDao oPerfilDao = new PerfilDao();

        public IList<Perfil> ConsultarPerfiles(string condiciones)
        {
            return oPerfilDao.GetPerfiles(condiciones);
        }

        public bool crearPerfil(Perfil perfil)
        {
            return oPerfilDao.crear(perfil);
        }

        public bool actualizarPerfil(Perfil perfil)
        {
            return oPerfilDao.actualizar(perfil);
        }

        public IList<Perfil> ObtenerTodos()
        {
            return oPerfilDao.GetAll();
        }

        public IList<Perfil> ObtenerConFiltros(string condiciones)
        {
            return oPerfilDao.GetConFiltros(condiciones);
        }

        internal bool CrearPerfil(Perfil oPerfil)
        {
            return oPerfilDao.Create(oPerfil);
        }
        internal bool ActualizarPerfil(Perfil oPerfilSelected)
        {
            return oPerfilDao.Update(oPerfilSelected);
        }

        internal bool ModificarEstadoPerfil(Perfil oPerfilSelected)
        {
            return oPerfilDao.Delete(oPerfilSelected);
        }

        internal bool ObtenerPerfil(string perfil)
        {
            //SIN PARAMETROS
            return oPerfilDao.GetPerfilSinParametros(perfil);

        }
    }
}
