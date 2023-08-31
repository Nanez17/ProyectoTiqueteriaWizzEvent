using Core;
using DTOs.Events;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : Controller
    {
        [HttpPost]
        [Route("CreateCategory")]
        public async Task<IActionResult> CreateCategory(Category category)
        {
            try
            {
                var um = new CategoryManager();
                um.CreateCategory(category);

                return Ok(category);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("RetrieveAllCategory")]
        public async Task<IActionResult> RetrieveAllCategory()
        {
            try
            {
                var mm = new CategoryManager();
                var results = mm.RetrieveAllCategories();

                return Ok(results);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("UpdateCategory")]
        public async Task<IActionResult> UpdateCategory(Category category)
        {
            try
            {
                var um = new CategoryManager();
                um.UpdateCategory(category);

                return Ok(category);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("DeleteCategory")]
        public async Task<IActionResult> DeleteCategory(Category category)
        {
            try
            {
                var um = new CategoryManager();
                um.DeleteCategory(category);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}
