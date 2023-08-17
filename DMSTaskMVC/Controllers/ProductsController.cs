using AutoMapper;
using BLL.DTOs.CustomFields;
using BLL.DTOs.Categories;
using BLL.DTOs.CustomFieldDatas;
using BLL.DTOs.Products;
using DAL.Contacts.Categories;
using DAL.Contacts.Products;
using DAL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DMSTaskMVC.Controllers
{
    public class ProductsController : Controller
    {

        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        private readonly ICategoryRepository _categoryRepository;

        public ProductsController(
                ICategoryRepository categoryRepository,
                IProductRepository productRepository,
                IMapper mapper)
        {


            _productRepository = productRepository;
            _mapper = mapper;
            _categoryRepository = categoryRepository;
        }
        public async Task<IActionResult> Index()
        {
            try
            {
                var Products = await _productRepository.GetAllAsync();

                return View(_mapper.Map<IEnumerable<ProductDTO>>(Products));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IActionResult> Search(string? filter = null, int? fromPrice = null, int? toPric = null, int? categoryId = null)
        {
            try
            {
                var Products = await _productRepository.FilterByAsync(filter, fromPrice,toPric,categoryId);

                return View("Index", _mapper.Map<IEnumerable<ProductDTO>>(Products));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.Categories = new SelectList(await _categoryRepository.GetAllAsync(), "Id", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductDTO product)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    var item = _mapper.Map<Product>(product);

                    item.Categories = (await _categoryRepository.GetAllAsync()).Where(c => product.CategoriesId.Contains(c.Id)).ToList();


                    await _productRepository.CreateAsync(item);
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return View();
                }

            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }


        }

        public async Task<IActionResult> Details(int id)
        {
            try
            {
                var product = (await _productRepository.GetDetailsAsync(id));

                if (product is null)
                {
                    return NotFound();
                }
                else
                {

                    // var t = _mapper.Map<DetailsProductDTO>(product);
                    var t = new DetailsProductDTO()
                    {
                        Id = product.Id,
                        Name = product.Name,
                        Price = product.Price,
                        Description = product.Description,
                        Quantity = product.Quantity,
                        Categories = product.Categories.Select(c => new CategoryDTO { Id = c.Id, Name = c.Name }).ToList(),
                        CustomFields = product.CustomFields.Select(
                            c => new CustomFieldDTO
                            {
                                Id = c.Id,
                                Name = c.Name,
                                CustomFieldsData = new CustomFieldDataDTO()
                                {
                                    Id = c.CustomFieldData.Id,
                                    Value = c.CustomFieldData.Value
                                }
                            }).ToList()
                    };

                    return View(t);
                }
            }
            catch (Exception ex)
            {

                ModelState.AddModelError("", ex.Message);
                return View();
            }



        }

        public async Task<IActionResult> Edit(int id)
        {
            var product = await _productRepository.GetDetailsAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            ViewBag.Categories = new SelectList(await _categoryRepository.GetAllAsync(), "Id", "Name");
            var model = _mapper.Map<EditProductDTO>(product);
            model.CategoriesId = product.Categories.Select(c => c.Id).ToList();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, EditProductDTO product)
        {

            if (id != product.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    var ProductTemp = await _productRepository.GetDetailsAsync(id);

                    if (ProductTemp is not null)
                    {
                        ProductTemp.Name = product.Name;
                        ProductTemp.Description = product.Description;
                        product.Quantity = product.Quantity;
                        ProductTemp.Price = product.Price;
                        ProductTemp.Quantity = product.Quantity;
                        ProductTemp.Categories = (await _categoryRepository.GetAllAsync()).Where(c => product.CategoriesId.Contains(c.Id)).ToList();
                        await _productRepository.UpdateAsync(ProductTemp);
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        throw new Exception("Error by Bind Value");
                    }

                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                }

            }
            return View(product);
        }

        [HttpPost]

        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (await _productRepository.GetDetailsAsync(id) == null)
            {
                return Problem("Entity set 'Product '  is null.");
            }
            var product = await _productRepository.GetDetailsAsync(id);
            if (product != null)
            {
                await _productRepository.DeleteAsync(id);
            }
            return RedirectToAction(nameof(Index));
        }

    }


}
