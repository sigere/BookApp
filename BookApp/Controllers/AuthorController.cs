using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using BookApp.Models.DbModels;

namespace BookApp.Controllers
{
    public class AuthorController : Controller
    {
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
                return RedirectToAction("ViewAll");
            }

            return View(author);
        }

        public ActionResult ViewAll()
        {
            List<Author> authors;
            using (DatabaseContext db = new DatabaseContext())
                authors = db.Authors.ToList();
            
            return View(authors);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            Author author;
            using (DatabaseContext db = new DatabaseContext())
                author = db.Authors.FirstOrDefault(a => a.AuthorId == id);
            
            return View(author);
        }
        
        [HttpPost]
        public ActionResult Edit(Author author)
        {
            if (!ModelState.IsValid)
                return View(author);

            using (DatabaseContext db = new DatabaseContext())
            {
                db.Entry(author).State = EntityState.Modified;
                db.SaveChanges();
            }

            return RedirectToAction("ViewAll");
        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            Author author;
            using (DatabaseContext db = new DatabaseContext())
                author = db.Authors.FirstOrDefault(x => x.AuthorId == id);

            return View(author);
        }
        
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirm(int? id)
        {
            using (DatabaseContext db = new DatabaseContext())
            {
                Author author = db.Authors.FirstOrDefault(x => x.AuthorId == id);
                db.Authors.Remove(author);
                db.SaveChanges();
            }
            
            return RedirectToAction("ViewAll");
        }
    }
}