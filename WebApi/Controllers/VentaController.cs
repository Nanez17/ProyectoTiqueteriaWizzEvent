using Core;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class VentaController : Controller
    {
        [HttpGet]
        [Route("RetrieveAllVenta")]
        public async Task<IActionResult> RetrieveAllVenta()
        {
            try
            {
                var mm = new VentaManager();
                var results = mm.RetrieveAllCategories();

                return Ok(results);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }

}
