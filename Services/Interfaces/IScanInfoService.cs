using ScanResultAPI.DTO;

namespace ScanResultAPI.Services.Interfaces
{
    public interface IScanInfoService
    {
        Task<(bool Succeeded, string Error, ScanData? ScanData)> GetScanDataFromFile(string fileName);
        ScanInfo? GetScanInfo();
        IList<string> GetFilesNames(bool result);
        IList<DTO.FileWithError> GetFilesWithError();
        Statistic GetStatistic();
    }
}
