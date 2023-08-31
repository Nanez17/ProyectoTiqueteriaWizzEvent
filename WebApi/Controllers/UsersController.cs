using Core;
using DTOs;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create(User user)
        {
            try
            {
                var userManager = new UserManager();
                userManager.Create(user);
                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("CreateGE")]
        public async Task<IActionResult> CreateGE(User user)
        {
            try
            {
                var userManager = new UserManager();
                userManager.CreateGE(user);
                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("Delete")]
        public async Task<IActionResult> Delete(User user)
        {
            try
            {
                var userManager = new UserManager();
                userManager.Delete(user);
                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("Update")]
        public async Task<IActionResult> Update(User user)
        {
            try
            {
                var userManager = new UserManager();
                userManager.Update(user);
                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("UpdatePassword")]
        public async Task<IActionResult> UpdatePassword(string email, string password)
        {
            try
            {
                var userManager = new UserManager();
                userManager.UpdatePassword(email,password);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("RetrieveAll")]
        public async Task<IActionResult> RetrieveAll()
        {
            try
            {
                var userManager = new UserManager();
                var results = userManager.RetrieveAll();
                return Ok(results);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("RetrieveById")]
        public async Task<IActionResult> RetrieveById(int id)
        {
            try
            {
                var user = new User { Id = id };
                var userManager = new UserManager();
                var result = userManager.RetrieveById(user);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("RetrieveByEmail")]
        public async Task<IActionResult> RetrieveByEmail(string email)
        {
            try
            {
               
                var userManager = new UserManager();
                var result = userManager.RetrieveByEmail(email);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        [Route("Login")]
        public async Task<IActionResult> Login(string email, string password)
        {
            try
            {
                var correo = new User { Email = email };
                var contrasenia = new User { Password = password };
                var userManager = new UserManager();
                var result = userManager.RetrieveByEmailAndPassword(email, password);
                return Ok(result);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}