using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrabajoPractico.Entities;
using TrabajoPractico.DataAccessLayer;

namespace TrabajoPractico.BusinessLayer
{
    class ProveedorService
    {
        private ProveedorDao oProveedorDao = new ProveedorDao();

        public IList<Proveedor> ConsultarProveedores(string condiciones)
        {
            return oProveedorDao.GetProveedores(condiciones);
        }

        public IList<Proveedor> GetProveedores()
        {
            return oProveedorDao.GetAll();
        }

        public bool crearProveedor(Proveedor perfil)
        {
            return oProveedorDao.Create(perfil);
        }

        public bool actualizarProveedor(Proveedor proveedor)
        {
            return oProveedorDao.Update(proveedor);
        }

        internal bool ModificarEstadoPerfil(Proveedor oProveedorSelected)
        {
            return oProveedorDao.Delete(oProveedorSelected);
        }

        internal bool ObtenerProveedor(int doc)
        {
            //SIN PARAMETROS
            return oProveedorDao.GetProveedorCuil(doc);

        }
    }
}
