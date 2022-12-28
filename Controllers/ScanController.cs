using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ScanResultAPI.DTO;

namespace ScanResultAPI.Controllers
{
    [Route("api")]
    [ApiController]
    public class ScanController : ControllerBase
    {
        /// <summary>
        /// Получает данные из файла data.json
        /// </summary>
        /// <returns></returns>
        [HttpGet("allData")]
        [ProducesResponseType(typeof(ScanData), 200)]
        public IActionResult GetAllData()
        {


            return Ok();
        }
    }
}
