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
    public class VentaMapper : ISqlStatements, IObjectMapper
    {
        public BaseDTO BuildObject(Dictionary<string, object> row)
        {

            var venta = new VentaTotal
            {
                VentasTotales = (float)(decimal)row["TotalSales"]
            };

            return venta;
        }

        public List<BaseDTO> BuildObjects(List<Dictionary<string, object>> row)
        {
            var lstResults = new List<BaseDTO>();

            foreach (var item in row)
            {
                var ventaDTO = BuildObject(item);
                lstResults.Add(ventaDTO);
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
            sqlOperation.ProcedureName = "GetTotalSales";

            return sqlOperation;
        }

        public SQLOperation GetRetrieveByIDStatement(BaseDTO dto)
        {
            throw new NotImplementedException();
        }

        public SQLOperation GetUpdateStatement(BaseDTO dto)
        {
            throw new NotImplementedException();
        }
    }
}
