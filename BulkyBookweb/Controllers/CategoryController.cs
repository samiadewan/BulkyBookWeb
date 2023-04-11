using BulkyBookweb.Data;
using BulkyBookweb.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkyBookweb.Controllers
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

        //GET method
        public IActionResult Create()
        {
            
            return View();//as we are using get method so no need to pass any object like previous action
        }

        //POST method
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category obj)
        {
            if(obj.Name ==obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "The DisplayOrder cannot exactly match the Name.");
            }
            if (ModelState.IsValid)
            {
                _db.Categories.Add(obj);
                _db.SaveChanges();//pushto databse
                TempData["success"] = "Category created successfully";
                return RedirectToAction("Index");

            }
            return View(obj);
           
        }

        //GET method for Edit
        public IActionResult Edit(int? id)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }
            var categoryFromDb = _db.Categories.Find(id);
            //var categoryFromDbFirst = _db.Categories.FirstOrDefault(u=>u.Id == id);
            //var categoryFromDbSingle = _db.Categories.SingleOrDefault(u=>u.Id == id);
            if(categoryFromDb == null) 
            {
                return NotFound();
            }

            return View(categoryFromDb);//as we are using get method so no need to pass any object like previous action
        }

        //POST method
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "The DisplayOrder cannot exactly match the Name.");
            }
            if (ModelState.IsValid)
            {
                _db.Categories.Update(obj);
                _db.SaveChanges();//pushto databse
                TempData["success"] = "Category updated successfully";
                return RedirectToAction("Index");

            }
            return View(obj);

        }

        //GET method for Delete
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var categoryFromDb = _db.Categories.Find(id);
            //var categoryFromDbFirst = _db.Categories.FirstOrDefault(u=>u.Id == id);
            //var categoryFromDbSingle = _db.Categories.SingleOrDefault(u=>u.Id == id);
            if (categoryFromDb == null)
            {
                return NotFound();
            }

            return View(categoryFromDb);//as we are using get method so no need to pass any object like previous action
        }

        //POST method
        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var obj= _db.Categories.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            
            _db.Categories.Remove(obj);
            _db.SaveChanges();//pushto databse
            TempData["success"] = "Category deleted successfully";
            return RedirectToAction("Index");

            
            return View(obj);

        }
    }
}
