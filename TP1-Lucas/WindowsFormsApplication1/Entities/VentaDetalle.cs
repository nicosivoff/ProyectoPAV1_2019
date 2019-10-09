using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabajoPractico.Entities
{
    public class VentaDetalle
    {
        public int IdVentaDetalle { get; set; }
        public int IdVenta { get; set; }
        public int NroItem { get; set; }
        public Prenda Prenda { get; set; }
        public Double PrecioUnitario { get; set; }
        public int Cantidad { get; set; }

        public int IdProducto
        {
            get
            {
                return Prenda.CodPrenda;
            }
        }
        public string PrendaDescripcion
        {
            get
            {
                return Prenda.Descripcion;
            }
        }

        public Double Importe
        {
            get
            {
                return Cantidad * PrecioUnitario;
            }
        }
    }
}
