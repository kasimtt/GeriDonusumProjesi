using Bussines.Abstract;
using Entity.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace WepAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarbonToKYCsController : ControllerBase
    {
        ICarbonToKYCService _carbonToKYCService;

        public CarbonToKYCsController(ICarbonToKYCService carbonToKYCService)
        {
            _carbonToKYCService = carbonToKYCService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            Thread.Sleep(2000);
            var result = _carbonToKYCService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpPost("add")]
        public IActionResult Add(CarbonToKYC carbonToKYC)
        {
            Thread.Sleep(2000);
            var result = _carbonToKYCService.Add(carbonToKYC);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(CarbonToKYC carbonToKYC)
        {
            Thread.Sleep(2000);
            var result = _carbonToKYCService.Delete(carbonToKYC);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(CarbonToKYC carbonToKYC)
        {
            Thread.Sleep(2000);
            var result = _carbonToKYCService.Update(carbonToKYC);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

    }
}
