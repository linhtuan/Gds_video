using System.Web.Mvc;

namespace Gds.Setting.Authorize
{
    public class CustomAuthorize: AuthorizeAttribute
    {
        public static bool CheckUserLogin()
        {
            var contactId = SessionManager.GetSessionObject(SessionObjectEnum.ContactId);
            return contactId != null;
        }
    }
}
