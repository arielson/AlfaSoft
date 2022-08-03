using AlfaSoft.Application.Interfaces;
using AlfaSoft.Domain.Models;
using AlfaSoft.Web.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;

namespace AlfaSoft.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IContactApplication _contactApplication;

        public IndexModel(ILogger<IndexModel> logger,
            IContactApplication contactApplication)
        {
            _logger = logger;
            _contactApplication = contactApplication;
        }

        public IList<Contact> Contacts { get; set; } = new List<Contact>();

        public void OnGet()
        {
            Contacts = _contactApplication.GetAll().ToList();
        }

        public IActionResult OnPostDelete(long id)
        {
            var contact = _contactApplication.GetById(id);
            contact.UserActionId = SessionHelper.User.Id;
            if (contact != null)
                _contactApplication.Remove(contact);

            return RedirectToPage();
        }
    }
}
