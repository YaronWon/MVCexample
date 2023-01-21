using Microsoft.AspNetCore.Mvc;
using cSharpMVC.Data;
using cSharpMVC.Models;

namespace cSharpMVC.Controllers
{
    public class CategoryController : Controller
    {
        private readonly AppDB _db;

        public CategoryController(AppDB db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Category> objCateList = _db.categories.ToList();
            return View(objCateList);
        }

        //GET
        public IActionResult Create()
        {
            
            return View();
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category obj)
        {
            if(obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "חייב לשנות את אחד הנתונים");
            }
            if (ModelState.IsValid)
            {
                _db.categories.Add(obj);
                _db.SaveChanges();
                TempData["GoodJob"] = "Created Successfully";
                return RedirectToAction("Index");
            }

            return View(obj);
           
        }

        //GET
        public IActionResult Edit(int? id)
        {
            if(id == 0 || id==null)
            {
                return NotFound();
            }
            var CategoryFromDB = _db.categories.Find(id);

            if (CategoryFromDB == null)
            {
                return NotFound();
            }
            return View(CategoryFromDB);
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "חייב לשנות את אחד הנתונים");
            }
            if (ModelState.IsValid)
            {
                _db.categories.Update(obj);
                _db.SaveChanges();
                TempData["GoodJob"] = "Updated Successfully";
                return RedirectToAction("Index");
            }

            return View(obj);

        }

        //GET
        public IActionResult Delete(int? id)
        {
            if (id == 0 || id == null)
            {
                return NotFound();
            }
            var CategoryFromDB = _db.categories.Find(id);

            if (CategoryFromDB == null)
            {
                return NotFound();
            }
            return View(CategoryFromDB);
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {

            var obj = _db.categories.Find(id);
            if(obj == null)
            {
                return NotFound();
            }
           
                _db.categories.Remove(obj);
                _db.SaveChanges();
            TempData["GoodJob"] = "Deleted Successfully";
            return RedirectToAction("Index");


         

        }
    }
}
