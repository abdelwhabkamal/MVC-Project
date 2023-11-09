using Microsoft.AspNetCore.Mvc;
using TestCoreApp.Models;
using TestCoreApp.Repository.Base;

namespace TestCoreApp.Controllers
{
    public class CategoriesController : Controller
    {
        private IUnitOfWork _unit;
        public CategoriesController(IUnitOfWork unit) {
            _unit=unit;
        }
        public async Task<IActionResult> Index()
        {
            var OneCat = _unit.categories.SelectOne(x=>x.Name=="Computers");
            var AllCat = await _unit.categories.GetAllAsync("Items");
            return View( AllCat);
        }
        public IActionResult New()
        {
            return View();
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult New(Category category)
        {
            if (ModelState.IsValid)
            {
                _unit.categories.AddOne(category);
                return RedirectToAction("Index");
            }
            else
            {
                return View(category);
            }
        }

        //GET
        public async Task<IActionResult> Edit(int? Id)
        {
            if (Id == null || Id == 0)
            {
                return NotFound();
            }
            var category = await _unit.categories.GetByIdAsync(Id.Value);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                _unit.categories.UpdateOne(category);
                return RedirectToAction("Index");
            }
            else
            {
                return View(category);
            }
        }

        //GET
        public async Task<IActionResult> Delete(int? Id)
        {
            if (Id == null || Id == 0)
            {
                return NotFound();
            }
            var category = await _unit.categories.GetByIdAsync(Id.Value);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Category category)
        {
            _unit.categories.DeleteOne(category);
            TempData["successData"] = "Item has been deleted successfully";
            return RedirectToAction("Index");
        }
    }
}
