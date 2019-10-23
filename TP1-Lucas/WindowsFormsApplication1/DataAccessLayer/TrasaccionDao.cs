using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrabajoPractico.Entities;

namespace TrabajoPractico.DataAccessLayer
{
    class TransaccionDao
    {
        internal bool Create(Venta venta)
        {
            DBHelper dbHelper = new DBHelper();
            try
            {
                dbHelper.conectar();
                dbHelper.BeginTransaction();

                string sql = string.Concat("INSERT INTO VentaTransaccion ",
                                                        "(fecha ",
                                                        ",cliente ",
                                                        ",tipoFactura ",
                                                        ",subtotal ",
                                                        ",borrado) ",
                                                    " VALUES ('",
                                                    venta.Fecha.ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss"), "'",
                                                    ",",venta.Cliente.NroDoc,
                                                    ",'",venta.TipoFactura,"'",
                                                    ",", venta.SubTotal,
                                                    ",0)");

                /*var parametros = new Dictionary<string, object>();
                parametros.Add("fecha", venta.Fecha);
                parametros.Add("cliente", venta.Cliente.NroDoc);
                parametros.Add("tipoFactura", venta.TipoFactura);
                parametros.Add("subtotal", venta.SubTotal);
                parametros.Add("borrado", false);*/
                dbHelper.EjecutarSQLTransaccion(sql);

                var newId = dbHelper.ConsultaSQLScalar("SELECT @@IDENTITY");
                venta.IdVenta = Convert.ToInt32(newId);

                foreach (var itemVenta in venta.VentaDetalle)
                {
                    string sqlDetalle = string.Concat(" INSERT INTO VentaDetalle",
                                                                    "(idVenta ",
                                                                    ",idPrenda ",
                                                                    ",precio ",
                                                                    ",cantidad ",
                                                                    ",borrado) ",
                                                                "VALUES",
                                                                    "(",venta.IdVenta ,
                                                                    ",",itemVenta.IdProducto,
                                                                    ",",itemVenta.PrecioUnitario,
                                                                    ",",itemVenta.Cantidad,
                                                                    ",0) ");
                    /*var paramDetalle = new Dictionary<string, object>();
                    paramDetalle.Add("idVenta", venta.IdVenta);
                    paramDetalle.Add("idPrenda", itemVenta.IdProducto);
                    paramDetalle.Add("precio", itemVenta.PrecioUnitario);
                    paramDetalle.Add("cantidad", itemVenta.Cantidad);
                    paramDetalle.Add("borrado", false);*/

                    dbHelper.EjecutarSQLTransaccion(sqlDetalle);
                }

                dbHelper.Commit();
                
                                                            
            }

            catch (Exception ex)
            {
                dbHelper.RollBack();
                throw ex;
            }
            finally
            {
                dbHelper.desconectar();
            }
            return true;
        }
    }
}
