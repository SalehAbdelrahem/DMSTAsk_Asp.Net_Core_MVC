using BLL.DTOs.Categories;
using BLL.Services;
using DAL.Contacts.Categories;
using DAL.Repositories.Categories;
using Microsoft.AspNetCore.Mvc;

namespace DMSTaskMVC.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ServiceCategory _serviceCategory;
        private readonly ICategoryRepository _categoryRepository;

        public CategoriesController(ServiceCategory serviceCategory ,ICategoryRepository categoryRepository) {
            _serviceCategory = serviceCategory;
            _categoryRepository = categoryRepository;
        }
        // GET: CategoriesController
        public async Task<IActionResult> Index()
        {
            return View(await _serviceCategory.GetCategories());
        }

        // GET: CategoriesController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            
            return View( await _serviceCategory.GetCategoryById(id));
        }

        // GET: CategoriesController/Create
        public IActionResult  Create()
        {
            return View();
        }

        // POST: CategoriesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CategoryDTO cat)
        {
            try
            {
                _serviceCategory.AddCategory(cat);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CategoriesController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            return View(await _serviceCategory.GetCategoryById(id));
        }

        // POST: CategoriesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, CategoryDTO category)
        {
            try
            {   
                try
                {
                    var result = await _categoryRepository.GetByIdAsync(category.Id);
                    if (result is null)
                    {
                        throw new Exception("Not Found the Category");
                    }
                    else
                    {
                        result.Name = category.Name;
                        await _categoryRepository.UpdateAsync(result);
                        return RedirectToAction(nameof(Index));
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            catch
            {
                return View();
            }
        }

      
       
        [HttpPost]

        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (await _categoryRepository.GetByIdAsync(id) == null)
            {
                return Problem("Entity set 'category '  is null.");
            }
            var category = await _categoryRepository.GetByIdAsync(id);
            if (category != null)
            {
                await _categoryRepository.DeleteAsync(id);
            }
            return RedirectToAction(nameof(Index));
        }

    }
}
