using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using StairEstate.Data;
using StairEstate.Entity;
using StairEstate.Service;

namespace StaitEstate.View.Controllers.System
{
    [RoutePrefix("System/Users")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly IBranchService _branchService;
        private readonly ICountryService _countryService;
        private readonly IUserTypeService _userTypeService;

        public UserController(IUserService userService, IBranchService branchService, ICountryService countryService, IUserTypeService userTypeService)
        {
            _userService = userService;
            _branchService = branchService;
            _countryService = countryService;
            _userTypeService = userTypeService;
        }


        // GET: User
        [Route("Index")]
        public ActionResult Index()
        {
            return View();
        }

        [Route("GetCountry")]
        public JsonResult GetCountry()
        {
            var countries = _countryService.GetAll().Select(c => new
            {
                Id = c.id,
                Name = c.name
            });

            return Json(countries, JsonRequestBehavior.AllowGet);
        }

        [Route("GetBranch/{id}")]
        public JsonResult GetBranch(int id)
        {
            var branches = _branchService.GetAll().Where(b => b.country == id).
                Select(b => new
                {
                    Id = b.branch_id,
                    Name = b.branch_name
                });

            return Json(branches, JsonRequestBehavior.AllowGet);
        }

        [Route("GetUsers/{id}")]
        public JsonResult GetUsers(int id)
        {
            var users = _userService.GetAll().Where(u => u.branch_id == id && u.user_id != 1).Select(u => new
            {
                Id = u.user_id,
                Username = u.user_name,
                Fullname = u.full_name,
                Password = u.user_password,
                Email = u.user_email,
                Phone = u.user_phone,
                Address = u.user_address,
                Date = String.Format("{0:dd/MM/yyyy}", u.user_creation),
                Usertype = u.sys_user_type.type_name,
                Branch = u.sys_branch.branch_name
            });

            return Json(users, JsonRequestBehavior.AllowGet);
        }

        // GET: User/Details/5
        [Route("Details/{id}")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            sys_user sys_user = _userService.GetById(id);
            if (sys_user == null)
            {
                return HttpNotFound();
            }
            return View(sys_user);
        }

        // GET: User/Create
        [Route("Create/{branchId?}")]
        public ActionResult Create(int branchId)
        {
            ViewBag.usr_type_id = new SelectList(_userTypeService.GetAll(), "usr_type_Id", "type_name");
            return View();
        }

        // POST: User/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Create/{branchId?}")]
        public ActionResult Create(sys_user user, int branchId)
        {
            if (ModelState.IsValid)
            {
                user.user_creation = DateTime.Now;
                user.branch_id = branchId;


                _userService.Create(user);
                return RedirectToAction("Index");
            }

            
            ViewBag.usr_type_id = new SelectList(_userTypeService.GetAll(), "usr_type_Id", "type_name", user.usr_type_id);
            return View(user);
        }

        // GET: User/Edit/5
        [Route("Edit/{id}")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            sys_user sys_user = _userService.GetById(id);
            if (sys_user == null)
            {
                return HttpNotFound();
            }
            ViewBag.branch_id = new SelectList(_branchService.GetAll(), "branch_id", "branch_name", sys_user.branch_id);
            ViewBag.usr_type_id = new SelectList(_userTypeService.GetAll(), "usr_type_Id", "type_name", sys_user.usr_type_id);
            return View(sys_user);
        }

        // POST: User/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Edit/{id}")]
        public ActionResult Edit([Bind(Include = "user_id,user_name,user_password,user_email,user_phone,user_address,full_name,usr_type_id,branch_id")] sys_user user)
        {
            if (ModelState.IsValid)
            {
                var a = _userService.GetById(user.user_id);
                user.user_name = a.user_name;

                _userService.Edit(user);
                return RedirectToAction("Index");
            }
            ViewBag.branch_id = new SelectList(_branchService.GetAll(), "branch_id", "branch_name", user.branch_id);
            ViewBag.usr_type_id = new SelectList(_userTypeService.GetAll(), "usr_type_Id", "type_name", user.usr_type_id);
            return View(user);
        }

        // GET: User/Delete/5
        [Route("Delete/{id?}")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            sys_user sys_user = _userService.GetById(id);
            if (sys_user == null)
            {
                return HttpNotFound();
            }
            ViewBag.branch_id = new SelectList(_branchService.GetAll(), "branch_id", "branch_name", sys_user.branch_id);
            ViewBag.usr_type_id = new SelectList(_userTypeService.GetAll(), "usr_type_Id", "type_name", sys_user.usr_type_id);
            return View(sys_user);
        }

        // POST: User/Delete/5
        [HttpPost, ActionName("Delete")]
        [Route("Delete/{id?}")]
        public ActionResult DeleteConfirmed(int id)
        {
            
            _userService.Delete(id);

            return RedirectToAction("Index");
        }
    }
}
