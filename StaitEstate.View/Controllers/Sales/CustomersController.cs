using System;
using System.Data;
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
    [RoutePrefix("sales/customers")]
    public class CustomersController : Controller
    {
        
        private readonly ICustomerService _customerService;
        private readonly IEmployeeService _employeeService;
        private readonly IBranchService _branchService;
        private readonly IProfessionService _professionService;
        private readonly ICollectorService _collectorService;
        private MHLDB db = new MHLDB();


        public CustomersController(ICustomerService customerService,
            IEmployeeService employeeService,
            IBranchService branchService,
            IProfessionService professionService,
            ICollectorService collectorService)
        {
            _customerService = customerService;
            _employeeService = employeeService;
            _branchService = branchService;
            _professionService = professionService;
            _collectorService = collectorService;
        }


        // GET: Customers
        [Route("index")]
        public ActionResult Index()
        {

            return View();
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
        [Route("create/{branchId?}")]
        public ActionResult Create(int? branchId = -1)
        {
            if (branchId == -1 || branchId == null)
                branchId = _branchService.GetAll().FirstOrDefault().branch_id;


            ViewBag.SP = _employeeService.GetAll().Where(e => e.emp_branch_id == branchId && e.deleted != true);
            ViewBag.Professions = _professionService.GetAll().OrderByDescending(p => p.profession_presidences);
            ViewBag.Cols = _collectorService.GetAll().Where(c => c.deleted != true && c.collector_branch_id == branchId);

            return View();
        }

        // POST: Customers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("create/{branchId?}")]
        public ActionResult Create(sales_customer model, int? branchId, string profession, string employee, string collector, HttpPostedFileBase imageFile)
        {
            if (ModelState.IsValid)
            {
                if (branchId == -1 || branchId == null)
                    branchId = _branchService.GetAll().FirstOrDefault().branch_id;

                model.customer_branch_id = branchId;

                //Profession
                var pro = (hr_profession)_professionService.GetAll().Where(p => p.profession_name.Contains(profession)).SingleOrDefault();
                if (pro != null)
                {
                    model.customer_profession_id = pro.profession_id;
                }
                else
                {
                    _professionService.Create(new hr_profession()
                    {
                        profession_name = profession,
                    });
                    pro = (hr_profession)_professionService.GetAll().Where(p => p.profession_name.Contains(profession)).SingleOrDefault();

                    model.customer_profession_id = pro.profession_id;
                }

                pro.profession_presidences += 1;
                _professionService.Edit(pro);


                //Sales Person
                var sal = (hr_employee)_employeeService.GetAll().Where(e => e.emp_code.Contains(employee) && e.deleted != true && e.emp_branch_id == branchId)
                    .SingleOrDefault();
                if (sal != null)
                {
                    model.customer_sales_person_id = sal.emp_id;
                }

                else
                {
                    ModelState.AddModelError(string.Empty, "Sales Person Code not correct!");
                    ViewBag.SP = _employeeService.GetAll().Where(e => e.emp_branch_id == branchId && e.deleted != true);
                    ViewBag.Professions = _professionService.GetAll().OrderByDescending(p => p.profession_presidences);
                    ViewBag.Cols = _collectorService.GetAll().Where(c => c.deleted != true && c.collector_branch_id == branchId);
                    return View(model);
                }

                //Collector
                var col = _collectorService.GetAll().Where(e => e.collector_code.Contains(collector) && e.deleted != true && e.collector_branch_id == branchId).SingleOrDefault();
                if (col != null)
                {
                    model.customer_collector_id = col.collector_id;
                }

                else
                {
                    ModelState.AddModelError(string.Empty, "Collector Code not correct!");
                    ViewBag.SP = _employeeService.GetAll().Where(e => e.emp_branch_id == branchId && e.deleted != true);
                    ViewBag.Professions = _professionService.GetAll().OrderByDescending(p => p.profession_presidences);
                    ViewBag.Cols = _collectorService.GetAll().Where(c => c.deleted != true && c.collector_branch_id == branchId);
                    return View(model);
                }

                //Image
                string extension = Path.GetExtension(imageFile.FileName);
                if (!(extension.Equals(".jpg") || extension.Equals(".JPG")))
                {
                    ModelState.AddModelError(string.Empty, "Not an accepted image type!");
                    ViewBag.SP = _employeeService.GetAll().Where(e => e.emp_branch_id == branchId && e.deleted != true);
                    ViewBag.Professions = _professionService.GetAll().OrderByDescending(p => p.profession_presidences);
                    ViewBag.Cols = _collectorService.GetAll().Where(c => c.deleted != true && c.collector_branch_id == branchId);
                    return View(model);
                }

                string fileName = model.customer_code + extension;
                
                model.customer_image = "~/File/Customer/" + fileName;
                fileName = Path.Combine(Server.MapPath("~/File/Customer/"), fileName);

                FileInfo fi = new FileInfo(fileName);
                if (fi.Exists)
                {
                    fi.Delete();
                }
                imageFile.SaveAs(fileName);

                _customerService.Create(model);




                return RedirectToAction("Index");
            }


            ViewBag.SP = _employeeService.GetAll().Where(e => e.emp_branch_id == branchId && e.deleted != true);
            ViewBag.Professions = _professionService.GetAll().OrderByDescending(p => p.profession_presidences);
            ViewBag.Cols = _collectorService.GetAll().Where(c => c.deleted != true && c.collector_branch_id == branchId);

            return View(model);
        }

        // GET: Customers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            sales_customer model = _customerService.GetById(id);
            if (model == null)
            {
                return HttpNotFound();
            }

            var branch = _branchService.GetById(model.customer_branch_id);
            ViewBag.Branch = branch.branch_name;

            ViewBag.Branchs = _branchService.GetAll();
            ViewBag.SP = _employeeService.GetAll().Where(e => e.emp_branch_id == model.customer_branch_id && e.deleted != true);
            ViewBag.Professions = _professionService.GetAll().OrderByDescending(p => p.profession_presidences);
            ViewBag.Cols = _collectorService.GetAll().Where(c => c.deleted != true && c.collector_branch_id == model.customer_branch_id);



            return View(model);
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(sales_customer model, string profession, string employee, string collector, HttpPostedFileBase imageFile, string branch)
        {
            if (ModelState.IsValid)
            {
                //branch
                var br = _branchService.GetAll().Where(bb => bb.branch_name.Contains(branch)).SingleOrDefault();
                if (br != null)
                {
                    model.customer_branch_id = br.branch_id;
                }
                else
                {

                    ModelState.AddModelError(string.Empty, "Branch not correct!");
                    var brnch = _branchService.GetById(model.customer_branch_id);
                    ViewBag.Branch = brnch.branch_name;

                    ViewBag.Branchs = _branchService.GetAll();
                    ViewBag.SP = _employeeService.GetAll()
                        .Where(e => e.emp_branch_id == model.customer_branch_id && e.deleted != true);
                    ViewBag.Professions = _professionService.GetAll().OrderByDescending(p => p.profession_presidences);
                    ViewBag.Cols = _collectorService.GetAll().Where(c =>
                        c.deleted != true && c.collector_branch_id == model.customer_branch_id);
                    return View(model);
                }

                //Profession
                var pro = (hr_profession)_professionService.GetAll().Where(p => p.profession_name.Contains(profession))
                    .SingleOrDefault();
                if (pro != null)
                {
                    model.customer_profession_id = pro.profession_id;
                }
                else
                {
                    _professionService.Create(new hr_profession()
                    {
                        profession_name = profession,
                    });
                    pro = (hr_profession)_professionService.GetAll().Where(p => p.profession_name.Contains(profession))
                        .SingleOrDefault();

                    model.customer_profession_id = pro.profession_id;
                }

                pro.profession_presidences += 1;
                _professionService.Edit(pro);


                //Sales Person
                var sal = (hr_employee)_employeeService.GetAll().Where(e =>
                       e.emp_code.Contains(employee) && e.deleted != true && e.emp_branch_id == br.branch_id)
                    .SingleOrDefault();
                if (sal != null)
                {
                    model.customer_sales_person_id = sal.emp_id;
                }

                else
                {
                    ModelState.AddModelError(string.Empty, "Sales Person not correct!");
                    var brnch = _branchService.GetById(model.customer_branch_id);
                    ViewBag.Branch = brnch.branch_name;

                    ViewBag.Branchs = _branchService.GetAll();
                    ViewBag.SP = _employeeService.GetAll()
                        .Where(e => e.emp_branch_id == model.customer_branch_id && e.deleted != true);
                    ViewBag.Professions = _professionService.GetAll().OrderByDescending(p => p.profession_presidences);
                    ViewBag.Cols = _collectorService.GetAll().Where(c =>
                        c.deleted != true && c.collector_branch_id == model.customer_branch_id);
                    return View(model);
                }

                //Collector
                var col = _collectorService.GetAll().Where(e =>
                        e.collector_code.Contains(collector) && e.deleted != true && e.collector_branch_id == br.branch_id)
                    .SingleOrDefault();
                if (col != null)
                {
                    model.customer_collector_id = col.collector_id;
                }

                else
                {
                    ModelState.AddModelError(string.Empty, "Collector not correct!");
                    var brnch = _branchService.GetById(model.customer_branch_id);
                    ViewBag.Branch = brnch.branch_name;

                    ViewBag.Branchs = _branchService.GetAll();
                    ViewBag.SP = _employeeService.GetAll()
                        .Where(e => e.emp_branch_id == model.customer_branch_id && e.deleted != true);
                    ViewBag.Professions = _professionService.GetAll().OrderByDescending(p => p.profession_presidences);
                    ViewBag.Cols = _collectorService.GetAll().Where(c =>
                        c.deleted != true && c.collector_branch_id == model.customer_branch_id);
                    return View(model);
                }

                //Image
                if (imageFile != null)
                {
                    string extension = Path.GetExtension(imageFile.FileName);
                    if (!(extension.Equals(".jpg") || extension.Equals(".JPG")))
                    {
                        ModelState.AddModelError(string.Empty, "Not an accepted image type!");
                        ViewBag.SP = _employeeService.GetAll()
                            .Where(e => e.emp_branch_id == br.branch_id && e.deleted != true);
                        ViewBag.Professions =
                            _professionService.GetAll().OrderByDescending(p => p.profession_presidences);
                        ViewBag.Cols = _collectorService.GetAll()
                            .Where(c => c.deleted != true && c.collector_branch_id == br.branch_id);
                        return View(model);
                    }

                    string fileName = model.customer_code + extension;

                    model.customer_image = "~/File/Customer/" + fileName;


                    fileName = Path.Combine(Server.MapPath("~/File/Customer/"), fileName);
                    imageFile.SaveAs(fileName);
                }



                _customerService.Edit(model);




                return RedirectToAction("Index");
            }



            var b = _branchService.GetById(model.customer_branch_id);
            ViewBag.Branch = b.branch_name;

            ViewBag.Branchs = _branchService.GetAll();
            ViewBag.SP = _employeeService.GetAll().Where(e => e.emp_branch_id == model.customer_branch_id && e.deleted != true);
            ViewBag.Professions = _professionService.GetAll().OrderByDescending(p => p.profession_presidences);
            ViewBag.Cols = _collectorService.GetAll().Where(c => c.deleted != true && c.collector_branch_id == model.customer_branch_id);
            return View(model);
        }




        //Json
        public JsonResult GetCus(int? id = -1)
        {
            if (id != -1)
            {
                var cus = _customerService.GetAll().Where(c => c.deleted != true && c.customer_branch_id == id)
                    .Select(c => new
                    {
                        Id = c.customer_id,
                        Code = c.customer_code,
                        Name = c.customer_name,
                        Phone = c.customer_phone,
                        Father = c.customer_father_or_husband_name,
                        Mother = c.customer_mother_name,
                        AddPerma = c.customer_permanent_address,
                        AddPre = c.customer_present_address,
                        Dob = String.Format("{0:dd/MM/yyyy}", c.customer_dob),
                        BirthPlace = c.customer_birth_place,
                        Image = c.customer_image,
                        Collector = new
                        {
                            Id = c.sales_collector.collector_id,
                            Name = c.sales_collector.collector_name,
                            Code = c.sales_collector.collector_code
                        },
                        SalesPerson = new
                        {
                            Id = c.hr_employee.emp_id,
                            Name = c.hr_employee.emp_name,
                            Code = c.hr_employee.emp_code
                        },
                        Profession = new
                        {
                            Id = c.hr_profession.profession_id,
                            Name = c.hr_profession.profession_name
                        }
                    });

                return Json(cus, JsonRequestBehavior.AllowGet);
            }

            var cs = _customerService.GetAll().Where(c => c.deleted != true)
                .Select(c => new
                {
                    Id = c.customer_id,
                    Code = c.customer_code,
                    Name = c.customer_name,
                    Phone = c.customer_phone,
                    Father = c.customer_father_or_husband_name,
                    Mother = c.customer_mother_name,
                    AddPerma = c.customer_permanent_address,
                    AddPre = c.customer_present_address,
                    Dob = String.Format("{0:dd/MM/yyyy}", c.customer_dob),
                    BirthPlace = c.customer_birth_place,
                    Image = c.customer_image,
                    Collector = new
                    {
                        Id = c.sales_collector.collector_id,
                        Name = c.sales_collector.collector_name,
                        Code = c.sales_collector.collector_code
                    },
                    SalesPerson = new
                    {
                        Id = c.hr_employee.emp_id,
                        Name = c.hr_employee.emp_name,
                        Code = c.hr_employee.emp_code
                    },
                    Profession = new
                    {
                        Id = c.hr_profession.profession_id,
                        Name = c.hr_profession.profession_name
                    }
                });


            return Json(cs, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetCusCode()
        {
            var a = _customerService.GetAll().Max(c => c.customer_id);

            string cusCode = "Cus-" + (++a).ToString();

            return Json(cusCode, JsonRequestBehavior.AllowGet);
        }

        public JsonResult DeleteCus(int? id)
        {
            try
            {
                var cus = _customerService.GetById(id);
                cus.deleted = true;
                _customerService.Edit(cus);
                return Json("Done", JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return Json("Error", JsonRequestBehavior.AllowGet);
            }
        }

    }
}
