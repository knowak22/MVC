﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplicationLogin.Models;

namespace WebApplicationLogin.Controllers
{
    public class SubjectsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Subjects
        public ActionResult Index()
        {
            return View(db.Subjects.ToList());
        }

        // GET: Subjects/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Subject subject = db.Subjects.Find(id);
            if (subject == null)
            {
                return HttpNotFound();
            }
            return View(subject);
        }

        // GET: Subjects/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Subjects/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]//[Bind(Include = "SubjectID,Name,MySubjectID,SClassID")]
        public ActionResult Create([Bind(Include = "SubjectID,Name,FilePath")] Subject subject)
        {
            if (ModelState.IsValid)
            {
                subject.FilePath = SaveFile(Request.Files[0]);

                db.Subjects.Add(subject);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(subject);
        }

        // GET: Subjects/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Subject subject = db.Subjects.Find(id);
            if (subject == null)
            {
                return HttpNotFound();
            }
            return View(subject);
        }

        // POST: Subjects/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]//[Bind(Include = "SubjectID,Name,MySubjectID,SClassID")]
        public ActionResult Edit([Bind(Include = "SubjectID,Name,FilePath")] Subject subject)
        {
            if (ModelState.IsValid)
            {
                subject.FilePath = SaveFile(Request.Files[0]);
                db.Entry(subject).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(subject);
        }

        // GET: Subjects/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Subject subject = db.Subjects.Find(id);
            if (subject == null)
            {
                return HttpNotFound();
            }
            return View(subject);
        }

        // POST: Subjects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Subject subject = db.Subjects.Find(id);
            db.Subjects.Remove(subject);
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

        private string SaveFile(HttpPostedFileBase file)
        {
            string targetFolder = HttpContext.Server.MapPath("~/uploads");
            string targetPath = Path.Combine(targetFolder, file.FileName);
            file.SaveAs(targetPath);
            return targetPath;
        }
    }
}
