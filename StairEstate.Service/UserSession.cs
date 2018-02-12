
using StairEstate.Entity.View_Model;
using System.Web;

namespace StairEstate.Service
{
    public static class UserSession
    {
        
        public static userVm GetUserFromSession()
        {
            return (userVm)HttpContext.Current.Session["LoggedInUser"];
        }

        public static void SetUserFromSession(userVm user)
        {
            HttpContext.Current.Session["LoggedInUser"] = user;
        }

        public static void SetUserFullNameInSession(string name)
        {
            HttpContext.Current.Session["LoggedInUserFullName"] = name;
        }

        public static string GetUserFullNameFromSession()
        {
            return (string)HttpContext.Current.Session["LoggedInUserFullName"];
        }

        public static void DestroySessionAfterUserLogout()
        {
            HttpContext.Current.Session.Clear();
        }

        public static bool IsAdmin()
        {
            var isAdminRole = false;
            if (GetUserFromSession() != null)
            {
                var defaultRoleId = GetUserFromSession().usr_type_id;
                if (defaultRoleId == 1)
                    isAdminRole = true;
            }
            return isAdminRole;
        }

        public static void SetSession(string id)
        {
            HttpContext.Current.Session["LoggedInUser"] = id;
        }

        public static void SetTimeZoneOffset(long offset)
        {
            HttpContext.Current.Session["TimezoneOffset"] = offset;
        }

        public static long GetTimeZoneOffset()
        {
            return (long)HttpContext.Current.Session["TimezoneOffset"];
        }

        public static void SetModuleClicked(string id)
        {
            HttpContext.Current.Session["ModuleId"] = id;
        }

        public static string GetModuleId()
        {
            return (string)HttpContext.Current.Session["ModuleId"];
        }

        public static bool IsAuthorized(string url)
        {
            
            

            return false;
        }
    }
}
