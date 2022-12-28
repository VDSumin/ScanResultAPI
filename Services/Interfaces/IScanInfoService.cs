using ScanResultAPI.DTO;

namespace ScanResultAPI.Services.Interfaces
{
    public interface IScanInfoService
    {
        Task<(bool Succeeded, IList<string> Errors, ScanData? ScanData)> GetScanDataFromText(string data);
        ScanInfo? GetScanInfo();
        IList<string> GetFilesNames(bool result);
        IList<DTO.FileWithError> GetFilesWithError();
        Statistic GetStatistic();
    }
}
