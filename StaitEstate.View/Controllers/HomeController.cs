using System.Web.Mvc;
using StairEstate.Entity;
using StairEstate.Entity.View_Model;
using StairEstate.Service;

namespace StaitEstate.View.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUserService _userService;

        public HomeController(IUserService userService)
        {
            _userService = userService;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }


        public ActionResult Login()
        {
            return View();
        }

        public JsonResult CheckLogin(string username, string password)
        {
            sys_user user = new sys_user();
            user.user_name = username;
            user.user_password = password;
            string chk = string.Empty;
            // user.user_password = this.securityService.GenerateHashWithSalt(password, username);


            sys_user bUser = new sys_user();
            userVm aUser;
            /*
             * After implementing BL
            */
            //bUser = new sys_userService().Authenticatesys_user(user);
            bUser = _userService.ValidateUser(user);


            if (bUser != null)
            {
                aUser = new userVm();
                aUser.branch_id = bUser.branch_id;
                aUser.full_name = bUser.full_name;
                aUser.user_address = bUser.user_address;
                aUser.user_creation = bUser.user_creation;
                aUser.user_email = bUser.user_email;
                aUser.user_id = bUser.user_id;
                aUser.user_name = bUser.user_name;
                aUser.user_password = bUser.user_password;
                aUser.user_phone = bUser.user_phone;
                aUser.usr_type_id = bUser.usr_type_id;


                var urlpath = string.Empty;

                //if (aUser.RoleId != null)
                //{
                //    if (aUser.Role.RoleSubModuleItems.Count() != 0)
                //    {

                //    }
                //    else
                //    {
                //        aUser.Role.RoleSubModuleItems = null;
                //    }
                //}
                //else
                //{
                //    aUser.Role = null;
                //}

                UserSession.SetUserFromSession(aUser);
                //UserSession.SetTimeZoneOffset(timeZoneOffset);
                UserSession.SetUserFullNameInSession(aUser.full_name);

                return Json(new
                {
                    isSuccess = true,
                    Id = aUser.user_id,
                    username = aUser.user_name,
                    fullname = aUser.full_name,
                    usertype = aUser.usr_type_id,
                    userbranch = aUser.branch_id,
                    //url = urlpath,
                    chk = chk
                }, JsonRequestBehavior.AllowGet);


            }

            return Json(new
            {
                isSuccess = false,

            }, JsonRequestBehavior.AllowGet);
        }
    }
}