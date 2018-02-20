﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using StairEstate.Data;
using StairEstate.Entity;

namespace StaitEstate.View.Controllers.Sales
{
    public class hr_employeeDemoController : Controller
    {
        private MHLDB db = new MHLDB();

        // GET: hr_employeeDemo
        public ActionResult Index()
        {
            var hr_employee = db.hr_employee.Include(h => h.hr_employee_type).Include(h => h.sys_branch);
            return View(hr_employee.ToList());
        }

        // GET: hr_employeeDemo/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            hr_employee hr_employee = db.hr_employee.Find(id);
            if (hr_employee == null)
            {
                return HttpNotFound();
            }
            return View(hr_employee);
        }

        // GET: hr_employeeDemo/Create
        public ActionResult Create()
        {
            ViewBag.emp_type_id = new SelectList(db.hr_employee_type, "emp_type_id", "emp_type_name");
            ViewBag.emp_branch_id = new SelectList(db.sys_branch, "branch_id", "branch_name");
            return View();
        }

        // POST: hr_employeeDemo/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "emp_id,emp_code,emp_name,emp_email,emp_phone,emp_father_or_husband_name,emp_mother_name,emp_permanent_address,emp_present_address,emp_dob,emp_birth_place,emp_type_id,emp_branch_id,emp_image,deleted")] hr_employee hr_employee)
        {
            if (ModelState.IsValid)
            {
                db.hr_employee.Add(hr_employee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.emp_type_id = new SelectList(db.hr_employee_type, "emp_type_id", "emp_type_name", hr_employee.emp_type_id);
            ViewBag.emp_branch_id = new SelectList(db.sys_branch, "branch_id", "branch_name", hr_employee.emp_branch_id);
            return View(hr_employee);
        }

        // GET: hr_employeeDemo/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            hr_employee hr_employee = db.hr_employee.Find(id);
            if (hr_employee == null)
            {
                return HttpNotFound();
            }
            ViewBag.emp_type_id = new SelectList(db.hr_employee_type, "emp_type_id", "emp_type_name", hr_employee.emp_type_id);
            ViewBag.emp_branch_id = new SelectList(db.sys_branch, "branch_id", "branch_name", hr_employee.emp_branch_id);
            return View(hr_employee);
        }

        // POST: hr_employeeDemo/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "emp_id,emp_code,emp_name,emp_email,emp_phone,emp_father_or_husband_name,emp_mother_name,emp_permanent_address,emp_present_address,emp_dob,emp_birth_place,emp_type_id,emp_branch_id,emp_image,deleted")] hr_employee hr_employee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hr_employee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.emp_type_id = new SelectList(db.hr_employee_type, "emp_type_id", "emp_type_name", hr_employee.emp_type_id);
            ViewBag.emp_branch_id = new SelectList(db.sys_branch, "branch_id", "branch_name", hr_employee.emp_branch_id);
            return View(hr_employee);
        }

        // GET: hr_employeeDemo/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            hr_employee hr_employee = db.hr_employee.Find(id);
            if (hr_employee == null)
            {
                return HttpNotFound();
            }
            return View(hr_employee);
        }

        // POST: hr_employeeDemo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            hr_employee hr_employee = db.hr_employee.Find(id);
            db.hr_employee.Remove(hr_employee);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
