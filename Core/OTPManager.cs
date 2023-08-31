using DataAccess.CRUD;
using DTOs;
using System;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using MimeKit;
using System.Net.Mail;
using SmtpClient = MailKit.Net.Smtp.SmtpClient;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using Twilio.Rest.Api.V2010.Account;
using Twilio;

namespace Core
{
    public class OTPManager
    {
        public void CreateOTPEmail(string email, string otp)
        {
          
            string recipientEmail = "recipient@example.com"; // Replace with the recipient's email address
            string emailSubject = "Wizzevent OTP(One-time password)";
            string emailBody = "Su OTP es el siguiente: " + otp;

            var emailRecipient = email;

            var rm = new RESTManager();
            Task task = rm.sentOTPEmailAsync(emailRecipient,emailSubject,emailBody);



        }

        public void SentOTPPhone(string phone, string otp)
        {
            string accountSid = "AC70f6e9809ae0988780b12f1cc58099ba";
            string authToken = "1ab5166f1d5007209215ec307605e707";
            TwilioClient.Init(accountSid, authToken);

            var message = MessageResource.Create(
            body: "Hola, bienvenido a Wizzevent " +
            ""+"Su OTP es es siguiente: " +otp,
            from: new Twilio.Types.PhoneNumber("+12179879689"),
            to: new Twilio.Types.PhoneNumber("+506" + "87269583")
            );
        }

       
        public static string GenerateOTP(int length)
        {
            const string allowedChars = "0123456789";
            using (var rng = new RNGCryptoServiceProvider())
            {
                byte[] otpBytes = new byte[length];
                rng.GetBytes(otpBytes);

                var otp = new char[length];
                for (int i = 0; i < length; i++)
                {
                    otp[i] = allowedChars[otpBytes[i] % allowedChars.Length];
                }

                return new string(otp);
            }
        }
    }


        
           
 
}




