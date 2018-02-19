using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using StairEstate.Data;
using StairEstate.Entity;
using StairEstate.Service;

namespace StaitEstate.View.Controllers.Sales
{
    public class EmployeesController : Controller
    {
        private readonly IEmployeeService _employeeService;
        private MHLDB db = new MHLDB();

        public EmployeesController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        // GET: Employees
        public ActionResult Index()
        {
            var hr_employee = _employeeService.GetAll();
            return View(hr_employee.ToList());
        }

        // GET: Employees/Details/5
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

        // GET: Employees/Create
        [Route("create/{id?}")]
        public ActionResult Create(int id)
        {
            ViewBag.emp_type_id = new SelectList(db.hr_employee_type, "emp_type_id", "emp_type_name");
            ViewBag.emp_branch_id = new SelectList(db.sys_branch, "branch_id", "branch_name");
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "emp_id,emp_code,emp_name,emp_phone,emp_father_or_husband_name,emp_mother_name,emp_permanent_address,emp_present_address,emp_dob,emp_birth_place,emp_type_id,emp_branch_id,emp_image,deleted")] hr_employee hr_employee)
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

        // GET: Employees/Edit/5
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

        // POST: Employees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "emp_id,emp_code,emp_name,emp_phone,emp_father_or_husband_name,emp_mother_name,emp_permanent_address,emp_present_address,emp_dob,emp_birth_place,emp_type_id,emp_branch_id,emp_image,deleted")] hr_employee hr_employee)
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

        // GET: Employees/Delete/5
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

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            hr_employee hr_employee = db.hr_employee.Find(id);
            db.hr_employee.Remove(hr_employee);
            db.SaveChanges();
            return RedirectToAction("Index");
        }



        //Json
        public JsonResult GetEmp(int? id = -1)
        {
            if (id != -1)
            {
                var emps = _employeeService.GetAll().Where(e => e.deleted != true && e.emp_branch_id == id).Select(e => new
                {
                    Id = e.emp_id,
                    Code = e.emp_code,
                    Name = e.emp_name,
                    Email=  e.emp_email,
                    Phone = e.emp_phone,
                    Father = e.emp_father_or_husband_name,
                    Mother = e.emp_mother_name,
                    AddressPerma = e.emp_permanent_address,
                    AddressPre = e.emp_present_address,
                    Dob = String.Format("{0:dd/MM/yyyy}", e.emp_dob),
                    BirthPlace = e.emp_birth_place,
                    Image = e.emp_image,
                    EmployeeType = new
                    {
                        Id = e.hr_employee_type.emp_type_id,
                        Name = e.hr_employee_type.emp_type_name
                    },
                    Branch = new
                    {
                        Id = e.sys_branch.branch_id,
                        Name = e.sys_branch.branch_name
                    },

                });

                return Json(emps, JsonRequestBehavior.AllowGet);
            }

            var emp = _employeeService.GetAll().Where(e => (e.deleted != true)).Select(e => new
            {
                Id = e.emp_id,
                Code = e.emp_code,
                Name = e.emp_name,
                Email = e.emp_email,
                Phone = e.emp_phone,
                Father = e.emp_father_or_husband_name,
                Mother = e.emp_mother_name,
                AddressPerma = e.emp_permanent_address,
                AddressPre = e.emp_present_address,
                Dob = String.Format("{0:dd/MM/yyyy}", e.emp_dob),
                BirthPlace = e.emp_birth_place,
                Image = e.emp_image,
                EmployeeType = new
                {
                    Id = e.hr_employee_type.emp_type_id,
                    Name = e.hr_employee_type.emp_type_name
                },
                Branch = new
                {
                    Id = e.sys_branch.branch_id,
                    Name = e.sys_branch.branch_name
                },

            });

            return Json(emp, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetEmpById(int id)
        {
            try
            {
                var e = _employeeService.GetById(id);
                if (e.deleted != true || e != null)
                {
                    var emp = new
                    {
                        Id = e.emp_id,
                        Code = e.emp_code,
                        Name = e.emp_name,
                        Email = e.emp_email,
                        Phone = e.emp_phone,
                        Father = e.emp_father_or_husband_name,
                        Mother = e.emp_mother_name,
                        AddressPerma = e.emp_permanent_address,
                        AddressPre = e.emp_present_address,
                        Dob = String.Format("{0:dd/MM/yyyy}", e.emp_dob),
                        BirthPlace = e.emp_birth_place,
                        Image = e.emp_image,
                        EmployeeType = new
                        {
                            Id = e.hr_employee_type.emp_type_id,
                            Name = e.hr_employee_type.emp_type_name
                        },
                        Branch = new
                        {
                            Id = e.sys_branch.branch_id,
                            Name = e.sys_branch.branch_name
                        },

                    };
                    return Json(emp, JsonRequestBehavior.AllowGet);
                }

                return Json(new
                {
                    isSuccessful = false
                }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception exception)
            {
                return Json(new
                {
                    isSuccessful = false
                }, JsonRequestBehavior.AllowGet);
            }
            
        }
    }
}
