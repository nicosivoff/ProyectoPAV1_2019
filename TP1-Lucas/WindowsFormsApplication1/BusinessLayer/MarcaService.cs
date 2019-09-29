using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrabajoPractico.DataAccessLayer;

namespace TrabajoPractico.BusinessLayer
{
    class MarcaService
    {
        private MarcaDao oMarcaDao;
        public MarcaService()
        {
            oMarcaDao = new MarcaDao();
        }
        public IList<Marca> obtenerTodos()
        {
            return oMarcaDao.getAll();
        }
        public IList<Marca> obtenerConFiltros(String condiciones)
        {
            return oMarcaDao.getMarcaCondicionada(condiciones);
        }
        public object obtenerMarca(string idMarca)
        {
            return oMarcaDao.getMarcaSinParametros(idMarca);
        }
        public bool crearMarca(Marca marca)
        {
            return oMarcaDao.crearMarca(marca);
        }
        public bool actualizarMarca(Marca marca)
        {
            return oMarcaDao.actualizarMarca(marca);
        }
        public bool modificarEstadoMarca(Marca marca)
        {
            return oMarcaDao.deleteMarca(marca);
        }
        
    }
}
