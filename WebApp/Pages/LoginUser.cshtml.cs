using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApp.Pages
{
    public class LoginUserModel : PageModel
    {
        private readonly ILogger<LoginUserModel> _logger;

        public LoginUserModel(ILogger<LoginUserModel> logger)
        {
            _logger = logger;
        }
        public void OnGet()
        {
        }
    }
}
