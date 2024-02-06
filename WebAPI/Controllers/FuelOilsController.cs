using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuelOilsController : ControllerBase
    {
        IFuelOilService _fuelOilService;
        public FuelOilsController(IFuelOilService fuelOilService)
        {
             _fuelOilService = fuelOilService;
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int fuelOildId)
        {
            var result = _fuelOilService.GetById(fuelOildId);

            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _fuelOilService.GetAll();

            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }

        [HttpPost("add")]
        public IActionResult Add(FuelOil fuelOil)
        {
            var result = _fuelOilService.Add(fuelOil);

            if (result.Success)
            {
                return Ok(result.Message);
            }
            else
            {
                return BadRequest(result.Message);
            }
        }

        [HttpPost("update")]
        public IActionResult Update(FuelOil fuelOil)
        {
            var result = _fuelOilService.Update(fuelOil);

            if (result.Success)
            {
                return Ok(result.Message);
            }
            else
            {
                return BadRequest(result.Message);
            }
        }

        [HttpPost("delete")]
        public IActionResult Delete(FuelOil fuelOil)
        {
            var result = _fuelOilService.Delete(fuelOil);

            if (result.Success)
            {
                return Ok(result.Message);
            }
            else
            {
                return BadRequest(result.Message);
            }
        }
    }
}
