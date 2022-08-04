using AlfaSoft.Application.Interfaces;
using AlfaSoft.Domain.Models;
using AlfaSoft.Web.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AlfaSoft.Web.Pages
{
    public class ItemModel : PageModel
    {
        [BindProperty]
        public Contact Contact { get; set; }

        private readonly IContactApplication _contactApplication;

        public ItemModel(IContactApplication contactApplication)
        {
            _contactApplication = contactApplication;
        }

        public IActionResult OnGet(long? id)
        {
            if (SessionHelper.User.Id == 0)
                return RedirectToPage("./Login");

            if (id.HasValue)
                Contact = _contactApplication.GetById(id.Value);

            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Contact.UserActionId = SessionHelper.User.Id;
            if (Contact != null)
            {
                if (Contact.Id > 0)
                    _contactApplication.Update(Contact);
                else
                    _contactApplication.Add(Contact);
            }

            return RedirectToPage("./Index");
        }
    }
}
