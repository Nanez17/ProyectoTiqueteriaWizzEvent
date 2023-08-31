using DataAccess.DAO;
using DTOs;
using DTOs.Events;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mapper
{
    public class CartItemMapper : IObjectMapper, ISqlStatements
    {
        public CartItem BuildObjectItem(Dictionary<string, object> row)
        {
            var items = new CartItem
            {
                eventName = row["eventName"] != DBNull.Value ? (string)row["eventName"] : string.Empty,
                eventDate = row["eventDate"] != DBNull.Value ? (string)row["eventDate"] : string.Empty,
                sectorName = row["sectorName"] != DBNull.Value ? (string)row["sectorName"] : string.Empty,
                seatName = row["seatName"] != DBNull.Value ? (string)row["seatName"] : string.Empty,
                seatId = (int)row["seatId"],
                seatPrice = (decimal)row["seatPrice"]
            };

            return items;
        }

        public List<CartItem> BuildObjectsItems(List<Dictionary<string, object>> row)
        {
            var lstResults = new List<CartItem>();

            foreach (var item in row)
            {
                var cartItem = BuildObjectItem(item);
                lstResults.Add(cartItem);
            }

            return lstResults;
        }

        public SQLOperation GetAddStatement(int IdCart, int IdSector, int Quantity)
        {
            var sqlOperation = new SQLOperation();
            sqlOperation.ProcedureName = "CRE_CARTITEM_PR";

            sqlOperation.AddIntParam("P_IDCART", IdCart);
            sqlOperation.AddIntParam("P_IDSECTOR", IdSector);
            sqlOperation.AddIntParam("P_QUANTITY", Quantity);

            return sqlOperation;
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
            throw new NotImplementedException();
        }

        public SQLOperation GetUpdateStatement(BaseDTO dto)
        {
            throw new NotImplementedException();
        }

        public SQLOperation GetRetrieveAllCartItemsStatement(int idUser)
        {
            var sqlOperation = new SQLOperation();
            sqlOperation.ProcedureName = "RET_ALL_CART_ITEMS_PR";

            sqlOperation.AddIntParam("P_IDUSER", idUser);

            return sqlOperation;
        }

        BaseDTO IObjectMapper.BuildObject(Dictionary<string, object> row)
        {
            throw new NotImplementedException();
        }

        public List<BaseDTO> BuildObjects(List<Dictionary<string, object>> row)
        {
            throw new NotImplementedException();
        }

        public SQLOperation GetCleanCartItemsStatement(int idUser)
        {
            var sqlOperation = new SQLOperation();
            sqlOperation.ProcedureName = "CLEAN_CART_ITEMS_PR";

            sqlOperation.AddIntParam("P_IDUSER",idUser);


            return sqlOperation;
        }

        public SQLOperation GetPayCartItemStatement(int idUser, int idSunpe)
        {
            var sqlOperation = new SQLOperation();
            sqlOperation.ProcedureName = "PAY_CART_ITEMS_PR";

            sqlOperation.AddIntParam("P_IDUSER", idUser);
            sqlOperation.AddIntParam("P_IDSUNPE", idSunpe);


            return sqlOperation;
        }

        public SQLOperation GetAsignSeatToClientStatement(int idSeat, string ownerName, string ownerMail)
        {
            var sqlOperation = new SQLOperation();
            sqlOperation.ProcedureName = "ASIGN_SEAT_TO_CLIENT_PR";

            sqlOperation.AddIntParam("P_IDSEAT", idSeat);
            sqlOperation.AddVarcharParam("P_OWNERNAME", ownerName);
            sqlOperation.AddVarcharParam("P_OWNERMAIL", ownerMail);

            return sqlOperation;
        }
    }
}
