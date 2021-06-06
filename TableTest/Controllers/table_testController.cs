using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TableTest.Models;

namespace TableTest.Controllers
{
    public class table_testController : Controller
    {
        private webtestEntities db = new webtestEntities();

        // GET: table_test
        public ActionResult Index()
        {
            return View(db.table_test.ToList());
        }

        public ActionResult Index2()
        {
            var data = new TestTableList();
            data.Build(db);

            return View(data);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public ActionResult Index2(IList<int> chktaisho, IList<int> No, string sel_shonin)
        public ActionResult Index2(TestTableList model)
        {
            var data = new TestTableList();
            data.Build(db);

            return RedirectToAction("Index2");
        }

        // GET: table_test/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            table_test table_test = db.table_test.Find(id);
            if (table_test == null)
            {
                return HttpNotFound();
            }
            return View(table_test);
        }

        // GET: table_test/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: table_test/Create
        // 過多ポスティング攻撃を防止するには、バインド先とする特定のプロパティを有効にしてください。
        // 詳細については、https://go.microsoft.com/fwlink/?LinkId=317598 を参照してください。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "no,flag,name,dt")] table_test table_test)
        {
            if (ModelState.IsValid)
            {
                db.table_test.Add(table_test);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(table_test);
        }

        // GET: table_test/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            table_test table_test = db.table_test.Find(id);
            if (table_test == null)
            {
                return HttpNotFound();
            }
            return View(table_test);
        }

        // POST: table_test/Edit/5
        // 過多ポスティング攻撃を防止するには、バインド先とする特定のプロパティを有効にしてください。
        // 詳細については、https://go.microsoft.com/fwlink/?LinkId=317598 を参照してください。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "no,flag,name,dt")] table_test table_test)
        {
            if (ModelState.IsValid)
            {
                db.Entry(table_test).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(table_test);
        }

        // GET: table_test/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            table_test table_test = db.table_test.Find(id);
            if (table_test == null)
            {
                return HttpNotFound();
            }
            return View(table_test);
        }

        // POST: table_test/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            table_test table_test = db.table_test.Find(id);
            db.table_test.Remove(table_test);
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
