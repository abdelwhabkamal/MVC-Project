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
        public IActionResult Index()
        {
            return View(_categoryRepository.GetAll());
        }
    }
}
