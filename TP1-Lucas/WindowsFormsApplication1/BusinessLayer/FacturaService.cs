using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrabajoPractico.Entities;

namespace TrabajoPractico.BusinessLayer
{
    class FacturaService
    {
        internal bool ValidarDatos(Factura factura)
        {
            if (factura.FacturaDetalle.Count == 0)
            {
                throw new Exception("Debe ingresar al menos un item de factura.");
            }

            return true;
        }

        internal bool Crear(Factura factura)
        {
            return oFacturaDao.Create(factura);
        }
    }
}
