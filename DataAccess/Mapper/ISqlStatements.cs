using DataAccess.DAO;
using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mapper
{
    public interface ISqlStatements
    {
        SQLOperation GetCreateStatement(BaseDTO dto);

        // Se definen los statements para update,delete, retrieve

        SQLOperation GetUpdateStatement(BaseDTO dto);

        SQLOperation GetDeleteStatement(BaseDTO dto);

        SQLOperation GetRetrieveAllStatement();

        SQLOperation GetRetrieveByIDStatement(BaseDTO dto);
      
    }
}
