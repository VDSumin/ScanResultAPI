using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ScanResultAPI.DTO;
using ScanResultAPI.Services.Interfaces;
using System;
using System.Text.Json;

namespace ScanResultAPI.Controllers
{
    [Route("api")]
    [ApiController]
    public class ScanController : ControllerBase
    {
        private readonly IScanInfoService _scanInfoService;

        public ScanController(IScanInfoService scanInfoService)
        {
            _scanInfoService = scanInfoService;
        }

        /// <summary>
        /// Получает данные из файла data.json
        /// </summary>
        /// <returns></returns>
        [HttpGet("allData")]
        [ProducesResponseType(typeof(ScanData), 200)]
        [ProducesResponseType(typeof(string), 400)]
        public async Task<IActionResult> GetAllData()
        {
            var scanData = await _scanInfoService.GetScanDataFromFile("data.json");
            
            if(scanData.Succeeded)
            {
                return Ok(scanData.ScanData);
            }

            return BadRequest(scanData.Error);
        }
    }
}
