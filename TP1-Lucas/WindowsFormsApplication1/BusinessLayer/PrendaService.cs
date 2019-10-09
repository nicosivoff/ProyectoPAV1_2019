using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrabajoPractico.DataAccessLayer;
using TrabajoPractico.Entities;

namespace TrabajoPractico.BusinessLayer
{
    class PrendaService
    {
        private PrendaDao oPrendaDao = new PrendaDao();

        public IList<Prenda> ConsultarPrendasConFiltros(String condiciones)
        {
            return oPrendaDao.getPrendasCondicionada(condiciones);
        }
        public Prenda ConsultarPrendaPorId(string id)
        {
            return oPrendaDao.getPrendaID(Int32.Parse(id));
        }
        public object ObtenerPrenda(string codPrenda)
        {
            return oPrendaDao.GetPrendaSinParametros(codPrenda);
        }
        public bool crearPrenda(Prenda prenda)
        {
            return oPrendaDao.crearPrenda(prenda);
        }
        public bool actualizarPrenda(Prenda prenda)
        {
            return oPrendaDao.actualizarPrenda(prenda);
        }
        public bool modificarEstadoPrenda(Prenda prenda)
        {
            return oPrendaDao.delete(prenda);
        }

        public IList<Prenda> ObtenerTodos()
        {
            return oPrendaDao.GetAll();
        }
    }
}
