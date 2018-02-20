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

namespace StaitEstate.View.Controllers.Sales
{
    public class CollectorsController : Controller
    {
        private readonly ICollectorService _collectorService;
        private MHLDB db = new MHLDB();


        public CollectorsController(ICollectorService collectorService)
        {
            _collectorService = collectorService;
        }

        // GET: Collectors
        public ActionResult Index()
        {
            return View();
        }

        // GET: Collectors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            sales_collector sales_collector = db.sales_collector.Find(id);
            if (sales_collector == null)
            {
                return HttpNotFound();
            }
            return View(sales_collector);
        }

        // GET: Collectors/Create
        public ActionResult Create()
        {
            ViewBag.collector_sales_person_id = new SelectList(db.hr_employee, "emp_id", "emp_code");
            ViewBag.collector_profession_id = new SelectList(db.hr_profession, "profession_id", "profession_name");
            return View();
        }

        // POST: Collectors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "collector_id,collector_code,collector_phone,collector_father_or_husband_name,collector_mother_name,collector_parmanent_address,collector_present_address,collector_dob,collector_birth_place,collector_name,collector_profession_id,collector_sales_person_id,collector_image,deleted")] sales_collector sales_collector)
        {
            if (ModelState.IsValid)
            {
                db.sales_collector.Add(sales_collector);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.collector_sales_person_id = new SelectList(db.hr_employee, "emp_id", "emp_code", sales_collector.collector_sales_person_id);
            ViewBag.collector_profession_id = new SelectList(db.hr_profession, "profession_id", "profession_name", sales_collector.collector_profession_id);
            return View(sales_collector);
        }

        // GET: Collectors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            sales_collector sales_collector = db.sales_collector.Find(id);
            if (sales_collector == null)
            {
                return HttpNotFound();
            }
            ViewBag.collector_sales_person_id = new SelectList(db.hr_employee, "emp_id", "emp_code", sales_collector.collector_sales_person_id);
            ViewBag.collector_profession_id = new SelectList(db.hr_profession, "profession_id", "profession_name", sales_collector.collector_profession_id);
            return View(sales_collector);
        }

        // POST: Collectors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "collector_id,collector_code,collector_phone,collector_father_or_husband_name,collector_mother_name,collector_parmanent_address,collector_present_address,collector_dob,collector_birth_place,collector_name,collector_profession_id,collector_sales_person_id,collector_image,deleted")] sales_collector sales_collector)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sales_collector).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.collector_sales_person_id = new SelectList(db.hr_employee, "emp_id", "emp_code", sales_collector.collector_sales_person_id);
            ViewBag.collector_profession_id = new SelectList(db.hr_profession, "profession_id", "profession_name", sales_collector.collector_profession_id);
            return View(sales_collector);
        }

        // GET: Collectors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            sales_collector sales_collector = db.sales_collector.Find(id);
            if (sales_collector == null)
            {
                return HttpNotFound();
            }
            return View(sales_collector);
        }

        // POST: Collectors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            sales_collector sales_collector = db.sales_collector.Find(id);
            db.sales_collector.Remove(sales_collector);
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


        //Json
        public JsonResult GetCollectors(int? id = -1)
        {
            if (id != -1)
            {
                var col = _collectorService.GetAll().Where(c => c.deleted != true && c.collector_branch_id == id)
                    .Select(c => new
                    {
                        Id = c.collector_id,
                        Code = c.collector_code,
                        Name = c.collector_name,
                        Phone = c.collector_phone,
                        Father = c.collector_father_or_husband_name,
                        Mother = c.collector_mother_name,
                        AddressPerma = c.collector_parmanent_address,
                        AddressPre = c.collector_present_address,
                        Dob = String.Format("{0:dd/MM/yyyy}", c.collector_dob),
                        BirthPlace = c.collector_birth_place,
                        Image = c.collector_image,
                        Employee = new
                        {
                            Id = c.hr_employee.emp_id,
                            Name = c.hr_employee.emp_name
                        },

                        Branch = new
                        {
                            Id = c.sys_branch.branch_id,
                            Name = c.sys_branch.branch_name
                        },
                        Profession = new
                        {
                            Id = c.hr_profession.profession_id,
                            Name = c.hr_profession.profession_name
                        }


                    });

                return Json(col, JsonRequestBehavior.AllowGet);
            }
            var cols = _collectorService.GetAll().Where(c => c.deleted != true)
                .Select(c => new
                {
                    Id = c.collector_id,
                    Code = c.collector_code,
                    Name = c.collector_name,
                    Phone = c.collector_phone,
                    Father = c.collector_father_or_husband_name,
                    Mother = c.collector_mother_name,
                    AddressPerma = c.collector_parmanent_address,
                    AddressPre = c.collector_present_address,
                    Dob = String.Format("{0:dd/MM/yyyy}", c.collector_dob),
                    BirthPlace = c.collector_birth_place,
                    Image = c.collector_image,
                    Employee = new
                    {
                        Id = c.hr_employee.emp_id,
                        Name = c.hr_employee.emp_name
                    },

                    Branch = new
                    {
                        Id = c.sys_branch.branch_id,
                        Name = c.sys_branch.branch_name
                    },
                    Profession = new
                    {
                        Id = c.hr_profession.profession_id,
                        Name = c.hr_profession.profession_name
                    }


                });

            return Json(cols, JsonRequestBehavior.AllowGet);
        }


    }
}
