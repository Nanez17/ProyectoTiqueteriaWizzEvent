using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    //Clase "padre" de todos los DTOs de la arquitectura
    //Todo DTO debe heredar de esta clase.
    public class BaseDTO
    {
        public int Id { get; set; }
    }
}
