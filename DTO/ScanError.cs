using Newtonsoft.Json;

namespace ScanResultAPI.DTO
{
    public class ScanError
    {
        public string Module { get; set; }
        public int ECode { get; set; }
        public string Error { get; set; }
    }
}