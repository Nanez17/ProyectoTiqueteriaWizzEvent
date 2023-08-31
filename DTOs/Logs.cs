using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class Logs : BaseDTO
    {
        public int IdUsuario { get; set; }
        public string Action { get; set; }
        public string TableName { get; set; }
        public int IdAffected { get; set; }
        public string OldData {get; set; }
        public string NewData { get; set; }
        public DateTime TimeLog{ get; set; }

    }
}
