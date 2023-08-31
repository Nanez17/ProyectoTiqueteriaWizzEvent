using DataAccess.CRUD;
using DTOs;
using DTOs.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class VentaManager
    {
        public VentaManager() { }

        public List<VentaTotal> RetrieveAllCategories()
        {
            var crud = new VentaTotalCRUD();
            return crud.RetrieveAll<VentaTotal>();
        }

    }
}
