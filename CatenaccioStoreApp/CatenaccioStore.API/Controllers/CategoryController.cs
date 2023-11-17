using CatenaccioStore.API.Infrastructure.constans;
using CatenaccioStore.Application.Services.Products.Abstraction;
using CatenaccioStore.Application.Services.Products.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CatenaccioStore.API.Controllers
{
    public class CategoryController : BaseController
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        [Authorize(Roles = UserType.AdminModerator)]
        [HttpGet]
        public async Task<IActionResult> GetCategories(CancellationToken token)
        {
            return Ok(await _categoryService.GetAll(token));
        }
        [Authorize(Roles = UserType.AdminModerator)]
        [HttpPost]
        public async Task<IActionResult> AddCategory(CancellationToken token,CreateCategoryDto input)
        {
            return Ok(await _categoryService.AddCategory(token,input));
        }
        [Authorize(Roles = UserType.AdminModerator)]
        [HttpPut]
        public async Task<IActionResult> Update(CancellationToken token, string categoryName, string newCategoryName)
        {
            return Ok(await _categoryService.UpdateCategory(token,categoryName,newCategoryName));
        }
        [Authorize(Roles = UserType.AdminModerator)]
        [HttpDelete]
        public async Task<IActionResult> Delete(CancellationToken token,string categoryName)
        {
            return Ok(await _categoryService.DeleteCategory(token,categoryName));
        }
    }
}
