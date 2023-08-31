using Core;
using DTOs;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartItemController : Controller
    {
        [HttpPost]
        [Route("CreateCartItem")]
        public async Task<IActionResult> CreateCartItem(int IdCart, int IdSector, int Quantity)
        {
            try
            {
                var um = new CartItemManager();
                um.CreateCartItem(IdCart,IdSector,Quantity);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("AsignSeatToClient")]
        public async Task<IActionResult> AsignSeatToClient(int IdSeat, string OwnerName, string OwnerMail)
        {
            try
            {
                var um = new CartItemManager();
                um.AsignSeatToClient(IdSeat, OwnerName, OwnerMail);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("PayCartItem")]
        public async Task<IActionResult> PayCartItem(int idUser, int idSunpe)
        {
            try
            {
                var um = new CartItemManager();
                um.PayCartItem(idUser,idSunpe);

                return Ok(idSunpe);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("RetrieveAllCartItems")]
        public async Task<IActionResult> RetrieveAllCartItems(int IdUser)
        {
            try
            {
                var mm = new CartItemManager();
                var result = mm.RetrieveAllCartItems(IdUser);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



        [HttpDelete]
        [Route("CleanCartItems")]
        public async Task<IActionResult> CleanCartItems(int IdUser)
        {
            try
            {
                var um = new CartItemManager();
                um.CleanCartItems(IdUser);

                return Ok(IdUser);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
