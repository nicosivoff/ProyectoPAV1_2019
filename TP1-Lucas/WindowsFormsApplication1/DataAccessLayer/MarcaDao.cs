using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace TrabajoPractico.DataAccessLayer
{
    class MarcaDao
    {
        DBHelper oBD = new DBHelper();
        public Marca getMarcaId(int id)
        {
            string strSQL = "SELECT idMarca, nombre"
                                + "FROM Marca WHERE idMarca=" + id.ToString();
            return mappingMarca(oBD.consultar(strSQL).Rows[0]);

        }
        public Marca mappingMarca(DataRow row)
        {
            Marca oMarca = new Marca();
            oMarca.IdMarca = Convert.ToInt32(row["idMarca"].ToString());
            oMarca.Nombre = row["nombre"].ToString();
            return oMarca;
        }
    }
}
