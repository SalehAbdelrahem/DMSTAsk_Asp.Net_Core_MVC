using AutoMapper;
using BLL.DTOs.Categories;
using DAL.Contacts.Categories;
using DAL.Models;

namespace BLL.Services
{
    public class ServiceCategory
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public ServiceCategory(ICategoryRepository categoryRepository , IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CategoryDTO>> GetCategories() {


            try{
               var result= await _categoryRepository.GetAllAsync();
                if(result is  null)
                {
                    throw new Exception("Not Fount Any Category");

                }
                else
                {
                    return _mapper.Map<IEnumerable<CategoryDTO>>(result);
                }

            }
            catch (Exception ex){
            throw new Exception(ex.Message);
            }
        }

        public async Task<CategoryDTO> GetCategoryById(int id)
        {


            try
            {
                var result = await _categoryRepository.GetByIdAsync(id);
                if (result is null)
                {
                    throw new Exception("Not Fount Any Category");

                }
                else
                {
                    return _mapper.Map<CategoryDTO>(result);
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async void AddCategory(CategoryDTO categoryDTO)
        {
            try
            {
                var tempCategory=_mapper.Map<Category>(categoryDTO);
                var category = await _categoryRepository.CreateAsync(tempCategory);
                if(category is null)
                {
                    throw new Exception($"Can Not Creat A category For name = {categoryDTO.Name} ");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async void UpdateCategory(CategoryDTO categoryDTO)
        {
            try
            {
                var result =await _categoryRepository.GetByIdAsync(categoryDTO.Id);
                if(result is null)
                {
                    throw new Exception("Not Found the Category");
                }
                else
                {
                    result.Name = categoryDTO.Name;
                   await _categoryRepository.UpdateAsync(result); 
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async void DeleteCategory(int categoryId)
        {
            try
            {
                var result = _categoryRepository.GetByIdAsync(categoryId);
                if (result is null)
                {
                    throw new Exception("Not Found the Category");
                }
                else
                {
                    await _categoryRepository.DeleteAsync(categoryId);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


    }

}
