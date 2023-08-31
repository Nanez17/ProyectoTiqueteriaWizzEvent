using DataAccess.CRUD;
using DTOs;
using Org.BouncyCastle.Asn1.X509;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class CartItemManager
    {
        public void AsignSeatToClient(int idSeat, string ownerName, string ownerMail)
        {
            var crud = new CartItemCrudFactory();
            crud.AsignSeatToClient(idSeat, ownerName, ownerMail);
        }

        public void CleanCartItems(int idUser)
        {
            var crud = new CartItemCrudFactory();
            crud.CleanCartItems(idUser);
        }

        public void CreateCartItem(int IdCart, int IdSector, int Quantity)
        {
            var crud = new CartItemCrudFactory();
            crud.Create(IdCart, IdSector, Quantity);
        }

        public void PayCartItem(int idUser, int idSunpe)
        {
            var crud = new CartItemCrudFactory();
            crud.PayCartItem(idUser, idSunpe);
        }

        public List<CartItem> RetrieveAllCartItems(int idUser)
        {
            var crud = new CartItemCrudFactory();
            return crud.RetrieveAllCartItems<CartItem>(idUser);
        }
    }
}
