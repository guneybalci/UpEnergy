using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BalancesController : ControllerBase
    {
        IBalanceService _balanceService;
        public BalancesController(IBalanceService balanceService)
        {
                _balanceService = balanceService;
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int balanceId)
        {
            var result= _balanceService.GetById(balanceId);

            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _balanceService.GetAll();

            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }

        [HttpGet("getlistbycustomerid")]
        public IActionResult GetListByCustomerId(int customerId)
        {
            var result = _balanceService.GetListByCustomerId(customerId);

            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }

        [HttpPost("add")]
        public IActionResult Add(Balance balance)
        {
            var result = _balanceService.Add(balance);
            if (result.Success)
            {
                //return Ok(result.Data.Select(x=> new Order
                //{
                //    Id = x.Id,
                //    OrderNo= x.OrderNo,
                //    Status = x.Status
                //}));

                return Ok(result);
            }

            return BadRequest(result.Message);
        }

        [HttpPost("update")]
        public IActionResult Update(Balance balance)
        {
            var result = _balanceService.Update(balance);

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
        public IActionResult Delete(Balance balance)
        {
            var result = _balanceService.Delete(balance);

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
