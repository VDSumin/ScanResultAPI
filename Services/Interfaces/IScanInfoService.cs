using ScanResultAPI.DTO;

namespace ScanResultAPI.Services.Interfaces
{
    public interface IScanInfoService
    {
        public Task<(bool Succeeded, string Error, ScanData? ScanData)> GetScanDataFromFile(string fileName);
    }
}
