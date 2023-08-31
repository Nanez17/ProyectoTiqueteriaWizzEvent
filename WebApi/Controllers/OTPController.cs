using Core;
using DTOs;
using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;

namespace WebApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OTPController : ControllerBase
    {
        [HttpPost("GenerateEmail")]
        public IActionResult GenerateOTPEmail(string email)
        {
           
            var om = new OTPManager(); 
            var otp =OTPManager.GenerateOTP(6);
            om.CreateOTPEmail(email,otp);
               return Ok(otp);

        }
        [HttpPost("GeneratePhone")]
        public IActionResult GenerateOTPPhone(string phone)
        {
        
            var om = new OTPManager();
            var otp = OTPManager.GenerateOTP(6);
            
            om.SentOTPPhone(phone, otp);
            return Ok(otp);

        }

    }
}