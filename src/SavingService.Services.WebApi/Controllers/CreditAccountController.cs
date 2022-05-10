using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SavingService.Application.Interface;
using System.Threading.Tasks;

namespace SavingService.Services.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreditAccountController : ControllerBase
    {
        private readonly ICreditAccountApplication _creditAccountApplication;
        public CreditAccountController(ICreditAccountApplication creditAccountApplication)
        {
            _creditAccountApplication = creditAccountApplication;
        }


        #region Synchronous Methods

        [HttpGet("get/{accountId}")]
        public IActionResult GetAll(int accountId)
        {
            if (accountId <= 0) return BadRequest();

            var response = _creditAccountApplication.Get(accountId);

            if (response.IsSuccess) return Ok(response);

            return BadRequest(response.Message);
        }

        #endregion

        #region Asynchronous Methods

        [HttpGet("getAsync/{accountId}")]
        public async Task<IActionResult> GetAsync(int accountId)
        {
            if (accountId <= 0) return BadRequest();

            var response = await _creditAccountApplication.GetAsync(accountId);

            if (response.IsSuccess) return Ok(response);

            return BadRequest(response.Message);
        }

        #endregion
    }
}