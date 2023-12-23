using CatenaccioStore.API.Infrastructure.constans;
using CatenaccioStore.Application.Services.Products.Abstraction;
using CatenaccioStore.Application.Services.Products.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace CatenaccioStore.API.Controllers
{
    public class CategoryController : BaseController
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        //[Authorize(Roles = UserType.AdminModerator)]
        [HttpGet]
        public async Task<IActionResult> GetCategories(CancellationToken token)
        {
            try
            {
                return Ok(await _categoryService.GetAll(token));
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                return StatusCode(500, "Internal Server Error");
            }
        }
        //[Authorize(Roles = UserType.AdminModerator)]
        [HttpPost("AddCategory")]
        public async Task<IActionResult> AddCategory(CancellationToken token, CreateCategoryDto input)
        {
            try
            {
                return Ok(await _categoryService.AddCategory(token, input));
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                return StatusCode(500, "Internal Server Error");
            }
        }
        //[Authorize(Roles = UserType.AdminModerator)]
        [HttpPut("Update")]
        public async Task<IActionResult> Update(CancellationToken token, string categoryName, string newCategoryName)
        {
            try
            {
                return Ok(await _categoryService.UpdateCategory(token, categoryName, newCategoryName));
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                return StatusCode(500, "Internal Server Error");
            }
        }
        //[Authorize(Roles = UserType.AdminModerator)]
        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(CancellationToken token,string categoryName)
        {
            try
            {
                return Ok(await _categoryService.DeleteCategory(token, categoryName));
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                return StatusCode(500, "Internal Server Error");
            }
        }
    }
}
