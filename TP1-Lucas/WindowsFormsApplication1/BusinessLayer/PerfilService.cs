using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabajoPractico.BusinessLayer
{
    class PerfilService
    {
        private PerfilDao oPerfilDao;
        public PerfilService()
        {
            oPerfilDao = new PerfilDao();
        }
        public IList<Perfil> ObtenerTodos()
        {
            return oPerfilDao.GetAll();
        }
    }
}
