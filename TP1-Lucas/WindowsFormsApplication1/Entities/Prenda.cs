using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;


namespace TrabajoPractico.Entities
{
    class Prenda
    {
        
        public int codPrenda { get; set; }
        public TipoPrenda tipoPrenda { get; set; }
        public string talle { get; set; }
        public string descripcion { get; set; }
        public int precio { get; set; }
        public int cantidad { get; set; }
        public Marca marca { get; set; }

        
       /* public bool validarDatosPrenda()
        {
            if (this.Codigo == null)
            {
                MessageBox.Show("El codigo esta vacio");
                return false;
            }
            if (this.Tipo.CodTipoPrenda == -1)
            {
                MessageBox.Show("El tipo esta vacio");
                return false;
            }
            if (this.Descripcion == "")
            {
                MessageBox.Show("La descripcion esta vacia");
                return false;
            }
            if (this.Talle == "")
            {
                MessageBox.Show("El talle esta vacio");
                return false;
            }
            if (this.Precio == "")
            {
                MessageBox.Show("El precio esta vacio");
                return false;
            }
            if (this.Cantidad == "")
            {
                MessageBox.Show("El cantidad esta vacio");
                return false;
            }
            return true;

        }
        */
    }
}
