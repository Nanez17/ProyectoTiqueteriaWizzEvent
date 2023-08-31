using Core;
using DTOs;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : Controller
    {
        [HttpGet]
        [Route("RetrieveByID")]
        public async Task<IActionResult> RetrieveByID(int id)
        {
            try
            {
                var rol = new Roles { Id = id };
                var userManager = new RoleManager();
                var result = userManager.RetrieveById(rol);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
