using AlfaSoft.Domain.Models;
using AlfaSoft.Web.Extensions;

namespace AlfaSoft.Web.Helpers
{
    public class SessionHelper
    {
        public static User User
        {
            get
            {
                if (AppContext.Current == null || AppContext.Current.Session.GetObjectFromJson<User>("User") == null)
                {
                    return new User();
                }

                return AppContext.Current.Session.GetObjectFromJson<User>("User");
            }
            set
            {
                AppContext.Current.Session.SetObjectAsJson("User", value);
            }
        }
    }
}
