using DataAccess.CRUD;
using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class SunpeManager
    {
        public void PaySunpeTransaction(TEF sunpeTransaction)
        {
            var crud = new SunpeCrudFactory();
            crud.Create(sunpeTransaction);
        }

        public TEF RetrieveIdSunpe(string transactionId)
        {
            var crud = new SunpeCrudFactory();
            return crud.RetrieveIdSunpe<TEF>(transactionId);
        }
    }
}
