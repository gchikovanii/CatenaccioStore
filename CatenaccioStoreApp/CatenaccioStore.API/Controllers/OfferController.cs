using CatenaccioStore.API.Infrastructure.constans;
using CatenaccioStore.Application.Services.Products.Abstraction;
using CatenaccioStore.Application.Services.Products.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace CatenaccioStore.API.Controllers
{
    public class OfferController : BaseController
    {
        private readonly IOfferService _offerService;

        public OfferController(IOfferService offerService)
        {
            _offerService = offerService;
        }
        [Authorize(Roles = UserType.AdminModerator)]
        [HttpGet]
        public async Task<IActionResult> GetCategories(CancellationToken token)
        {
            try
            {
                return Ok(await _offerService.GetAllOffers(token));
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                return StatusCode(500, "Internal Server Error");
            }
        }
        [Authorize(Roles = UserType.AdminModerator)]
        [HttpPost]
        public async Task<IActionResult> AddCategory(CancellationToken token, OfferDto input)
        {
            try
            {
                return Ok(await _offerService.CreateAsync(token, input));
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                return StatusCode(500, "Internal Server Error");
            }
        }
       
        [Authorize(Roles = UserType.AdminModerator)]
        [HttpDelete]
        public async Task<IActionResult> Delete(CancellationToken token, string categoryName)
        {
            try
            {
                return Ok(await _offerService.DeleteAsync(token, categoryName));
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                return StatusCode(500, "Internal Server Error");
            }
        }


    }
}
