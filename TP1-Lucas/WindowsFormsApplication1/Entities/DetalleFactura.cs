using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabajoPractico.Entities
{
    class DetalleFactura
    {
        public int codFactura { get; set; }
        public int codPrenda { get; set; }
        public string cantidad { get; set; }
        public int codDetalleFactura { get; set; }

    }
}
