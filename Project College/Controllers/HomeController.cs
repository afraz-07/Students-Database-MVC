using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Project_College.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        [Authorize]
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





        [Authorize]        
        [HttpGet]

        public ActionResult Read(Student s, string searchtxt, string SortOrder, int Pgnumber = 1)
        {
            CollegeDbEntities Db = new CollegeDbEntities();

            ViewBag.SortOrder = SortOrder;


            var list = Db.Students.ToList();

            if (searchtxt != null)
            {
                list = Db.Students.Where(x => x.Name.Contains(searchtxt) || x.Email.Contains(searchtxt) || x.Gender.Contains(searchtxt)).ToList();
            }

            switch (SortOrder)
            {
                case "Asc":
                    {
                        list = list.OrderBy(x => x.Name).ToList();
                        break;
                    }
                case "Desc":
                    {
                        list = list.OrderByDescending(x => x.Name).ToList();
                        break;
                    }
                default:
                    {
                        list = list.OrderBy(x => x.Name).ToList();
                        break;
                    }
            }

            ViewBag.Ttlpgs = Math.Ceiling(list.Count() / 6.0);
            ViewBag.PageNumber = Pgnumber;

            list = list.Skip((Pgnumber - 1) * 6).Take(6).ToList();

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
                FormsAuthentication.SetAuthCookie(st.UserId, false);
                return RedirectToAction("Index");
            }
            return View();
        }



        [HttpGet]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index");
        }
    }
}