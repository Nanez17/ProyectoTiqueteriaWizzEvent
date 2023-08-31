using DataAccess.DAO;
using DataAccess.Mapper;
using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.CRUD
{
    public class ShoppingCartCrudFactory : CrudFactory
    {
        ShoppingCartMapper _mapper;

        public ShoppingCartCrudFactory()
        {
            _dao = SqlDao.GetInstance();
            _mapper = new ShoppingCartMapper();
        }

        public override void Create(BaseDTO dto)
        {
            var shoppingCart = (ShoppingCart)dto;

            var sqlOperation = _mapper.GetCreateStatement(shoppingCart);

            _dao.ExecuteProcedure(sqlOperation);
        }

        public override void Delete(BaseDTO dto)
        {
            throw new NotImplementedException();
        }

        public override List<T> RetrieveAll<T>()
        {
            throw new NotImplementedException();
        }

        public override T RetrieveById<T>(BaseDTO dto)
        {
            throw new NotImplementedException();
        }

        public override void Update(BaseDTO dto)
        {
            throw new NotImplementedException();
        }

        public int RetrieveCantCartItems(int idUser)
        {
            var sqlOperation = _mapper.GetRetrieveCantCartItemsStatement(idUser);

            var queryResult = _dao.ExecuteQueryProcedure(sqlOperation);

            if (queryResult.Count > 0 && queryResult[0].ContainsKey("CantItems"))
            {
                if (queryResult[0]["CantItems"] is int cantCartItems)
                {
                    return cantCartItems;
                }
            }

            return -1; 
        }

    }
}
