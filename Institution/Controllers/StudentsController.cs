using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Institution.Models;
using Institution.Interffaces;

namespace Institution.Controllers
{
    public class StudentsControllerTest : Controller
    {
        
        private StudentsContext db = new StudentsContext();

        ////CREATE METTHOD TEST
        //private readonly StudentRepository studentRepository;
        //public StudentsControllerTest(StudentRepository studentRepository)
        //{
        //    this.studentRepository = studentRepository;
        //}
        //[HttpPost]
        //public ActionResult Create(Student student)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        this.studentRepository.InsertOrUpdate(student);
        //        this.studentRepository.save();
        //        return RedirectToAction("Index");
        //    }
        //    return this.View();
        //}
        //---------------------------------------------------------

        // GET: Students
        public async Task<ActionResult> Index()
        {
            var student = db.Student.Include(s => s.Course);
            return View(await student.ToListAsync());
        }

        // GET: Students/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = await db.Student.FindAsync(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // GET: Students/Create
        public ActionResult Create()
        {
            ViewBag.COURSE_ID = new SelectList(db.Course, "COURSE_ID", "NAME");
            return View();
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "STUDENT_ID,NAME,LASTNAME,AGE,COURSE_ID")] Student student)
        {
            if (ModelState.IsValid)
            {
                db.Student.Add(student);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.COURSE_ID = new SelectList(db.Course, "COURSE_ID", "NAME", student.COURSE_ID);
            return View(student);
        }

        // GET: Students/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = await db.Student.FindAsync(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            ViewBag.COURSE_ID = new SelectList(db.Course, "COURSE_ID", "NAME", student.COURSE_ID);
            return View(student);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "STUDENT_ID,NAME,LASTNAME,AGE,COURSE_ID")] Student student)
        {
            if (ModelState.IsValid)
            {
                db.Entry(student).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.COURSE_ID = new SelectList(db.Course, "COURSE_ID", "NAME", student.COURSE_ID);
            return View(student);
        }

        // GET: Students/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = await db.Student.FindAsync(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Student student = await db.Student.FindAsync(id);
            db.Student.Remove(student);
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
