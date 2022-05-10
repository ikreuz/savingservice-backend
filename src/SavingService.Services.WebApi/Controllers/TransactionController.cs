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
        //private readonly ITransactionApplication _transactionApplication;
        //public TransactionController(ITransactionApplication transactionApplication)
        //{
        //    _transactionApplication = transactionApplication;
        //}


        //#region Synchronous Methods

        //[HttpPost("insert")]
        //public IActionResult Insert([FromBody] TransactionDto transactionDto)
        //{
        //    if (transactionDto == null) return BadRequest();

        //    var response = _transactionApplication.Insert(transactionDto);

        //    if (response.IsSuccess) return Ok(response);

        //    return BadRequest(response.Message);
        //}

        //[HttpPut("update")]
        //public IActionResult Update([FromBody] TransactionDto transactionDto)
        //{
        //    if (transactionDto == null) return BadRequest();

        //    var response = _transactionApplication.Update(transactionDto);

        //    if (response.IsSuccess) return Ok(response);

        //    return BadRequest(response.Message);
        //}

        //[HttpDelete("delete/{transactionId}")]
        //public IActionResult Delete(int transactionId)
        //{
        //    if (transactionId <= 0) return BadRequest();

        //    var response = _transactionApplication.Delete(transactionId);

        //    if (response.IsSuccess) return Ok(response);

        //    return BadRequest(response.Message);
        //}

        //[HttpGet("get/{transactionId}")]
        //public IActionResult Get(int transactionId)
        //{
        //    if (transactionId <= 0) return BadRequest();

        //    var response = _transactionApplication.Get(transactionId);

        //    if (response.IsSuccess) return Ok(response);

        //    return BadRequest(response.Message);
        //}

        //[HttpGet("getall")]
        //public IActionResult GetAll()
        //{
        //    var response = _transactionApplication.GetAll();

        //    if (response.IsSuccess) return Ok(response);

        //    return BadRequest(response.Message);
        //}
        //#endregion

        //#region Asynchronous Methods

        //[HttpPost("insertAsync{transactionDto}")]
        //public async Task<IActionResult> InsertAsync([FromBody] TransactionDto transactionDto)
        //{
        //    if (transactionDto == null) return BadRequest();

        //    var response = await _transactionApplication.InsertAsync(transactionDto);

        //    if (response.IsSuccess) return Ok(response);

        //    return BadRequest(response.Message);
        //}

        //[HttpPut("updateAsync/{transactionDto}")]
        //public async Task<IActionResult> UpdateAsync([FromBody] TransactionDto transactionDto)
        //{
        //    if (transactionDto == null) return BadRequest();

        //    var response = await _transactionApplication.UpdateAsync(transactionDto);

        //    if (response.IsSuccess) return Ok(response);

        //    return BadRequest(response.Message);
        //}

        //[HttpDelete("deleteAsync/{transactionId}")]
        //public async Task<IActionResult> DeleteAsync(int transactionId)
        //{
        //    if (transactionId <= 0) return BadRequest();

        //    var response = await _transactionApplication.DeleteAsync(transactionId);

        //    if (response.IsSuccess) return Ok(response);

        //    return BadRequest(response.Message);
        //}

        //[HttpGet("getAsync/{transactionId}")]
        //public async Task<IActionResult> GetAsync(int transactionId)
        //{
        //    if (transactionId <= 0) return BadRequest();

        //    var response = await _transactionApplication.GetAsync(transactionId);

        //    if (response.IsSuccess) return Ok(response);

        //    return BadRequest(response.Message);
        //}

        //[HttpGet("getallAsync")]
        //public async Task<IActionResult> GetAllAsync()
        //{
        //    var response = await _transactionApplication.GetAllAsync();

        //    if (response.IsSuccess) return Ok(response);

        //    return BadRequest(response.Message);
        //}
        //#endregion
    }
}
