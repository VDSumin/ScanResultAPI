using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ScanResultAPI.DTO;

namespace ScanResultAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        /// <summary>
        /// Получение информации о сервере
        /// </summary>
        [ProducesResponseType(typeof(ServerInfo), 200)]
        [HttpGet("serviceInfo")]
        public IActionResult GetServiceInfo()
        {
            ServerInfo info = new();
            var assembly = System.Reflection.Assembly.GetExecutingAssembly().GetName();

            info.AppName = assembly.Name;
            info.Version = assembly.Version?.ToString();
            info.DateUTC = DateTime.UtcNow;

            return Ok(info);
        }
    }
}
