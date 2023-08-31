using DataAccess.DAO;
using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mapper
{
    public class MembershipMapper : ISqlStatements, IObjectMapper
    {
        public BaseDTO BuildObject(Dictionary<string, object> row)
        {
            var membershipDTO = new Memberships
            {
                Id = (int)row["IdMembership"],
                Name = (string)row["Name"],
                Price = Convert.ToSingle(row["Price"]),
                TicketsToSellMin = (int)row["TicketsToSellMin"],
                TicketsToSellMax = (int)row["TicketsToSellMax"],
                Commission = Convert.ToSingle(row["Commission"])
            };
            return membershipDTO;
        }

        public List<BaseDTO> BuildObjects(List<Dictionary<string, object>> row)
        {
            var lstResults = new List<BaseDTO>();
            foreach (var item in row)
            {
                var membershipDTO = BuildObject(item);
                lstResults.Add(membershipDTO);
            }
            return lstResults;
        }

        public SQLOperation GetCreateStatement(BaseDTO dto)
        {
            
            var sqlOperation = new SQLOperation();
            sqlOperation.ProcedureName = "CRE_MEMBERSHIP_PR";


            var membership = (Memberships)dto;

            sqlOperation.AddVarcharParam("P_NAME", membership.Name);
            sqlOperation.AddFloatParam("P_PRICE", membership.Price);
            sqlOperation.AddIntParam("P_TICKETSTOSELLMIN", membership.TicketsToSellMin);
            sqlOperation.AddIntParam("P_TICKETSTOSELLMAX", membership.TicketsToSellMax);
            sqlOperation.AddFloatParam("P_COMMISSION", membership.Commission);
          


            return sqlOperation;

        }

        public SQLOperation GetDeleteStatement(BaseDTO dto)
        {

            var sqlOperation = new SQLOperation();
            sqlOperation.ProcedureName = "DEL_MEMBERSHIP_PR";


            var membership = (Memberships)dto;


            sqlOperation.AddIntParam("P_MEMBERSHIP_ID", membership.Id);

            return sqlOperation;
        }

        public SQLOperation GetRetrieveAllStatement()
        {
            var sqlOperation = new SQLOperation();
            sqlOperation.ProcedureName = "RETRIEVE_ALL_MEMBERSHIPS_PR";

            return sqlOperation;
        }

        public SQLOperation GetRetrieveByEmailAndPassword(BaseDTO dto)
        {
            throw new NotImplementedException();
        }

        public SQLOperation GetRetrieveByIDStatement(BaseDTO dto)
        {
            var sqlOperation = new SQLOperation();
            sqlOperation.ProcedureName = "RET_BY_ID_MEMBERSHIP_PR";

            var membership = (Memberships)dto;
            sqlOperation.AddIntParam("P_ID", membership.Id);

            return sqlOperation;
        }

        public SQLOperation GetUpdateStatement(BaseDTO dto)
        {
            var sqlOperation = new SQLOperation();
            sqlOperation.ProcedureName = "UPDT_MEMBERSHIP_PR";

            var membership = (Memberships)dto;

            sqlOperation.AddIntParam("P_ID", membership.Id);
            sqlOperation.AddVarcharParam("P_NAME", membership.Name);
            sqlOperation.AddFloatParam("P_PRICE", membership.Price);
            sqlOperation.AddIntParam("P_TICKETSTOSELLMIN", membership.TicketsToSellMin);
            sqlOperation.AddIntParam("P_TICKETSTOSELLMAX", membership.TicketsToSellMax);
            sqlOperation.AddFloatParam("P_COMMISSION", membership.Commission);

            return sqlOperation;
        }


    }
}
