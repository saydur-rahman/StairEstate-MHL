using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using StairEstate.Data;
using StairEstate.Entity;
using StairEstate.Service;

namespace StaitEstate.View.Controllers.System
{

    /*
     * Route has to configured
     * System/Usertype
     */
    [RoutePrefix("Dashboard/System/UserTypes")]
    public class UserTypeController : Controller
    {

        private readonly IUserTypeService _userTypeService;
        private readonly IUserService _userService;

        private readonly string unAuthorized = "You are not authorized!";

        public UserTypeController(IUserTypeService userTypeService, IUserService userService)
        {
            _userTypeService = userTypeService;
            _userService = userService;
        }

        // GET: sys_user_type
        [Route("Index")]
        public ActionResult Index()
        {
            if (!_userService.AuthorizedUser("system/usertypes/index"))
            {
                return Content(unAuthorized);
            }
            return View(_userTypeService.GetAll());
        }

        // GET: sys_user_type/Details/5
        [Route("Details")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            sys_user_type sys_user_type = _userTypeService.GetById(id);
            if (sys_user_type == null)
            {
                return HttpNotFound();
            }
            return View(sys_user_type);
        }

        // GET: sys_user_type/Create
        [Route("Create")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: sys_user_type/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "usr_type_Id,type_name,description")] sys_user_type sys_user_type)
        {
            if (ModelState.IsValid)
            {
                _userTypeService.Create(sys_user_type);
                return RedirectToAction("Index");
            }

            return View(sys_user_type);
        }

        // GET: sys_user_type/Edit/5
        [Route("Edit/{id}")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            sys_user_type sys_user_type = _userTypeService.GetById(id);
            if (sys_user_type == null)
            {
                return HttpNotFound();
            }
            return View(sys_user_type);
        }

        // POST: sys_user_type/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "usr_type_Id,type_name,description")] sys_user_type sys_user_type)
        {
            if (ModelState.IsValid)
            {
                _userTypeService.Edit(sys_user_type);
                return RedirectToAction("Index");
            }
            return View(sys_user_type);
        }

        // GET: sys_user_type/Delete/5
        [Route("Delete/{id}")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            sys_user_type sys_user_type = _userTypeService.GetById(id);
            if (sys_user_type == null)
            {
                return HttpNotFound();
            }
            return View(sys_user_type);
        }

        // POST: sys_user_type/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _userTypeService.Delete(id);
            return RedirectToAction("Index");
        }
        
    }
}
