using DataAccess.DAO;
using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mapper
{
    public class SunpeMapper : ISqlStatements, IObjectMapper
    {
        public BaseDTO BuildObject(Dictionary<string, object> row)
        {
            var sunpe = new TEF
            {
                Id = (int)row["IdSunpe"]
            };

            return sunpe;
        }

        public List<BaseDTO> BuildObjects(List<Dictionary<string, object>> row)
        {
            var lstResults = new List<BaseDTO>();

            foreach (var item in row)
            {
                var sunpe = BuildObject(item);
                lstResults.Add(sunpe);
            }

            return lstResults;
        }

        public SQLOperation GetCreateStatement(BaseDTO dto)
        {
            var sqlOperation = new SQLOperation();
            sqlOperation.ProcedureName = "PAY_SUNPE_TRANSACTIONS_PR";

            var sunpe = (TEF)dto;

            sqlOperation.AddDecimalParam("P_AMOUNT", sunpe.Amount);
            sqlOperation.AddVarcharParam("P_SENDER", sunpe.Sender);
            sqlOperation.AddVarcharParam("P_TRANSACTIONID", sunpe.TransactionId);

            return sqlOperation;
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
            throw new NotImplementedException();
        }

        public SQLOperation GetUpdateStatement(BaseDTO dto)
        {
            throw new NotImplementedException();
        }

        public SQLOperation GetRetrieveIdSunpeStatement(string transactionId)
        {
            var sqlOperation = new SQLOperation();
            sqlOperation.ProcedureName = "RET_ID_SUNPE_TRANSACTION_PR";

            sqlOperation.AddVarcharParam("P_TRANSACTIONID", transactionId);

            return sqlOperation;
        }
    }
}
