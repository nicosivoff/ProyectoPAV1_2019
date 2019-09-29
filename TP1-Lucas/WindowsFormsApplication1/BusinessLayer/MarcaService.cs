using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrabajoPractico.DataAccessLayer;

namespace TrabajoPractico.BusinessLayer
{
    class MarcaService
    {
        MarcaDao oMarcaDao = new MarcaDao();

        public Marca consultarMarcaPorId(int id)
        {
            return oMarcaDao.getMarcaId(id);
        }
    }
}