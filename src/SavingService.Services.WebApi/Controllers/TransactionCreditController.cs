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

        [HttpDelete("delete/{transactionId}")]
        public IActionResult Delete(int transactionId)
        {
            if (transactionId <= 0) return BadRequest();

            var response = _transactionCreditApplication.Delete(transactionId);

            if (response.IsSuccess) return Ok(response);

            return BadRequest(response.Message);
        }

        [HttpGet("get/{transactionId}")]
        public IActionResult Get(int transactionId)
        {
            if (transactionId <= 0) return BadRequest();

            var response = _transactionCreditApplication.Get(transactionId);

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

        [HttpGet("getallCmp")]
        public IActionResult GetAllCmp()
        {
            var response = _transactionCreditApplication.GetAllCmp();

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

        [HttpDelete("deleteAsync/{transactionId}")]
        public async Task<IActionResult> DeleteAsync(int transactionId)
        {
            if (transactionId <= 0) return BadRequest();

            var response = await _transactionCreditApplication.DeleteAsync(transactionId);

            if (response.IsSuccess) return Ok(response);

            return BadRequest(response.Message);
        }

        [HttpGet("getAsync/{transactionId}")]
        public async Task<IActionResult> GetAsync(int transactionId)
        {
            if (transactionId <= 0) return BadRequest();

            var response = await _transactionCreditApplication.GetAsync(transactionId);

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

