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
    public class TransactionSavingController : ControllerBase
    {
        private readonly ITransactionSavingApplication _transactionSavingApplication;
        public TransactionSavingController(ITransactionSavingApplication transactionSavingApplication)
        {
            _transactionSavingApplication = transactionSavingApplication;
        }


        #region Synchronous Methods

        [HttpPost("insert")]
        public IActionResult Insert([FromBody] TransactionSavingDto transactionDto)
        {
            if (transactionDto == null) return BadRequest();

            var response = _transactionSavingApplication.Insert(transactionDto);

            if (response.IsSuccess) return Ok(response);

            return BadRequest(response.Message);
        }

        [HttpPut("update")]
        public IActionResult Update([FromBody] TransactionSavingDto transactionDto)
        {
            if (transactionDto == null) return BadRequest();

            var response = _transactionSavingApplication.Update(transactionDto);

            if (response.IsSuccess) return Ok(response);

            return BadRequest(response.Message);
        }

        [HttpDelete("delete/{transactionId}")]
        public IActionResult Delete(int transactionId)
        {
            if (transactionId <= 0) return BadRequest();

            var response = _transactionSavingApplication.Delete(transactionId);

            if (response.IsSuccess) return Ok(response);

            return BadRequest(response.Message);
        }

        [HttpGet("get/{transactionId}")]
        public IActionResult Get(int transactionId)
        {
            if (transactionId <= 0) return BadRequest();

            var response = _transactionSavingApplication.Get(transactionId);

            if (response.IsSuccess) return Ok(response);

            return BadRequest(response.Message);
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var response = _transactionSavingApplication.GetAll();

            if (response.IsSuccess) return Ok(response);

            return BadRequest(response.Message);
        }

        #endregion

        #region Asynchronous Methods

        [HttpPost("insertAsync{transactionDto}")]
        public async Task<IActionResult> InsertAsync([FromBody] TransactionSavingDto transactionDto)
        {
            if (transactionDto == null) return BadRequest();

            var response = await _transactionSavingApplication.InsertAsync(transactionDto);

            if (response.IsSuccess) return Ok(response);

            return BadRequest(response.Message);
        }

        [HttpPut("updateAsync/{transactionDto}")]
        public async Task<IActionResult> UpdateAsync([FromBody] TransactionSavingDto transactionDto)
        {
            if (transactionDto == null) return BadRequest();

            var response = await _transactionSavingApplication.UpdateAsync(transactionDto);

            if (response.IsSuccess) return Ok(response);

            return BadRequest(response.Message);
        }

        [HttpDelete("deleteAsync/{transactionId}")]
        public async Task<IActionResult> DeleteAsync(int transactionId)
        {
            if (transactionId <= 0) return BadRequest();

            var response = await _transactionSavingApplication.DeleteAsync(transactionId);

            if (response.IsSuccess) return Ok(response);

            return BadRequest(response.Message);
        }

        [HttpGet("getAsync/{transactionId}")]
        public async Task<IActionResult> GetAsync(int transactionId)
        {
            if (transactionId <= 0) return BadRequest();

            var response = await _transactionSavingApplication.GetAsync(transactionId);

            if (response.IsSuccess) return Ok(response);

            return BadRequest(response.Message);
        }

        [HttpGet("getallAsync")]
        public async Task<IActionResult> GetAllAsync()
        {
            var response = await _transactionSavingApplication.GetAllAsync();

            if (response.IsSuccess) return Ok(response);

            return BadRequest(response.Message);
        }
        #endregion
    }
}


