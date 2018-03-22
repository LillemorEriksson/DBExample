using DBExample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DBExample.Controllers
{
    public class HomeController : Controller
    {
        DBExampleContext _db = new DBExampleContext();

        //if (string.IsNullOrEmty(ViewBag.error)) denna kolla om fältet är tomt eller ett mellanslag. tomt blankt mellanslag.

        public ActionResult EditStud(int id)
        {
            Student student = _db.Students.FirstOrDefault(s => s.Id == id);

            return View(student);
        }
        [HttpPost]
        public ActionResult EditStud(Student student)
        {
            Student editstud = _db.Students.FirstOrDefault(s => s.Id == student.Id);

            editstud.Name = student.Name;
            editstud.Email = student.Email;

            _db.SaveChanges();

            return RedirectToAction("Students");


        }

        public ActionResult Remove(int id)
        {
            Student removebul = _db.Students.FirstOrDefault(s => s.Id == id);
            _db.Students.Remove(removebul);
            _db.SaveChanges();

            return RedirectToAction("Students");
        }

        public ActionResult Index()
        {
            List<Course> listc = _db.Courses.ToList();
            _db.Courses
            .Include("Teacher")
            .Include("Students")
            //.Where(c => c.Students.Count < 2)
            .OrderByDescending(c => c.Name)
            .Take(10)//denna sorterar de 10 första kurserna
            .ToList();

            return View(listc);
        }
        [HttpPost]
        public ActionResult Index(Student student)
        {
            _db.Students.Add(student);
            _db.SaveChanges();

            return RedirectToAction("Index");


        }

        public ActionResult Teachers()
        {
            List<Teacher> list = _db.Teacher.ToList();

            return View(list);
        }

        public ActionResult Students()
        {
            List<Student> list = _db.Students.ToList();

            return View(list);
        }
        public ActionResult About()
        {
            // var model =
            // _db.Students.ToList();

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}