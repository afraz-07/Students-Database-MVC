using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project_College.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            CollegeDbEntities Db = new CollegeDbEntities();

            var select = Db.Departments.ToList();

            ViewBag.Select = new SelectList(select, "DeptId", "Departments");

            return View();
        }

        [HttpPost]
        public ActionResult Create(Student s )
        {
            CollegeDbEntities Db = new CollegeDbEntities();
           


            if (ModelState.IsValid)
            {
                Db.Students.Add(s);

                Db.SaveChanges();

                return RedirectToAction("Read");

            }
            
                return View();
        }




        

        [HttpGet]
        public ActionResult Read(Student s) 
        {
            CollegeDbEntities Db = new CollegeDbEntities();

            var list = Db.Students.ToList();

            return View(list);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            CollegeDbEntities Db = new CollegeDbEntities();

            var find = Db.Students.Find(id);


            var select = Db.Departments.ToList();

            ViewBag.Select = new SelectList(select, "DeptId", "Departments");

            return View(find);
        }

        [HttpPost]
        public ActionResult Edit(Student s)
        {

            CollegeDbEntities Db = new CollegeDbEntities();

            Db.Entry(s).State = System.Data.Entity.EntityState.Modified;

            Db.SaveChanges();

            return RedirectToAction("Read");

        }

        [HttpGet]

        public ActionResult Details (int id)
        {
            CollegeDbEntities Db = new CollegeDbEntities();

            var find = Db.Students.Find(id);

            return View(find);
        }


      
        public ActionResult Delete(int id)
        {
            CollegeDbEntities Db = new CollegeDbEntities();

            var del = Db.Students.Find(id);

            Db.Students.Remove(del);

            Db.SaveChanges();

            return RedirectToAction("Read");
        }

        [HttpGet]
        public ActionResult Reg()
        {
            CollegeDbEntities Db = new CollegeDbEntities();

            var select = Db.Departments.ToList();

            ViewBag.Select = new SelectList(select, "DeptId", "Departments");

            return View();
        }

        [HttpPost]

        public ActionResult Reg(Staff st)
        {
            CollegeDbEntities Db = new CollegeDbEntities();


            if (ModelState.IsValid)
            {
                Db.Staffs.Add(st);

                Db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View();
            

            
        }


        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Staff st) 
        {
            CollegeDbEntities Db = new CollegeDbEntities();

            var user = Db.Staffs.Where(x=> x.UserId ==  st.UserId && x.Password == st.Password).FirstOrDefault();

            if (user != null)
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Reg");
        }
    }
}