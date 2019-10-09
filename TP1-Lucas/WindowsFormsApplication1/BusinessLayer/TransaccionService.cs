using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrabajoPractico.DataAccessLayer;
using TrabajoPractico.Entities;

namespace TrabajoPractico.BusinessLayer
{
    class TransaccionService
    {
        private TransaccionDao oTransaccionDao;

        public TransaccionService(){
            oTransaccionDao = new TransaccionDao();
        }

        internal bool Crear(Venta venta)
        {
            return oTransaccionDao.Create(venta);
        }

        internal bool ValidarDatos(Venta venta)
        {
            if (venta.VentaDetalle.Count == 0)
            {
                throw new Exception("Debe ingersar al menos una prenda ");
            }
            return true;
        }


    }
}
