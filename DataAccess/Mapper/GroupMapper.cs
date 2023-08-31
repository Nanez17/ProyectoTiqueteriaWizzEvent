using DataAccess.DAO;
using DTOs;
using DTOs.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mapper
{
    public class GroupMapper : ISqlStatements, IObjectMapper
    {
        #region"IObjectMapper"
        public BaseDTO BuildObject(Dictionary<string, object> row)
        {
            var groupDTO = new Group
            {
                Id = (int)row["IdGroup"],
                Name = row["Name"] != DBNull.Value ? (string)row["Name"] : string.Empty,
                State = row["State"] != DBNull.Value ? (string)row["State"] : string.Empty,
                StartDate = (DateTime)row["StartDate"],
                FinalDate = (DateTime)row["FinalDate"]
            };

            return groupDTO;
        }

        public List<BaseDTO> BuildObjects(List<Dictionary<string, object>> lstRows)
        {
            var lstResults = new List<BaseDTO>();

            foreach (var item in lstRows)
            {
                var groupDTO = BuildObject(item);
                lstResults.Add(groupDTO);
            }

            return lstResults;
        }
        #endregion

        #region"ISqlStatements"
        public SQLOperation GetCreateStatement(BaseDTO dto)
        {
            var sqlOperation = new SQLOperation();
            sqlOperation.ProcedureName = "CRE_GROUP_PR";

            var group = (Group)dto;

            sqlOperation.AddVarcharParam("P_NAME", group.Name);
            sqlOperation.AddVarcharParam("P_STATE", group.State);
            sqlOperation.AddDateTimeParam("P_STARTDATE", group.StartDate);
            sqlOperation.AddDateTimeParam("P_FINALDATE", group.FinalDate);

            return sqlOperation;
        }

        public SQLOperation GetDeleteStatement(BaseDTO dto)
        {
            var sqlOperation = new SQLOperation();
            sqlOperation.ProcedureName = "DEL_GROUP_PR";

            var group = (Group)dto;

            sqlOperation.AddIntParam("P_IDGROUP", group.Id);

            return sqlOperation;
        }

        public SQLOperation GetRetrieveAllStatement()
        {
            var sqlOperation = new SQLOperation();
            sqlOperation.ProcedureName = "RET_ALL_GROUPS_PR";

            return sqlOperation;

        }

        public SQLOperation GetRetrieveByEmailAndPassword(BaseDTO dto)
        {
            throw new NotImplementedException();
        }

        public SQLOperation GetRetrieveByIDStatement(BaseDTO dto)
        {
            throw new NotImplementedException();
        }

        public SQLOperation GetUpdateStatement(BaseDTO dto)
        {
            var sqlOperation = new SQLOperation();
            sqlOperation.ProcedureName = "UPD_GROUP_PR";

            var group = (Group)dto;

            sqlOperation.AddIntParam("P_IDGROUP", group.Id);
            sqlOperation.AddVarcharParam("P_NAME", group.Name);
            sqlOperation.AddVarcharParam("P_STATE", group.State);
            sqlOperation.AddDateTimeParam("P_STARTDATE", group.StartDate);
            sqlOperation.AddDateTimeParam("P_FINALDATE", group.FinalDate);

            return sqlOperation;
        }
        #endregion


    }
}
