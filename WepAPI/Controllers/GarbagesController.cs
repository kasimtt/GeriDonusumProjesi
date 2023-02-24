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
    public class GarbagesController : ControllerBase
    {
        IGarbageService _garbageService;
        public GarbagesController(IGarbageService garbageService)
        {
            _garbageService = garbageService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            Thread.Sleep(2000);
            var result = _garbageService.GetAll();
            if(result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyname")]
        public IActionResult GetByName(string name)
        {
            Thread.Sleep(2000);
            var result = _garbageService.GetByName(name);
            if(result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

    

        [HttpPost("delete")]
        public IActionResult Delete(Garbage garbage)
        {
            Thread.Sleep(2000);
            var result = _garbageService.Delete(garbage);
            if(result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(Garbage garbage)
        {
            Thread.Sleep(2000);
            var result = _garbageService.Update(garbage);
            if(result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }

        [HttpGet("add")]
        public IActionResult Add(Garbage garbage) 
        {
            var result = _garbageService.Add(garbage);
            if( result.Success) 
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
