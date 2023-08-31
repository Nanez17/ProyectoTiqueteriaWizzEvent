using DTOs;
using MailKit.Net.Smtp;
using MimeKit;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace Core
{
    public class RESTManager
    {
        public async Task sentOTPEmailAsync(string toEmail, string subject, string body)
        {

            try
            {
                var message = new MimeMessage();
                message.From.Add(new MailboxAddress("Wizzevent", "wizzeventoriginal@gmail.com"));
                message.To.Add(new MailboxAddress("", toEmail));
                message.Subject = subject;

                var bodyBuilder = new BodyBuilder();
                bodyBuilder.HtmlBody = body;

                message.Body = bodyBuilder.ToMessageBody();

                using (var client = new SmtpClient())
                {
                    await client.ConnectAsync("smtp.ethereal.email", 587, false); // Replace with your email provider's SMTP server
                    await client.AuthenticateAsync("lesley.von86@ethereal.email", "vDkAmnnss7TAH9M2cH"); // Replace with your email account credentials
                    await client.SendAsync(message);
                    await client.DisconnectAsync(true);
                }

                Console.WriteLine("Email sent successfully!");
            }
            catch (Exception ex)
            {
                // Handle exceptions (e.g., failed to send email)
                Console.WriteLine("Error sending email: " + ex.Message);
            }
        }




        public static async Task PostToApiMessage( string body)
        {
            var url = "https://localhost:7152/api/OTP/GeneratePhone";

            var httpClient = new HttpClient();

            string jsonMessage = JsonConvert.SerializeObject(body);

            var content = new StringContent(jsonMessage, Encoding.UTF8, "application/json");

            var response = await httpClient.PostAsync(url, content);

            if (!response.IsSuccessStatusCode)
            {
                var error = await response.Content.ReadAsStringAsync();
                throw new Exception(error);
            }

        }


        public async Task PostToApiSUNPE(TEF sunpeTransaction)
        {
            var url = "https://sunpe.azurewebsites.net/api/SUNPE/SendTEF";

            var httpClient = new HttpClient();

            // Serializar el objeto usuario a JSON
            string jsonUser = JsonConvert.SerializeObject(sunpeTransaction);

            // Crear el contenido de la solicitud HTTP
            var content = new StringContent(jsonUser, Encoding.UTF8, "application/json");

            var response = await httpClient.PostAsync(url, content);

            if (!response.IsSuccessStatusCode)
            {
                var error = await response.Content.ReadAsStringAsync();
                throw new Exception(error);
            }
        }
    }
}
