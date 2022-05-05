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
    public class UsersController : ControllerBase
    {
        private readonly IUsersApplication _userDataApplication;
        public UsersController(IUsersApplication userDataApplication)
        {
            _userDataApplication = userDataApplication;
        }


        #region Synchronous Methods

        [HttpPost("insert")]
        public IActionResult Insert([FromBody] UsersDto userDataDto)
        {
            if (userDataDto == null) return BadRequest();

            var response = _userDataApplication.Insert(userDataDto);

            if (response.IsSuccess) return Ok(response);

            return BadRequest(response.Message);
        }

        [HttpPut("update")]
        public IActionResult Update([FromBody] UsersDto userDataDto)
        {
            if (userDataDto == null) return BadRequest();

            var response = _userDataApplication.Update(userDataDto);

            if (response.IsSuccess) return Ok(response);

            return BadRequest(response.Message);
        }

        [HttpDelete("delete/{userDataId}")]
        public IActionResult Delete(int userDataId)
        {
            if (userDataId <= 0) return BadRequest();

            var response = _userDataApplication.Delete(userDataId);

            if (response.IsSuccess) return Ok(response);

            return BadRequest(response.Message);
        }

        [HttpGet("get/{userDataId}")]
        public IActionResult Get(int userDataId)
        {
            if (userDataId <= 0) return BadRequest();

            var response = _userDataApplication.Get(userDataId);

            if (response.IsSuccess) return Ok(response);

            return BadRequest(response.Message);
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var response = _userDataApplication.GetAll();

            if (response.IsSuccess) return Ok(response);

            return BadRequest(response.Message);
        }
        #endregion

        #region Asynchronous Methods

        [HttpPost("insertAsync{userDataDto}")]
        public async Task<IActionResult> InsertAsync([FromBody] UsersDto userDataDto)
        {
            if (userDataDto == null) return BadRequest();

            var response = await _userDataApplication.InsertAsync(userDataDto);

            if (response.IsSuccess) return Ok(response);

            return BadRequest(response.Message);
        }

        [HttpPut("updateAsync/{userDataDto}")]
        public async Task<IActionResult> UpdateAsync([FromBody] UsersDto userDataDto)
        {
            if (userDataDto == null) return BadRequest();

            var response = await _userDataApplication.UpdateAsync(userDataDto);

            if (response.IsSuccess) return Ok(response);

            return BadRequest(response.Message);
        }

        [HttpDelete("deleteAsync/{userDataId}")]
        public async Task<IActionResult> DeleteAsync(int userDataId)
        {
            if (userDataId <= 0) return BadRequest();

            var response = await _userDataApplication.DeleteAsync(userDataId);

            if (response.IsSuccess) return Ok(response);

            return BadRequest(response.Message);
        }

        [HttpGet("getAsync/{userDataId}")]
        public async Task<IActionResult> GetAsync(int userDataId)
        {
            if (userDataId <= 0) return BadRequest();

            var response = await _userDataApplication.GetAsync(userDataId);

            if (response.IsSuccess) return Ok(response);

            return BadRequest(response.Message);
        }

        [HttpGet("getallAsync")]
        public async Task<IActionResult> GetAllAsync()
        {
            var response = await _userDataApplication.GetAllAsync();

            if (response.IsSuccess) return Ok(response);

            return BadRequest(response.Message);
        }
        #endregion
    }
}
