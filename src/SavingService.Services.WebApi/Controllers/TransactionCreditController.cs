using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SavingService.Application.DTO;
using SavingService.Application.Interface;
using System.Threading.Tasks;

namespace SavingService.Services.WebApi.Controllers
{
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionCreditController : ControllerBase
    {
        private readonly ITransactionCreditApplication _transactionCreditApplication;
        public TransactionCreditController(ITransactionCreditApplication transactionCreditApplication)
        {
            _transactionCreditApplication = transactionCreditApplication;
        }


        #region Synchronous Methods

        [HttpPost("insert")]
        public IActionResult Insert([FromBody] TransactionCreditDto transactionDto)
        {
            if (transactionDto == null) return BadRequest();

            var response = _transactionCreditApplication.Insert(transactionDto);

            if (response.IsSuccess) return Ok(response);

            return BadRequest(response.Message);
        }

        [HttpPut("update")]
        public IActionResult Update([FromBody] TransactionCreditDto transactionDto)
        {
            if (transactionDto == null) return BadRequest();

            var response = _transactionCreditApplication.Update(transactionDto);

            if (response.IsSuccess) return Ok(response);

            return BadRequest(response.Message);
        }

        [HttpDelete("delete/{userDataId}")]
        public IActionResult Delete(int userDataId)
        {
            if (userDataId <= 0) return BadRequest();

            var response = _transactionCreditApplication.Delete(userDataId);

            if (response.IsSuccess) return Ok(response);

            return BadRequest(response.Message);
        }

        [HttpGet("get/{userDataId}")]
        public IActionResult Get(int userDataId)
        {
            if (userDataId <= 0) return BadRequest();

            var response = _transactionCreditApplication.Get(userDataId);

            if (response.IsSuccess) return Ok(response);

            return BadRequest(response.Message);
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var response = _transactionCreditApplication.GetAll();

            if (response.IsSuccess) return Ok(response);

            return BadRequest(response.Message);
        }
        #endregion

        #region Asynchronous Methods

        [HttpPost("insertAsync{transactionDto}")]
        public async Task<IActionResult> InsertAsync([FromBody] TransactionCreditDto transactionDto)
        {
            if (transactionDto == null) return BadRequest();

            var response = await _transactionCreditApplication.InsertAsync(transactionDto);

            if (response.IsSuccess) return Ok(response);

            return BadRequest(response.Message);
        }

        [HttpPut("updateAsync/{transactionDto}")]
        public async Task<IActionResult> UpdateAsync([FromBody] TransactionCreditDto transactionDto)
        {
            if (transactionDto == null) return BadRequest();

            var response = await _transactionCreditApplication.UpdateAsync(transactionDto);

            if (response.IsSuccess) return Ok(response);

            return BadRequest(response.Message);
        }

        [HttpDelete("deleteAsync/{userDataId}")]
        public async Task<IActionResult> DeleteAsync(int userDataId)
        {
            if (userDataId <= 0) return BadRequest();

            var response = await _transactionCreditApplication.DeleteAsync(userDataId);

            if (response.IsSuccess) return Ok(response);

            return BadRequest(response.Message);
        }

        [HttpGet("getAsync/{userDataId}")]
        public async Task<IActionResult> GetAsync(int userDataId)
        {
            if (userDataId <= 0) return BadRequest();

            var response = await _transactionCreditApplication.GetAsync(userDataId);

            if (response.IsSuccess) return Ok(response);

            return BadRequest(response.Message);
        }

        [HttpGet("getallAsync")]
        public async Task<IActionResult> GetAllAsync()
        {
            var response = await _transactionCreditApplication.GetAllAsync();

            if (response.IsSuccess) return Ok(response);

            return BadRequest(response.Message);
        }
        #endregion
    }
}

