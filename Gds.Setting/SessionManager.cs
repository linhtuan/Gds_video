using System.Web;

namespace Gds.Setting
{
    public static class SessionManager
    {
        public static void Dispose()
        {
            HttpContext.Current.Session.Clear();
            HttpContext.Current.Session.Abandon();
        }

        public static object GetSessionObject(SessionObjectEnum key)
        {
            if (HttpContext.Current.Session == null || HttpContext.Current.Session[key.ToString()] == null) return null;
            return HttpContext.Current.Session[key.ToString()];
        }

        public static string SessionId()
        {
            return HttpContext.Current.Session.SessionID;
        }

        public static void Remove(SessionObjectEnum key)
        {
            if (HttpContext.Current.Session[key.ToString()] == null) return;
            HttpContext.Current.Session.Remove(key.ToString());
        }

        public static void SetSessionObject(SessionObjectEnum key, object value)
        {
            if (HttpContext.Current.Session[key.ToString()] != null) Remove(key);
            HttpContext.Current.Session.Add(key.ToString(), value);
        }
    }

    public enum SessionObjectEnum
    {
        Categorys,
        SecurityCode,
        TokenUser,
        ContactId,
        ContactFullName,
        ContactImage,
    }
}
