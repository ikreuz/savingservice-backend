using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SavingService.Application.Interface;
using System.Threading.Tasks;

namespace SavingService.Services.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SavingAccountController : ControllerBase
    {
        //private readonly ISavingAccountApplication _savingAccountApplication;
        //public SavingAccountController(ISavingAccountApplication savingAccountApplication)
        //{
        //    _savingAccountApplication = savingAccountApplication;
        //}


        //#region Synchronous Methods

        //[HttpGet("get/{accountId}")]
        //public IActionResult Get(int accountId)
        //{
        //    if (accountId <= 0) return BadRequest();

        //    var response = _savingAccountApplication.Get(accountId);

        //    if (response.IsSuccess) return Ok(response);

        //    return BadRequest(response.Message);
        //}

        //#endregion

        //#region Asynchronous Methods

        //[HttpGet("getAsync/{accountId}")]
        //public async Task<IActionResult> GetAsync(int accountId)
        //{
        //    if (accountId <= 0) return BadRequest();

        //    var response = await _savingAccountApplication.GetAsync(accountId);

        //    if (response.IsSuccess) return Ok(response);

        //    return BadRequest(response.Message);
        //}

        //#endregion
    }
}