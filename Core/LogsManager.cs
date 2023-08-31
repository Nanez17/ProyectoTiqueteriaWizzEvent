using DataAccess.CRUD;
using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class LogsManager
    {
    
        public List<Logs> RetrieveAll()
        {
            var mm = new LogsR();
            return mm.RetrieveAll<Logs>();
        }
        public Logs RetrieveByID(Logs log)
        {
            var id = log.Id;
            var mcrud = new LogsR();
            return mcrud.RetrieveById<Logs>(log);
        }

    }
}
