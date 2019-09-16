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
    }
}
