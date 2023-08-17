using AutoMapper;
using BLL.DTOs.CustomData;
using BLL.DTOs.CustomFieldDatas;
using BLL.DTOs.CustomFields;
using BLL.DTOs.Products;
using DAL.Contacts.Categories;
using DAL.Contacts.CustomFieldDatas;
using DAL.Contacts.CustomFields;
using DAL.Contacts.Products;
using DAL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DMSTaskMVC.Controllers
{
    public class CustomFiledsController : Controller
    {

        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        private readonly ICustomFieldRepository _customFieldRepository;
        private readonly ICustomFieldDataRepository _customFieldDataRepository;
        private readonly ICategoryRepository _categoryRepository;

        public CustomFiledsController(
            ICustomFieldRepository customFieldRepository,
            ICustomFieldDataRepository customFieldDataRepository,
            ICategoryRepository categoryRepository,
            IProductRepository productRepository,
            IMapper mapper)
        {

            _productRepository = productRepository;
            _mapper = mapper;
            _customFieldRepository = customFieldRepository;
            _customFieldDataRepository = customFieldDataRepository;
            _categoryRepository = categoryRepository;
        }
        public async Task<IActionResult> Index()
        {
            var result = (await _customFieldRepository.GetAllAsync())
                .Select(x => new ShowAllCustomDataViewModel()
                {
                    Id = x.Id,
                    ProductName = x.Product?.Name,
                    CustomFieldDataValue = x.CustomFieldData?.Value,
                    CustomFieldName = x.CustomFieldData?.CustomField?.Name

                });

            return View(result);
        }
        public async Task<IActionResult> Create()
        {
            ViewBag.Products = new SelectList(await _productRepository.GetAllAsync(), "Id", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CustomFieldViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    var product = await _productRepository.GetByIdAsync(model.ProductId);
                    if (product != null)
                    {

                        var customField = new CustomField()
                        {
                            Name = model.Name,
                            Product = product
                        };
                        var result = await _customFieldRepository.CreateAsync(customField);
                        if (model.Value is not null)
                        {
                            var customFieldData = new CustomFieldData()
                            {
                                Value = model.Value,
                                CustomField = result
                            };
                            var resultData = await _customFieldDataRepository.CreateAsync(customFieldData);

                        }


                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        ViewBag.Products = new SelectList(await _productRepository.GetAllAsync(), "Id", "Name");

                        return View(model);
                    }

                }
                else
                {
                    return View();
                }

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);

                return View();
            }


        }

        public async Task<IActionResult> Details(int id)
        {
            try
            {
                var field = (await _customFieldRepository.GetDetailsAsync(id));
                if (field is null)
                {
                    return NotFound();
                }
                else
                {
                    var result = new DetailscustomFieldDTO()
                    {
                        Id = field.Id,
                        Name = field.Name,
                        customFieldDataDTO = new CustomFieldDataDTO()
                        {
                            Id = field.CustomFieldData.Id,
                            Value = field.CustomFieldData.Value,

                        },
                        ProductDTO = new ProductDTO()
                        {
                            Id = field.Product.Id,
                            Name = field.Product.Name,
                            Description = field.Product.Description,
                            Price = field.Product.Price,
                            Quantity = field.Product.Quantity
                        }
                    };
                    return View(result);
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
            var field = await _customFieldRepository.GetByIdAsync(id);
            if (field == null)
            {
                return NotFound();
            }


            return View(_mapper.Map<CustomFieldDTO>(field));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, CustomFieldDTO field)
        {
            try
            {
                var FieldTemp = await _customFieldRepository.GetDetailsAsync(id);

                if (FieldTemp is null)
                {
                    throw new Exception("Not Found the Category");
                }
                else
                {
                    FieldTemp.Name = field.Name;
                    await _customFieldRepository.UpdateAsync(FieldTemp);
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPost]

        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (await _customFieldRepository.GetDetailsAsync(id) == null)
            {
                return Problem("Entity set 'CustomField '  is null.");
            }
            var product = await _customFieldRepository.GetDetailsAsync(id);
            if (product != null)
            {
                await _customFieldRepository.DeleteAsync(id);
            }
            return RedirectToAction(nameof(Index));
        }

    }


}
