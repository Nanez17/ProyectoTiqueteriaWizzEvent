using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mapper
{
    public interface IObjectMapper
    {
        //Metodo para construir un objeto (SINGULAR)

        BaseDTO BuildObject(Dictionary<string,object> row);


        //Metodo para construir multiples objetos

        List<BaseDTO> BuildObjects(List<Dictionary<string, object>> row);



    }
}
