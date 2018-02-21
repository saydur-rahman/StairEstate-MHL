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

namespace StaitEstate.View.Controllers.Sales
{
    public class CustomersController : Controller
    {
        private MHLDB db = new MHLDB();

        // GET: Customers
        public ActionResult Index()
        {
            var sales_customer = db.sales_customer.Include(s => s.hr_employee).Include(s => s.hr_profession).Include(s => s.sales_collector);
            return View(sales_customer.ToList());
        }

        // GET: Customers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            sales_customer sales_customer = db.sales_customer.Find(id);
            if (sales_customer == null)
            {
                return HttpNotFound();
            }
            return View(sales_customer);
        }

        // GET: Customers/Create
        public ActionResult Create()
        {
            ViewBag.customer_sales_person_id = new SelectList(db.hr_employee, "emp_id", "emp_code");
            ViewBag.customer_profession_id = new SelectList(db.hr_profession, "profession_id", "profession_name");
            ViewBag.customer_collector_id = new SelectList(db.sales_collector, "collector_id", "collector_code");
            return View();
        }

        // POST: Customers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "customer_id,customer_code,customer_name,customer_phone,customer_father_or_husband_name,customer_mother_name,customer_permanent_address,customer_present_address,customer_dob,customer_birth_place,customer_collector_id,customer_sales_person_id,customer_profession_id,customer_branch_id,customer_image,deleted")] sales_customer sales_customer)
        {
            if (ModelState.IsValid)
            {
                db.sales_customer.Add(sales_customer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.customer_sales_person_id = new SelectList(db.hr_employee, "emp_id", "emp_code", sales_customer.customer_sales_person_id);
            ViewBag.customer_profession_id = new SelectList(db.hr_profession, "profession_id", "profession_name", sales_customer.customer_profession_id);
            ViewBag.customer_collector_id = new SelectList(db.sales_collector, "collector_id", "collector_code", sales_customer.customer_collector_id);
            return View(sales_customer);
        }

        // GET: Customers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            sales_customer sales_customer = db.sales_customer.Find(id);
            if (sales_customer == null)
            {
                return HttpNotFound();
            }
            ViewBag.customer_sales_person_id = new SelectList(db.hr_employee, "emp_id", "emp_code", sales_customer.customer_sales_person_id);
            ViewBag.customer_profession_id = new SelectList(db.hr_profession, "profession_id", "profession_name", sales_customer.customer_profession_id);
            ViewBag.customer_collector_id = new SelectList(db.sales_collector, "collector_id", "collector_code", sales_customer.customer_collector_id);
            return View(sales_customer);
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "customer_id,customer_code,customer_name,customer_phone,customer_father_or_husband_name,customer_mother_name,customer_permanent_address,customer_present_address,customer_dob,customer_birth_place,customer_collector_id,customer_sales_person_id,customer_profession_id,customer_branch_id,customer_image,deleted")] sales_customer sales_customer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sales_customer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.customer_sales_person_id = new SelectList(db.hr_employee, "emp_id", "emp_code", sales_customer.customer_sales_person_id);
            ViewBag.customer_profession_id = new SelectList(db.hr_profession, "profession_id", "profession_name", sales_customer.customer_profession_id);
            ViewBag.customer_collector_id = new SelectList(db.sales_collector, "collector_id", "collector_code", sales_customer.customer_collector_id);
            return View(sales_customer);
        }

        
    }
}
