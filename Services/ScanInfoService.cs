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

        public async Task<(bool Succeeded, IList<string> Errors, ScanData? ScanData)> GetScanDataFromText(string data)
        {


            return (true, new List<string>(), null);
        }

        private static ScanData? GetScanData(string path)
        {
            using StreamReader file = System.IO.File.OpenText(path);
            JsonSerializer serializer = new JsonSerializer();
            ScanData? scanData = (ScanData)serializer.Deserialize(file, typeof(ScanData));
            return scanData;
        }

        public ScanInfo? GetScanInfo()
        {
            return _scanData?.Scan;
        }

        public IList<string> GetFilesNames(bool result)
        {
            var files = _scanData?.Files.Where(f => f.Result == result).Select(f => f.FileName).ToList();

            return files;
        }

        public IList<DTO.FileWithError> GetFilesWithError()
        {
            var files = _scanData?.Files.Where(f => f.Result == false).Select(f => new FileWithError
            {
                Name = f.FileName,
                Errors = f.Errors.Select(e => e.Error).ToList()
            }).ToList();
            return files;
        }

        public Statistic GetStatistic()
        {
            var files = _scanData?.Files.Where(f => f.FileName.ToLower().TrimStart().StartsWith("query_")).ToList();

            int total = files.Count;

            var errorFiles = files.Where(f => f.Result == false).Select(f => f.FileName).ToArray();
            int errors = errorFiles.Count();
            int correct = total - errors;

            var result = new Statistic
            {
                Total = total,
                Correct = correct,
                Errors = errors,
                Files = errorFiles
            };
            return result;
        }


    }
}
