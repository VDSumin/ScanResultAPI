using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using ScanResultAPI.DTO;
using ScanResultAPI.Services.Interfaces;
using System;
using System.IO;
using System.Text.Json;

namespace ScanResultAPI.Controllers
{
    [Route("api")]
    [ApiController]
    public class ScanController : ControllerBase
    {
        private readonly IScanInfoService _scanInfoService;
        private readonly IWebHostEnvironment _hostEnvironment;

        public ScanController(IScanInfoService scanInfoService, IWebHostEnvironment hostEnvironment)
        {
            _scanInfoService = scanInfoService;
            _hostEnvironment = hostEnvironment;
        }

        /// <summary>
        /// Получает данные из файла data.json
        /// </summary>
        [HttpGet("allData")]
        [ProducesResponseType(typeof(string), 200)]
        [ProducesResponseType(typeof(string), 400)]
        public async Task<IActionResult> GetAllData()
        {
            string path = Path.Combine(_hostEnvironment.WebRootPath, "data.json");
            if (!System.IO.File.Exists(path))
            {
                return BadRequest("Файл data.json не найден");
            }

            using StreamReader file = System.IO.File.OpenText(path);
            string fileData = await file.ReadToEndAsync();
            return Ok(fileData);
        }

        /// <summary>
        /// Выдаёт данные из свойства scan. scanTime, db, server, errorCount
        /// </summary>
        [HttpGet("scan")]
        [ProducesResponseType(typeof(ScanInfo), 200)]
        public IActionResult getScanInfo()
        {
            var result = _scanInfoService.GetScanInfo();
            return Ok(result);
        }

        /// <summary>
        /// Выдаёт список файлов, у которых свойство result = correct.
        /// </summary>
        [HttpGet("filenames")]
        [ProducesResponseType(typeof(List<string>), 200)]
        public IActionResult GetFiles(bool correct)
        {
            var result = _scanInfoService.GetFilesNames(correct);
            return Ok(result);
        }

        /// <summary>
        /// Выдаёт список файлов с ошибками
        /// </summary>
        [HttpGet("errors")]
        [ProducesResponseType(typeof(List<DTO.FileWithError>), 200)]
        public IActionResult GetFilesWithError()
        {
            var result = _scanInfoService.GetFilesWithError();
            return Ok(result);
        }

        /// <summary>
        /// Выдаёт количество ошибок.
        /// </summary>
        [HttpGet("errors/count")]
        [ProducesResponseType(typeof(int), 200)]
        public IActionResult GetErrorCount()
        {
            var result = _scanInfoService.GetScanInfo()?.ErrorCount;
            return Ok(result);
        }

        /// <summary>
        /// Выдаёт файл с ошибкой.
        /// </summary>
        [HttpGet("errors/{index}")]
        [ProducesResponseType(typeof(DTO.FileWithError), 200)]
        public IActionResult GetFileWithError(int index)
        {
            int errorCount = _scanInfoService.GetScanInfo().ErrorCount;
            if (errorCount == 0)
            {
                return BadRequest("Файлы с ошибками не найдены");
            }
            index %= errorCount;
            Index i = index < 0 ? (errorCount + index) : index;

            var result = _scanInfoService.GetFilesWithError()[i];
            return Ok(result);
        }

        /// <summary>
        /// Выдаёт статистику по файлам query_%.
        /// </summary>
        [HttpGet("query/check")]
        [ProducesResponseType(typeof(DTO.Statistic), 200)]
        public IActionResult GetStatistic()
        {
            var result = _scanInfoService.GetStatistic();
            return Ok(result);
        }
    }
}
