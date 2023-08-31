using Core;
using DTOs;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingCartController : Controller
    {
        [HttpPost]
        [Route("CreateShoppingCart")]
        public async Task<IActionResult> CreateShoppingCart(ShoppingCart shoppingCart)
        {
            try
            {
                var um = new ShoppingCartManager();
                um.CreateShoppingCart(shoppingCart);

                return Ok(shoppingCart);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("RetrieveCantCartItems")]
        public async Task<IActionResult> RetrieveCantCartItems(int idUser)
        {
            try
            {
                var mm = new ShoppingCartManager();
                var results = mm.RetrieveCantCartItems(idUser);

                return Ok(results);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
