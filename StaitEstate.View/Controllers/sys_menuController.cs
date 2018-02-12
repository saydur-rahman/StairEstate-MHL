using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using StairEstate.Data;
using StairEstate.Entity;

namespace StaitEstate.View.Controllers
{
    public class sys_menuController : Controller
    {
        private MHLDB db = new MHLDB();

        // GET: sys_menu
        public async Task<ActionResult> Index()
        {
            return View(await db.sys_menu.ToListAsync());
        }

        // GET: sys_menu/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            sys_menu sys_menu = await db.sys_menu.FindAsync(id);
            if (sys_menu == null)
            {
                return HttpNotFound();
            }
            return View(sys_menu);
        }

        // GET: sys_menu/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: sys_menu/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "menu_id,menu_name,menu_type,menu_link,menu_parent")] sys_menu sys_menu)
        {
            if (ModelState.IsValid)
            {
                db.sys_menu.Add(sys_menu);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(sys_menu);
        }

        // GET: sys_menu/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            sys_menu sys_menu = await db.sys_menu.FindAsync(id);
            if (sys_menu == null)
            {
                return HttpNotFound();
            }
            return View(sys_menu);
        }

        // POST: sys_menu/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "menu_id,menu_name,menu_type,menu_link,menu_parent")] sys_menu sys_menu)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sys_menu).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(sys_menu);
        }

        // GET: sys_menu/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            sys_menu sys_menu = await db.sys_menu.FindAsync(id);
            if (sys_menu == null)
            {
                return HttpNotFound();
            }
            return View(sys_menu);
        }

        // POST: sys_menu/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            sys_menu sys_menu = await db.sys_menu.FindAsync(id);
            db.sys_menu.Remove(sys_menu);
            await db.SaveChangesAsync();
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
