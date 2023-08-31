using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApp.Pages
{
    public class OTPModel : PageModel
    {
        private readonly ILogger<OTPModel> _logger;

        public OTPModel(ILogger<OTPModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }

        public int UserId { get; set; }
    }
}
