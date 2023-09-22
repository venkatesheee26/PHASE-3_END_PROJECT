using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PHASE_END_PROJECT_3.Models;

namespace PHASE_END_PROJECT_3.Controllers
{
    public class CustLogInfoesController : Controller
    {
        private PHASE_END_PROJECT_3Entities db = new PHASE_END_PROJECT_3Entities();

        // GET: CustLogInfoes
        public ActionResult Index()
        {
            var custLogInfoes = db.CustLogInfoes.Include(c => c.UserInfo);
            return View(custLogInfoes.ToList());
        }

        // GET: CustLogInfoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustLogInfo custLogInfo = db.CustLogInfoes.Find(id);
            if (custLogInfo == null)
            {
                return HttpNotFound();
            }
            return View(custLogInfo);
        }

        // GET: CustLogInfoes/Create
        public ActionResult Create()
        {
            ViewBag.UserId = new SelectList(db.UserInfoes, "UserId", "Email");
            return View();
        }

        // POST: CustLogInfoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "LogId,CustEmail,CustName,LogStatus,UserId,Description")] CustLogInfo custLogInfo)
        {
            if (ModelState.IsValid)
            {
                db.CustLogInfoes.Add(custLogInfo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UserId = new SelectList(db.UserInfoes, "UserId", "Email", custLogInfo.UserId);
            return View(custLogInfo);
        }

        // GET: CustLogInfoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustLogInfo custLogInfo = db.CustLogInfoes.Find(id);
            if (custLogInfo == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserId = new SelectList(db.UserInfoes, "UserId", "Email", custLogInfo.UserId);
            return View(custLogInfo);
        }

        // POST: CustLogInfoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "LogId,CustEmail,CustName,LogStatus,UserId,Description")] CustLogInfo custLogInfo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(custLogInfo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserId = new SelectList(db.UserInfoes, "UserId", "Email", custLogInfo.UserId);
            return View(custLogInfo);
        }

        // GET: CustLogInfoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustLogInfo custLogInfo = db.CustLogInfoes.Find(id);
            if (custLogInfo == null)
            {
                return HttpNotFound();
            }
            return View(custLogInfo);
        }

        // POST: CustLogInfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CustLogInfo custLogInfo = db.CustLogInfoes.Find(id);
            db.CustLogInfoes.Remove(custLogInfo);
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
