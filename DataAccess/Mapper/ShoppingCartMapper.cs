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
    public class ShoppingCartMapper : IObjectMapper, ISqlStatements
    {
        public BaseDTO BuildObject(Dictionary<string, object> row)
        {
            throw new NotImplementedException();
        }

        public List<BaseDTO> BuildObjects(List<Dictionary<string, object>> row)
        {
            throw new NotImplementedException();
        }

        public SQLOperation GetCreateStatement(BaseDTO dto)
        {
            var sqlOperation = new SQLOperation();
            sqlOperation.ProcedureName = "CRE_SHOPPINGCART_PR";

            var shoppingCart = (ShoppingCart)dto;

            sqlOperation.AddIntParam("P_IDUSER", shoppingCart.IdUser);

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

        public SQLOperation GetRetrieveCantCartItemsStatement(int idUser)
        {
            var sqlOperation = new SQLOperation();
            sqlOperation.ProcedureName = "RET_CANT_CART_ITEMS_PR";

            sqlOperation.AddIntParam("P_IDUSER", idUser);

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
