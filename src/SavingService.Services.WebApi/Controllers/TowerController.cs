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
    public class TowerController : ControllerBase
    {
        private readonly ITowerApplication _towerApplication;
        public TowerController(ITowerApplication towerApplication)
        {
            _towerApplication = towerApplication;
        }


        #region Synchronous Methods

        [HttpPost("insert")]
        public IActionResult Insert([FromBody] TowerDto towerDto)
        {
            if (towerDto == null) return BadRequest();

            var response = _towerApplication.Insert(towerDto);

            if (response.IsSuccess) return Ok(response);

            return BadRequest(response.Message);
        }

        [HttpPut("update")]
        public IActionResult Update([FromBody] TowerDto towerDto)
        {
            if (towerDto == null) return BadRequest();

            var response = _towerApplication.Update(towerDto);

            if (response.IsSuccess) return Ok(response);

            return BadRequest(response.Message);
        }

        [HttpDelete("delete/{towerId}")]
        public IActionResult Delete(int towerId)
        {
            if (towerId <= 0) return BadRequest();

            var response = _towerApplication.Delete(towerId);

            if (response.IsSuccess) return Ok(response);

            return BadRequest(response.Message);
        }

        [HttpGet("get/{towerId}")]
        public IActionResult Get(int towerId)
        {
            if (towerId <= 0) return BadRequest();

            var response = _towerApplication.Get(towerId);

            if (response.IsSuccess) return Ok(response);

            return BadRequest(response.Message);
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var response = _towerApplication.GetAll();

            if (response.IsSuccess) return Ok(response);

            return BadRequest(response.Message);
        }
        #endregion

        #region Asynchronous Methods

        [HttpPost("insertAsync{towerDto}")]
        public async Task<IActionResult> InsertAsync([FromBody] TowerDto towerDto)
        {
            if (towerDto == null) return BadRequest();

            var response = await _towerApplication.InsertAsync(towerDto);

            if (response.IsSuccess) return Ok(response);

            return BadRequest(response.Message);
        }

        [HttpPut("updateAsync/{towerDto}")]
        public async Task<IActionResult> UpdateAsync([FromBody] TowerDto towerDto)
        {
            if (towerDto == null) return BadRequest();

            var response = await _towerApplication.UpdateAsync(towerDto);

            if (response.IsSuccess) return Ok(response);

            return BadRequest(response.Message);
        }

        [HttpDelete("deleteAsync/{towerId}")]
        public async Task<IActionResult> DeleteAsync(int towerId)
        {
            if (towerId <= 0) return BadRequest();

            var response = await _towerApplication.DeleteAsync(towerId);

            if (response.IsSuccess) return Ok(response);

            return BadRequest(response.Message);
        }

        [HttpGet("getAsync/{towerId}")]
        public async Task<IActionResult> GetAsync(int towerId)
        {
            if (towerId <= 0) return BadRequest();

            var response = await _towerApplication.GetAsync(towerId);

            if (response.IsSuccess) return Ok(response);

            return BadRequest(response.Message);
        }

        [HttpGet("getallAsync")]
        public async Task<IActionResult> GetAllAsync()
        {
            var response = await _towerApplication.GetAllAsync();

            if (response.IsSuccess) return Ok(response);

            return BadRequest(response.Message);
        }
        #endregion
    }
}
