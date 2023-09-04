using DAL.Contacts.Categories;
using Microsoft.AspNetCore.Mvc;

namespace DMSTaskMVC.ViewComponents
{
    public class CategoryViewComponent: ViewComponent
    {
     
        private readonly ICategoryRepository _categoryRepository;

        public CategoryViewComponent(ICategoryRepository  categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {

            return View("Index",  (await _categoryRepository.GetAllAsync()));
        }
    }
}
