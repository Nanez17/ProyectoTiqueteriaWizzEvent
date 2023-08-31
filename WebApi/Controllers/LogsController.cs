using Core;
using DTOs;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogsController : Controller
    {
     
            [HttpGet]
            [Route("RetrieveAll")]
            public async Task<IActionResult> RetrieveAll()
            {
                try
                {
                    var lm = new LogsManager();

                    var results = lm.RetrieveAll();

                    return Ok(results);
                }
                catch (Exception ex) { return BadRequest(ex.Message); }

            }

            [HttpGet]
            [Route("RetrieveById")]
            public async Task<IActionResult> RetrieveById(int id)
            {
                try
                {
                    var log = new Logs { Id = id };
                var lm = new LogsManager();

                var results = lm.RetrieveByID(log);

                return Ok(results);
                }
                catch (Exception ex) { return BadRequest(ex.Message); }

            }
        
    }
}
