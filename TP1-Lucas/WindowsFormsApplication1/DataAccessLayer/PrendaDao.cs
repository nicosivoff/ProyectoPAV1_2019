using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrabajoPractico.Entities;
using System.Data;
using TrabajoPractico.DataAccessLayer;


namespace TrabajoPractico.DataAccessLayer
{   
    
    class PrendaDao
    {
        DBHelper oBD = new DBHelper();
        /*public void grabarPrenda()
        {
            string sqlInsert = "";

            sqlInsert = @"INSERT INTO Prenda (codPrenda,tipoPrenda,talle,descripcion,precio,cantidad,marca) VALUES ('" +
                         this.codigo + "', '" +
                         this.tipo + "', '" +
                         this.talle + "', '" +
                         this.descripcion + "', '" +
                         this.precio + "', '" +
                         this.cantidad + "', '" +
                         this.marca + "')";

            oBD.actualizar(sqlInsert);

        }

        public void actualizarPrenda()
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

            //var resultadoConsulta = (DataRowCollection)oBD.consultar(strSql).Rows;
            var resultado = oBD.consultar(strSql);

            foreach (DataRow row in resultado.Rows)
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
        public Prenda GetPrendaSinParametros(string codPrenda)
        {
            string strSql = "SELECT p.codPrenda, p.tipoPrenda, t.descrip, p.talle, p.descripcion, p.precio, p.cantidad, p.marca, m.nombre"
                            + " FROM Prenda p, TipoPrenda t, Marca m"
                            + " WHERE p.tipoPrenda=t.codTipoPrenda"
                            + " AND p.marca=m.idMarca"
                            + " AND p.borrado = 0"
                            + " AND p.codPrenda=" + codPrenda.ToString();
            var resultado = DBHelper.GetDBHelper().consultar(strSql);

            if (resultado.Rows.Count > 0)
            {
                return MappingPrenda(resultado.Rows[0]);
            }
            return null;
        }
        public bool crearPrenda(Prenda prenda)
        {
            string strSql = "INSERT INTO Prenda(codPrenda, tipoPrenda, talle, descripcion, precio, cantidad, marca, borrado)"
                             + "VALUES ("
                             + "'" + prenda.CodPrenda + "' , "
                             + "'" + prenda.TipoPrenda.Codigo + "' , "
                             + "'" + prenda.Talle + "', "
                             + "'" + prenda.Descripcion + "' , "
                             + prenda.Precio + " , "
                             + prenda.Cantidad + " , "
                             + prenda.Marca.IdMarca + " , "
                             + "0)";
            return (DBHelper.GetDBHelper().EjecutarSQL(strSql) == 1);
        }
        public bool actualizarPrenda(Prenda prenda)
        {
            string strSql = "UPDATE Prenda" +
                            " SET tipoPrenda=" + prenda.TipoPrenda.Codigo +
                            ", talle='" + prenda.Talle + "'" +
                            ", descripcion='" + prenda.Descripcion + "'" +
                            ", precio=" + prenda.Precio +
                            ", cantidad=" + prenda.Cantidad +
                            ", marca=" + prenda.Marca.IdMarca +
                            ", borrado=0" +
                            "WHERE codPrenda= " + (int)prenda.CodPrenda;
            return (DBHelper.GetDBHelper().EjecutarSQL(strSql) == 1);
        }
        public bool delete(Prenda prenda)
        {
            string strSql = "UPDATE Prenda " +
                            "SET borrado=1" +
                            " WHERE codPrenda= " + prenda.CodPrenda;
            oBD.actualizar(strSql);
            return true;
        }

        public IList<Prenda> GetAll()
        {
            List<Prenda> listadoPrendas = new List<Prenda>();
            var strSql = "SELECT p.codPrenda, p.tipoPrenda, t.descrip, p.talle, p.descripcion, p.precio, p.cantidad, p.marca, m.nombre"
                            + " FROM Prenda p, TipoPrenda t, Marca m"
                            + " WHERE p.tipoPrenda=t.codTipoPrenda"
                            + " AND p.marca=m.idMarca"
                            + " AND p.borrado = 0";

            var resultado = oBD.consultar(strSql);

            foreach (DataRow row in resultado.Rows)
            {
                listadoPrendas.Add(MappingPrenda(row));
            }

            return listadoPrendas;
        }
        
    }
}
