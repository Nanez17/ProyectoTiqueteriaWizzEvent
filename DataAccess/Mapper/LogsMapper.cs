using DataAccess.DAO;
using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mapper
{
    public class LogsMapper : IObjectMapper, ISqlStatements
    {
        public BaseDTO BuildObject(Dictionary<string, object> row)
        {
            var LogDTO = new Logs
            {
                Id = (int)row["IdLOG"],
                IdUsuario = (int)row["IdAffected"],
                TableName = (string)row["TableName"],
                Action = (string)row["Accion"],
                IdAffected = (int)row["IdAffected"],
                OldData = row["OldData"]?.ToString(),
                NewData = row["NewData"]?.ToString(),
                TimeLog = (DateTime)row["TimeLog"],
            
            };
            return LogDTO;
        }

        public List<BaseDTO> BuildObjects(List<Dictionary<string, object>> row)
        {
            var lstResults = new List<BaseDTO>();
            foreach (var item in row)
            {
                var logDto = BuildObject(item);
                lstResults.Add(logDto);
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
            var sqlOperation = new SQLOperation();
            sqlOperation.ProcedureName = "RETRIEVE_ALL_LOGS_PR";

            return sqlOperation;
        }

        public SQLOperation GetRetrieveByEmailAndPassword(BaseDTO dto)
        {
            throw new NotImplementedException();
        }

        public SQLOperation GetRetrieveByIDStatement(BaseDTO dto)
        {
            var sqlOperation = new SQLOperation();
            sqlOperation.ProcedureName = "RET_BY_ID_LOG_PR";

            var log = (Logs)dto;
            sqlOperation.AddIntParam("P_ID", log.Id);

            return sqlOperation;
        }

        public SQLOperation GetUpdateStatement(BaseDTO dto)
        {
            throw new NotImplementedException();
        }
    }
}
