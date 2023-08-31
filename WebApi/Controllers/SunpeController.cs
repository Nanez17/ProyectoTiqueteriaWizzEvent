using Core;
using DTOs;
using DTOs.Events;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SunpeController : Controller
    {
        [HttpPost]
        [Route("PaySunpeTransaction")]
        public async Task<IActionResult> PaySunpeTransaction(TEF sunpeTransaction)
        {
            try
            {
                /*var mm = new RESTManager();
                var result = mm.PostToApiSUNPE(sunpeTransaction);*/

                var um = new SunpeManager();
                um.PaySunpeTransaction(sunpeTransaction);

                return Ok(sunpeTransaction);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("RetrieveIdSunpe")]
        public async Task<IActionResult> RetrieveIdSunpe(string transactionId)
        {
            try
            {
                var mm = new SunpeManager();
                var result = mm.RetrieveIdSunpe(transactionId);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
