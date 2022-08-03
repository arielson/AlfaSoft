using AlfaSoft.Application.Interfaces;
using AlfaSoft.Domain.Models;
using AlfaSoft.Web.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AlfaSoft.Web.Pages
{
    public class LoginModel : PageModel
    {
        private readonly IUserApplication _userApplication;

        [BindProperty]
        public new User User { get; set; }

        public LoginModel(IUserApplication userApplication)
        {
            _userApplication = userApplication;
        }

        public void OnGet()
        {
            SessionHelper.User = null;
        }

        public IActionResult OnPostAsync()
        {
            var user = _userApplication.GetByLoginAndPassword(User.Login, User.Password);
            if (user == null)
                return RedirectToPage("./UserFailed");

            SessionHelper.User = user;

            return RedirectToPage("./Index");
        }
    }
}
