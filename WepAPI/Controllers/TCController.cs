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
    public class TCController : ControllerBase
    {
        bool status;
        public async void TcDogrula(string name, string lastName, long identityNumber, int birthDate)
        {
            using (tcNoDogrula.KPSPublicSoapClient servis = new tcNoDogrula.KPSPublicSoapClient(tcNoDogrula.KPSPublicSoapClient.EndpointConfiguration.KPSPublicSoap))
            {
                var response = await servis.TCKimlikNoDogrulaAsync(identityNumber, name.ToUpper(), lastName.ToUpper(), birthDate);
                status = response.Body.TCKimlikNoDogrulaResult;
                
            }
        }


        [HttpGet("tcdogrula")]
        public IActionResult TcDogrulamaFrontEnd(string name, string lastName, long identityNumber, int birthDate)
        {
            TcDogrula(name, lastName, identityNumber, birthDate);
            Thread.Sleep(2000);
                return Ok(status);
        }


    }
}
