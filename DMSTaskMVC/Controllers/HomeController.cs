using DAL.Contacts.Categories;
using DAL.Contacts.CustomFields;
using DAL.Contacts.Products;
using DMSTaskMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;

namespace DMSTaskMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IProductRepository _productRepository;
        private readonly ICustomFieldRepository _customFieldRepository;

        public HomeController(ILogger<HomeController> logger,
            ICategoryRepository categoryRepository,
            IProductRepository productRepository,
            ICustomFieldRepository customFieldRepository
            )
        {
            _logger = logger;
            _categoryRepository = categoryRepository;
            _productRepository = productRepository;
            _customFieldRepository = customFieldRepository;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.ProductsCount = await _productRepository.GetCountAsync();
            ViewBag.CategoriesCount = await _categoryRepository.GetCountAsync();
            ViewBag.CustomFiledCount = await _customFieldRepository.GetCountAsync();
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}