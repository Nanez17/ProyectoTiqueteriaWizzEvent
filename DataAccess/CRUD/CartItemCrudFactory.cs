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
    public class CartItemCrudFactory : CrudFactory
    {
        CartItemMapper _mapper;

        public CartItemCrudFactory()
        {
            _dao = SqlDao.GetInstance();
            _mapper = new CartItemMapper();
        }

        public void AsignSeatToClient(int idSeat, string ownerName, string ownerMail)
        {
            var sqlOperation = _mapper.GetAsignSeatToClientStatement(idSeat, ownerName, ownerMail);

            _dao.ExecuteProcedure(sqlOperation);
        }

        public void CleanCartItems(int idUser)
        {
            var sqlOperation = _mapper.GetCleanCartItemsStatement(idUser);

            _dao.ExecuteProcedure(sqlOperation);
        }

        public void Create(int IdCart, int IdSector, int Quantity)
        {
            var sqlOperation = _mapper.GetAddStatement(IdCart, IdSector, Quantity);

            _dao.ExecuteProcedure(sqlOperation);
        }

        public override void Create(BaseDTO dto)
        {
            throw new NotImplementedException();
        }

        public override void Delete(BaseDTO dto)
        {
            throw new NotImplementedException();
        }

        public void PayCartItem(int idUser, int idSunpe)
        {
            var sqlOperation = _mapper.GetPayCartItemStatement(idUser,idSunpe);

            _dao.ExecuteProcedure(sqlOperation);
        }

        public override List<T> RetrieveAll<T>()
        {
            throw new NotImplementedException();
        }

        public List<T> RetrieveAllCartItems<T>(int idUser)
        {
            var lstItems = new List<T>();

            var sqlOperation = _mapper.GetRetrieveAllCartItemsStatement(idUser);

            var lstResults = _dao.ExecuteQueryProcedure(sqlOperation);

            if (lstResults.Count > 0)
            {
                var objs = _mapper.BuildObjectsItems(lstResults);

                foreach (var obj in objs)
                {
                    lstItems.Add((T)Convert.ChangeType(obj, typeof(T)));
                }
            }
            return lstItems;

        }

        public override T RetrieveById<T>(BaseDTO dto)
        {
            throw new NotImplementedException();
        }

        public override void Update(BaseDTO dto)
        {
            throw new NotImplementedException();
        }
    }
}
