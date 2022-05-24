using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using BookApp.Models.DbModels;

namespace BookApp.Controllers
{
    public class AuthorController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult View(int id)
        {
            Author author;
            using (DatabaseContext db = new DatabaseContext())
                author = db.Authors.FirstOrDefault(a => a.AuthorId == id);
            
            return View(author);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(new Author());
        }

        [HttpPost]
        public ActionResult Create(Author author)
        {
            if(ModelState.IsValid)
            {
                using (DatabaseContext db = new DatabaseContext())
                {
                    db.Authors.Add(author);
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }

            return View(author);
        }

        public ActionResult ViewAll()
        {
            List<Author> authors;
            using (DatabaseContext db = new DatabaseContext())
            {
                authors = db.Authors.ToList();
            }
            return View(authors);
        }

        public ActionResult Edit(int id)
        {
            Author author;
            using (DatabaseContext db = new DatabaseContext())
                author = db.Authors.FirstOrDefault(a => a.AuthorId == id);
            
            return View(author);
        }
    }
}