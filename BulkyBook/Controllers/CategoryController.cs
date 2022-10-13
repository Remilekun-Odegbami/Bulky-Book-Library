using BulkyBook.Data;
using BulkyBook.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkyBook.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;
        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Category> objCategoryList = _db.Categories;
            return View(objCategoryList);
        }

        // Get
        public IActionResult Create()
        {
            return View();
        }

        // Post
        [HttpPost]
        [ValidateAntiForgeryToken] //helps to prevent cross-site request forgery by creating a key in every form created in the application which must be validated before the method will execute.
        public IActionResult Create(Category obj)
        {
            if(obj.Name == obj.DisplayOrder.ToString())
            {
                //custom errors
                ModelState.AddModelError("CustomError", "Display order cannot be the same value as Name");
            }
            // to check if a model is valid or not
            if (ModelState.IsValid)
            {
                _db.Categories.Add(obj);
                // to post the data to the database
                _db.SaveChanges();
                TempData["success"] = "Category was created successfully";
                // Redirect to the index page
                return RedirectToAction("Index");
            }
            // if the model is not valid
            return View(obj);
        }

        // Edit
        public IActionResult Edit(int? id)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }
            // ways to retrieve data from the database based on the id
            var categoryFromDb = _db.Categories.Find(id);
            //var categoryFromFirst = _db.Categories.FirstOrDefault(u => u.Id == id);
            //var categoryFromSingle = _db.Categories.SingleOrDefault(u => u.Id == id);


            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }

        // Post
        [HttpPost]
        [ValidateAntiForgeryToken] //helps to prevent cross-site request forgery by creating a key in every form created in the application which must be validated before the method will execute.
        public IActionResult Edit(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                //custom errors
                ModelState.AddModelError("CustomError", "Display order cannot be the same value as Name");
            }
            // to check if a model is valid or not
            if (ModelState.IsValid)
            {
                _db.Categories.Update(obj);
                // to post the data to the database
                _db.SaveChanges();
                TempData["success"] = "Category has been edited successfully";
                // Redirect to the index page
                return RedirectToAction("Index");
            }
            // if the model is not valid
            return View(obj);
        }

        // Delete
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            // ways to retrieve data from the database based on the id
            var categoryFromDb = _db.Categories.Find(id);
            //var categoryFromFirst = _db.Categories.FirstOrDefault(u => u.Id == id);
            //var categoryFromSingle = _db.Categories.SingleOrDefault(u => u.Id == id);


            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }

        // Post
        [HttpPost]
        [ValidateAntiForgeryToken] //helps to prevent cross-site request forgery by creating a key in every form created in the application which must be validated before the method will execute.
        public IActionResult DeletePost(int? id)
        {
            var obj = _db.Categories.Find(id);

            if (obj == null) 
            {
                return NotFound();
            }
            
            _db.Categories.Remove(obj);
            _db.SaveChanges();
            TempData["success"] = "Category has been deleted successfully";
            return RedirectToAction("Index");
        }
    }
}
