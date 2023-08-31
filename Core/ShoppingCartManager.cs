using DataAccess.CRUD;
using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class ShoppingCartManager
    {
        public ShoppingCartManager() { }

        public void CreateShoppingCart(ShoppingCart shoppingCart)
        {
            var crud = new ShoppingCartCrudFactory();
            crud.Create(shoppingCart);
        }

        public int RetrieveCantCartItems(int idUser)
        {
            var crud = new ShoppingCartCrudFactory();
            return crud.RetrieveCantCartItems(idUser);
        }
    }
}
