using DataAccess.DAO;
using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mapper
{
    public class RolesMapper : IObjectMapper, ISqlStatements
    {
        public BaseDTO BuildObject(Dictionary<string, object> row)
        {
            var rol = new Roles
            {
                idRol = (int)row["IdRole"],
                RolName = (string)row["RoleName"],
            };
            return rol;
        }

        public List<BaseDTO> BuildObjects(List<Dictionary<string, object>> row)
        {
            var lstResults = new List<BaseDTO>();
            foreach (var item in row)
            {
                var userDTO = BuildObject(item);
                lstResults.Add(userDTO);
            }
            return lstResults;
        }

        public SQLOperation GetCreateStatement(BaseDTO dto)
        {
            throw new NotImplementedException();
        }

        public SQLOperation GetDeleteStatement(BaseDTO dto)
        {
            throw new NotImplementedException();
        }

        public SQLOperation GetRetrieveAllStatement()
        {
            throw new NotImplementedException();
        }

        public SQLOperation GetRetrieveByIDStatement(BaseDTO dto)
        {

            var sqlOperation = new SQLOperation();
            sqlOperation.ProcedureName = "RET_ROL_BY_ID_PR";

            var rol = (Roles)dto;
            sqlOperation.AddIntParam("@P_IdUser", rol.Id);;

            return sqlOperation;
        }

        public SQLOperation GetUpdateStatement(BaseDTO dto)
        {
            throw new NotImplementedException();
        }
    }
}
