using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrabajoPractico.Entities;
using System.Data;
using TrabajoPractico.DataAccessLayer;
using System.Windows.Forms;


namespace TrabajoPractico.DataAccessLayer
{   
    
    class PrendaDao
    {
        DBHelper oBD = new DBHelper();
        
        public void grabarPrenda(int tipo, string talle, string descripcion, int precio, int cantidad, int marca)
        {
            try
            {
                string sqlInsert = "";

                sqlInsert = @"INSERT INTO Prenda (tipoPrenda,talle,descripcion,precio,cantidad,marca) VALUES ('" +
                             tipo + "', '" +
                             talle + "', '" +
                             descripcion + "', '" +
                             precio + "', '" +
                             cantidad + "', '" +
                             marca + "')";

                oBD.actualizar(sqlInsert);
                MessageBox.Show("La prenda se agrego con exito");
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo agregar.");
                throw ex;
            }
            
           

        }

        /*public void actualizarPrenda()
        {
            string sqlUpdate = "";
            // (codPrenda,tipoPrenda,talle,descripcion,precio,cantidad)
            sqlUpdate = @"UPDATE Prenda SET tipoPrenda=" + this.tipo + ", " +
                        "talle='" + this.talle + "', " +
                        "descripcion='" + this.descripcion + "', " +
                        "precio='" + this.precio + "', " +
                        "cantidad='" + this.cantidad + "'" +
                        " WHERE codPrenda=" + this.codigo;

            oBD.actualizar(sqlUpdate);

        }
        public void eliminarPrenda()
        {
            string sqlDelete = @"DELETE FROM Prenda WHERE codPrenda='" + this.codigo + "'";
            oBD.actualizar(sqlDelete);
        }

        public DataTable recuperarPrenda()
        {
            string strSql = "SELECT p.codPrenda, t.descripcion, p.talle, p.descripcion, p.precio, p.cantidad, m.nombre"
                            + " FROM Prenda p, TipoPrenda t, Marca m"
                            + " WHERE p.tipoPrenda=t.codTipoPrenda"
                            + " AND p.marca=m.idMarca";
            return oBD.consultar(strSql);
        }
         * */

        public Prenda getPrendaID(int iD)
        {
            string strSql = "SELECT p.codPrenda, p.tipoPrenda, t.descrip, p.talle, p.descripcion, p.precio, p.cantidad, p.marca, m.nombre"
                            + " FROM Prenda p, TipoPrenda t, Marca m"
                            + " WHERE p.tipoPrenda=t.codTipoPrenda"
                            + " AND p.marca=m.idMarca"
                            + " AND p.borrado = 0"
                            + " AND p.codPrenda=" + iD.ToString();

            return MappingPrenda(oBD.consultar(strSql).Rows[0]);
        }

        public IList<Prenda> getPrendasCondicionada(string condiciones)
        {   

            List<Prenda> listadoPrendas = new List<Prenda>();
            
            String strSql = "SELECT p.codPrenda, p.tipoPrenda, t.descrip, p.talle, p.descripcion, p.precio, p.cantidad, p.marca, m.nombre"
                            + " FROM Prenda p, TipoPrenda t, Marca m"
                            + " WHERE p.tipoPrenda=t.codTipoPrenda"
                            + " AND p.marca=m.idMarca"
                            + " AND p.borrado = 0";
            strSql += condiciones;

            var resultadoConsulta = (DataRowCollection)oBD.consultar(strSql).Rows;

            foreach (DataRow row in resultadoConsulta)
            {
                listadoPrendas.Add(MappingPrenda(row));
            }

            return listadoPrendas;

        }

        private Prenda MappingPrenda(DataRow row)
        {
            Prenda oPrenda = new Prenda();
            oPrenda.CodPrenda = Convert.ToInt32(row["codPrenda"].ToString());
            oPrenda.TipoPrenda = new TipoPrenda();
            oPrenda.TipoPrenda.Codigo = Convert.ToInt32(row["tipoPrenda"].ToString());
            oPrenda.TipoPrenda.Nombre = row["descrip"].ToString();
            oPrenda.Talle = row["talle"].ToString();
            oPrenda.Descripcion = row["descripcion"].ToString();
            oPrenda.Precio = Convert.ToInt32(row["precio"].ToString());
            oPrenda.Cantidad = Convert.ToInt32(row["cantidad"].ToString());
            oPrenda.Marca = new Marca();
            oPrenda.Marca.IdMarca = Convert.ToInt32(row["marca"].ToString());
            oPrenda.Marca.Nombre = row["nombre"].ToString();

            return oPrenda;
        }
        
    }
}
