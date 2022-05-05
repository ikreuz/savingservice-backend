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
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionApplication _transactionApplication;
        public TransactionController(ITransactionApplication transactionApplication)
        {
            _transactionApplication = transactionApplication;
        }


        #region Synchronous Methods

        [HttpPost("insert")]
        public IActionResult Insert([FromBody] TransactionDto transactionDto)
        {
            if (transactionDto == null) return BadRequest();

            var response = _transactionApplication.Insert(transactionDto);

            if (response.IsSuccess) return Ok(response);

            return BadRequest(response.Message);
        }

        [HttpPut("update")]
        public IActionResult Update([FromBody] TransactionDto transactionDto)
        {
            if (transactionDto == null) return BadRequest();

            var response = _transactionApplication.Update(transactionDto);

            if (response.IsSuccess) return Ok(response);

            return BadRequest(response.Message);
        }

        [HttpDelete("delete/{userDataId}")]
        public IActionResult Delete(int userDataId)
        {
            if (userDataId <= 0) return BadRequest();

            var response = _transactionApplication.Delete(userDataId);

            if (response.IsSuccess) return Ok(response);

            return BadRequest(response.Message);
        }

        [HttpGet("get/{userDataId}")]
        public IActionResult Get(int userDataId)
        {
            if (userDataId <= 0) return BadRequest();

            var response = _transactionApplication.Get(userDataId);

            if (response.IsSuccess) return Ok(response);

            return BadRequest(response.Message);
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var response = _transactionApplication.GetAll();

            if (response.IsSuccess) return Ok(response);

            return BadRequest(response.Message);
        }
        #endregion

        #region Asynchronous Methods

        [HttpPost("insertAsync{transactionDto}")]
        public async Task<IActionResult> InsertAsync([FromBody] TransactionDto transactionDto)
        {
            if (transactionDto == null) return BadRequest();

            var response = await _transactionApplication.InsertAsync(transactionDto);

            if (response.IsSuccess) return Ok(response);

            return BadRequest(response.Message);
        }

        [HttpPut("updateAsync/{transactionDto}")]
        public async Task<IActionResult> UpdateAsync([FromBody] TransactionDto transactionDto)
        {
            if (transactionDto == null) return BadRequest();

            var response = await _transactionApplication.UpdateAsync(transactionDto);

            if (response.IsSuccess) return Ok(response);

            return BadRequest(response.Message);
        }

        [HttpDelete("deleteAsync/{userDataId}")]
        public async Task<IActionResult> DeleteAsync(int userDataId)
        {
            if (userDataId <= 0) return BadRequest();

            var response = await _transactionApplication.DeleteAsync(userDataId);

            if (response.IsSuccess) return Ok(response);

            return BadRequest(response.Message);
        }

        [HttpGet("getAsync/{userDataId}")]
        public async Task<IActionResult> GetAsync(int userDataId)
        {
            if (userDataId <= 0) return BadRequest();

            var response = await _transactionApplication.GetAsync(userDataId);

            if (response.IsSuccess) return Ok(response);

            return BadRequest(response.Message);
        }

        [HttpGet("getallAsync")]
        public async Task<IActionResult> GetAllAsync()
        {
            var response = await _transactionApplication.GetAllAsync();

            if (response.IsSuccess) return Ok(response);

            return BadRequest(response.Message);
        }
        #endregion
    }
}
