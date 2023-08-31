using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApp.Pages
{
    public class CreateUserGEModel : PageModel
    {
        private readonly ILogger<CreateUserModel> _logger;

        public CreateUserGEModel(ILogger<CreateUserModel> logger)
        {
            _logger = logger;
        }
        public void OnGet()
        {
        }
    }
}
