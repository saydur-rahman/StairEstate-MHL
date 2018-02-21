using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using StairEstate.Data;
using StairEstate.Entity;
using StairEstate.Service;

namespace StaitEstate.View.Controllers.Sales
{
    [RoutePrefix("sales/collectors")]
    public class CollectorsController : Controller
    {
        private readonly ICollectorService _collectorService;
        private readonly IEmployeeService _employeeService;
        private readonly IProfessionService _professionService;
        private readonly IBranchService _branchService;


        public CollectorsController(ICollectorService collectorService, IEmployeeService employeeService, IProfessionService professionService, IBranchService branchService)
        {
            _collectorService = collectorService;
            _employeeService = employeeService;
            _professionService = professionService;
            _branchService = branchService;
        }

        // GET: Collectors
        [Route("index")]
        public ActionResult Index()
        {
            return View();
        }

        // GET: Collectors/Details/5
        [Route("Details/{id?}")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            sales_collector sales_collector = _collectorService.GetById(id);
            if (sales_collector == null)
            {
                return HttpNotFound();
            }

            ViewBag.collector_sales_person_id = new SelectList(_employeeService.GetAll().Where(e => e.deleted != true), "emp_id", "emp_code");
            ViewBag.collector_profession_id = new SelectList(_professionService.GetAll().Where(e => e.deleted != true), "profession_id", "profession_name");
            ViewBag.collector_branch_id = new SelectList(_branchService.GetAll(), "branch_id", "branch_name");

            return View(sales_collector);
        }

        // GET: Collectors/Create
        [Route("create/{branchId?}")]
        public ActionResult Create(int branchId)
        {
            //ViewBag.collector_sales_person_id = new SelectList(_employeeService.GetAll().Where(e => e.emp_branch_id == branchId), "emp_id", "emp_code");
            //ViewBag.collector_profession_id = new SelectList(_professionService.GetAll().OrderBy(p => p.profession_presidences), "profession_id", "profession_name");
            ViewBag.SP = _employeeService.GetAll().Where(e => e.emp_branch_id == branchId && e.deleted != true);
            ViewBag.Professions = _professionService.GetAll().OrderBy(p => p.profession_presidences);
            return View();
        }

        // POST: Collectors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("create/{branchId?}")]
        public ActionResult Create(sales_collector model, int branchId, string profession, string employee, HttpPostedFileBase imageFile)
        {
            if (ModelState.IsValid)
            {
                model.collector_branch_id = branchId;


                var pro = (hr_profession)_professionService.GetAll().Where(p => p.profession_name.Contains(profession)).SingleOrDefault();
                if (pro != null)
                {
                    model.collector_profession_id = pro.profession_id;
                }
                else
                {
                    _professionService.Create(new hr_profession()
                    {
                        profession_name = profession,
                    });
                    pro = (hr_profession)_professionService.GetAll().Where(p => p.profession_name.Contains(profession)).SingleOrDefault();

                    model.collector_profession_id = pro.profession_id;
                }

                var sal = (hr_employee)_employeeService.GetAll().Where(e => e.emp_code.Contains(employee))
                    .SingleOrDefault();
                if (sal != null)
                {
                    model.collector_sales_person_id = sal.emp_id;
                }

                else
                {
                    ModelState.AddModelError(string.Empty, "Sales Person Code not correct!");
                    ViewBag.SP = _employeeService.GetAll().Where(e => e.emp_branch_id == branchId && e.deleted != true);
                    ViewBag.Professions = _professionService.GetAll().OrderBy(p => p.profession_presidences);
                    return View(model);
                }

                string extension = Path.GetExtension(imageFile.FileName);
                if (!(extension.Equals(".jpg") || extension.Equals(".JPG")))
                {
                    ModelState.AddModelError(string.Empty, "Not an accepted image type!");
                    ViewBag.SP = _employeeService.GetAll().Where(e => e.emp_branch_id == branchId && e.deleted != true);
                    ViewBag.Professions = _professionService.GetAll().OrderBy(p => p.profession_presidences);
                    return View(model);
                }


                string fileName = model.collector_code + extension;

                model.collector_image = "~/File/Collector/" + fileName;
                fileName = Path.Combine(Server.MapPath("~/File/Collector/"), fileName);
                imageFile.SaveAs(fileName);

                pro.profession_presidences += 1;
                _professionService.Edit(pro);

                _collectorService.Create(model);


                return RedirectToAction("Index");
            }

            ViewBag.SP = _employeeService.GetAll().Where(e => e.emp_branch_id == branchId && e.deleted != true);
            ViewBag.Professions = _professionService.GetAll().OrderBy(p => p.profession_presidences);
            return View(model);
        }

        // GET: Collectors/Edit/5
        [Route("Edit/{id?}")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            sales_collector sales_collector = _collectorService.GetById(id);
            if (sales_collector == null)
            {
                return HttpNotFound();
            }
            ViewBag.SP = _employeeService.GetAll().Where(e => e.deleted != true);
            ViewBag.Branchs = _branchService.GetAll();
            ViewBag.Professions = _professionService.GetAll().OrderBy(p => p.profession_presidences);
            return View(sales_collector);
        }

        // POST: Collectors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(sales_collector model, string branch, string profession, string employee, HttpPostedFileBase imageFile)
        {
            if (ModelState.IsValid)
            {
                if (imageFile != null)
                {
                    string extension = Path.GetExtension(imageFile.FileName);

                    if (!(extension.Equals(".jpg") || extension.Equals(".JPG")))
                    {
                        ModelState.AddModelError(string.Empty, "Not an accepted image type!");
                        return View(model);
                    }

                    string fileName = model.collector_code + extension;

                    model.collector_image = "~/File/Collector/" + fileName;

                    fileName = Path.Combine(Server.MapPath("~/File/Collector/"), fileName);

                    imageFile.SaveAs(fileName);
                }

                var pro = (hr_profession)_professionService.GetAll().Where(p => p.profession_name.Contains(profession)).SingleOrDefault();
                if (pro != null)
                {
                    model.collector_profession_id = pro.profession_id;
                }
                else
                {
                    _professionService.Create(new hr_profession()
                    {
                        profession_name = profession,
                    });
                    pro = (hr_profession)_professionService.GetAll().Where(p => p.profession_name.Contains(profession)).SingleOrDefault();

                    model.collector_profession_id = pro.profession_id;
                }

                var sal = (hr_employee)_employeeService.GetAll().Where(e => e.emp_code.Contains(employee))
                    .SingleOrDefault();
                if (sal != null)
                {
                    model.collector_sales_person_id = sal.emp_id;
                }

                else
                {
                    ModelState.AddModelError(string.Empty, "Sales Person Code not correct!");

                    ViewBag.SP = _employeeService.GetAll().Where(e => e.deleted != true);
                    ViewBag.Branchs = _branchService.GetAll();
                    ViewBag.Professions = _professionService.GetAll().OrderBy(p => p.profession_presidences);

                    return View(model);
                }


                var br = _branchService.GetAll().Where(b => b.branch_name.Contains(branch)).SingleOrDefault();
                if (br != null)
                {
                    model.collector_branch_id = br.branch_id;
                }

                else
                {
                    ModelState.AddModelError(string.Empty, "Branch Name not correct!");

                    ViewBag.SP = _employeeService.GetAll().Where(e => e.deleted != true);
                    ViewBag.Branchs = _branchService.GetAll();
                    ViewBag.Professions = _professionService.GetAll().OrderBy(p => p.profession_presidences);

                    return View(model);
                }

                pro.profession_presidences += 1;
                _professionService.Edit(pro);


                _collectorService.Edit(model);




                return RedirectToAction("Index");
            }

            ViewBag.SP = _employeeService.GetAll().Where(e => e.deleted != true);
            ViewBag.Branchs = _branchService.GetAll();
            ViewBag.Professions = _professionService.GetAll().OrderBy(p => p.profession_presidences);
            return View(model);
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


        public JsonResult GetColCode()
        {
            var a = _collectorService.GetAll().Max(c => c.collector_id);

            string colCode = "collector-" + (++a).ToString();

            return Json(colCode, JsonRequestBehavior.AllowGet);
        }


        public JsonResult DeleteCol(int id)
        {
            try
            {
                var col = _collectorService.GetById(id);
                col.deleted = true;
                _collectorService.Edit(col);
                return Json("Done", JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return Json("Error", JsonRequestBehavior.AllowGet);
            }
        }


    }
}
