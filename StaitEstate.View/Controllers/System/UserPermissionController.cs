using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json.Serialization;
using StairEstate.Entity;
using StairEstate.Entity.View_Model;
using StairEstate.Service;

namespace StaitEstate.View.Controllers.System
{

    [RoutePrefix("System/UserPermission")]
    public class UserPermissionController : Controller
    {
        private readonly IUserTypeService _userTypeService;
        private readonly IUserMenuAccessService _userMenuAccessService;

        private readonly IMenuService _menuService;

        public UserPermissionController(IUserTypeService userTypeService, IUserMenuAccessService userMenuAccessService, IMenuService menuService)
        {
            _userTypeService = userTypeService;
            _userMenuAccessService = userMenuAccessService;
            _menuService = menuService;
        }


        // GET: UserPermission
        [Route("Index")]
        public ActionResult Index()
        {
            //if (!_userService.AuthorizedUser("system/userpermission/index"))
            //{
            //    return Content(unAuthorized);
            //}
            var userTypesList = new List<SelectListItem>();
            var userTypes = _userTypeService.GetAll();

            foreach (var ut in userTypes)
            {
                userTypesList.Add(new SelectListItem()
                {
                    Value = ut.usr_type_Id.ToString(), 
                    Text = ut.type_name
                });
            }

            ViewBag.UT = userTypesList;

            return View();
        }
        
        

        [Route("Delete/{mId?}/{uId?}")]
        public ActionResult Delete(int? mId, int? uId)
        {
            if (mId == null && uId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            

            ViewBag.UserType = _userTypeService.GetById(uId).type_name;
            var menu = _menuService.GetById(mId);

            if (menu == null)
            {
                return HttpNotFound();
            }
            return View(menu);
        }

        [Route("Delete/{mId?}/{uId?}")]
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int? mId, int? uId)
        {
            var a = _userMenuAccessService.GetAll()
                .Where(m => m.menu_id == mId && m.usr_type_id == uId).SingleOrDefault();

            _userMenuAccessService.Delete(a);



            return RedirectToAction("Index");
        }


        [Route("GetAllUserTypes")]
        public JsonResult GetAllUserTypes()
        {
            
            var a = _userTypeService.GetAll();
            List<UserTypeVM> list = new List<UserTypeVM>();


            foreach (var ut in a)
            {
                list.Add(new UserTypeVM(ut));
            }

            return Json(list, JsonRequestBehavior.AllowGet);
        }
        [Route("AddAccess/{id}")]
        public ActionResult AddAccess(string id)
        {
            int x = Int32.Parse(id);
            

            var userMenu = _userMenuAccessService.GetAll().Where(u => u.usr_type_id == x).Select(u => u.menu_id);

            var menus = _menuService.GetAll().Where(m => !userMenu.Contains(m.menu_id));


            var menusList = new List<SelectListItem>();

            foreach (var m in menus)
            {
                menusList.Add(
                    new SelectListItem()
                    {
                        Value = m.menu_id.ToString(),
                        Text = m.menu_name
                    }
                );
            }

            ViewBag.MenusList = menusList;
            ViewBag.UserType = _userTypeService.GetById(x).type_name;

            ViewBag.UserTypeId = x;
           

            return View();
        }

        [Route("AddAccess/{id?}")]
        [HttpPost]
        public ActionResult AddAccess(string UserTypeId, string MenuId)
        {

            try
            {

                int ut = Int32.Parse(UserTypeId);
                int m = Int32.Parse(MenuId);

                _userMenuAccessService.Create(
                    new sys_user_menu_access()
                    {
                        menu_id = m,
                        usr_type_id = ut
                    }
                 );

                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return RedirectToAction("Index");
            }
        }



        [Route("GetMenuForUser/{id?}")]
        public JsonResult GetMenuForUser(int id)
        {
            try
            {
                if(id == -1)
                {
                    return Json(_menuService.GetAll(), JsonRequestBehavior.AllowGet);
                }


                var userType = _userTypeService.GetById(id);
                var userMenu = _userMenuAccessService.GetAll().Where(u => u.usr_type_id == id).Select(x => x.menu_id).ToList();

                var menus = _menuService.GetAll().Where(m => userMenu.Contains(m.menu_id));

                


                return Json(menus, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(e, JsonRequestBehavior.DenyGet);
            }
        }
    }
}