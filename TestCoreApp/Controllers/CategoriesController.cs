using Microsoft.AspNetCore.Mvc;
using TestCoreApp.Models;
using TestCoreApp.Repository.Base;

namespace TestCoreApp.Controllers
{
    public class CategoriesController : Controller
    {
        private IRepository<Category> _categoryRepository;
        public CategoriesController(IRepository<Category> repository ) {
            _categoryRepository = repository;
        }
        public async Task<IActionResult> Index()
        {
            var OneCat = _categoryRepository.SelectOne(x=>x.Name=="Computers");
            var AllCat = await _categoryRepository.GetAllAsync("Items");
            return View( AllCat);
        }
    }
}
