using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;
using ScanResultAPI.DTO;
using ScanResultAPI.Services.Interfaces;

namespace ScanResultAPI.Services
{
    public class ScanInfoService : IScanInfoService
    {
        private readonly IWebHostEnvironment _hostEnvironment;
        private readonly ScanData? _scanData;

        public ScanInfoService(IWebHostEnvironment hostEnvironment)
        {
            _hostEnvironment = hostEnvironment;
            var path = Path.Combine(_hostEnvironment.WebRootPath, "data.json");
            _scanData = GetScanData(path);
        }

        public async Task<(bool Succeeded, string Error, ScanData? ScanData)> GetScanDataFromFile(string fileName)
        {
            if (fileName.Equals("data.json"))
            {
                return (true, "", _scanData);
            }

            var path = Path.Combine(_hostEnvironment.WebRootPath, fileName);
            
            if (!System.IO.File.Exists(path))
            {
                return (false, "Файл не найден", null);
            }
            
            ScanData? scanData = GetScanData(path);

            return (true, "", scanData);
        }

        private static ScanData? GetScanData(string path)
        {
            using StreamReader file = System.IO.File.OpenText(path);
            JsonSerializer serializer = new JsonSerializer();
            ScanData? scanData = (ScanData)serializer.Deserialize(file, typeof(ScanData));
            return scanData;
        }

    }
}
