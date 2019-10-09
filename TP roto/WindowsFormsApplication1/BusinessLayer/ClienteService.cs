using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrabajoPractico.DataAccessLayer;
using TrabajoPractico.Entities;
using System.Data;

namespace TrabajoPractico.BusinessLayer
{
    class ClienteService
    {
        private ClienteDao oClienteDao = new ClienteDao();

        public IList<Cliente> ConsultarClientes(string condiciones)
        {
            return oClienteDao.GetClientes(condiciones);
        }

        public IList<Cliente> GetClientes()
        {
            return oClienteDao.GetAll();
        }

        public bool crearCliente(Cliente perfil)
        {
            return oClienteDao.Create(perfil);
        }

        public bool actualizarCliente(Cliente cliente)
        {
            return oClienteDao.Update(cliente);
        }

        internal bool ModificarEstadoPerfil(Cliente oClienteSelected)
        {
            return oClienteDao.Delete(oClienteSelected);
        }

        internal bool ObtenerCliente(int doc)
        {
            //SIN PARAMETROS
            return oClienteDao.GetClienteDoc(doc);

        }
        public IList<Cliente> ObtenerTodos()
        {
            return oClienteDao.GetAll();
        }
    }       
}
