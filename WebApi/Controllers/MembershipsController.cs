using Core;
using DTOs;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class MembershipsController : ControllerBase
    {
        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create(Memberships membership)
        {
            try
            {
                var mm = new MembershipManager();
                mm.Create(membership);
                return Ok(membership);          
            }
            catch (Exception ex) { return BadRequest(ex.Message); }


        }
        [HttpDelete]
        [Route("Delete")]
        public async Task<IActionResult> Delete(Memberships membership)
        {
            try
            {

                var mm = new MembershipManager();

                mm.Delete(membership);

                return Ok(membership);
            }
            catch (Exception ex) { return BadRequest(ex.Message); }

        }

        [HttpPut]
        [Route("Update")]
        public async Task<IActionResult> Update(Memberships membership)
        {
            try
            {

                var mm = new MembershipManager();

                mm.Update(membership);

                return Ok(membership);
            }
            catch (Exception ex) { return BadRequest(ex.Message); }

        }

        [HttpGet]
        [Route("RetrieveAll")]
        public async Task<IActionResult> RetrieveAll()
        {
            try
            {
                var mm = new MembershipManager();

                var results = mm.RetrieveAll();

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
                var membership = new Memberships { Id = id };
                var mm = new MembershipManager();

                var result = mm.RetrieveByID(membership);

                return Ok(result);
            }
            catch (Exception ex) { return BadRequest(ex.Message); }

        }

    }
}
