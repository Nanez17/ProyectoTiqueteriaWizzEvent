using Microsoft.AspNetCore.Mvc;
using DTOs.Events;
using Core;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupController : Controller
    {
        [HttpPost]
        [Route("CreateGroup")]
        public async Task<IActionResult> CreateGroup(Group group)
        {
            try
            {
                var um = new GroupManager();
                um.CreateGroup(group);

                return Ok(group);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("RetrieveAllGroups")]
        public async Task<IActionResult> RetrieveAllGroups()
        {
            try
            {
                var mm = new GroupManager();
                var results = mm.RetrieveAllGroup();

                return Ok(results);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("UpdateGroup")]
        public async Task<IActionResult> UpdateGroup(Group group)
        {
            try
            {
                var um = new GroupManager();
                um.UpdateGroup(group);
                return Ok(group);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("DeleteGroup")]
        public async Task<IActionResult> DeleteGroup(Group group)
        {
            try
            {
                var um = new GroupManager();
                um.DeleteGroup(group);
                return Ok(group);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
