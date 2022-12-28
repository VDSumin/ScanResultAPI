using Newtonsoft.Json;

namespace ScanResultAPI.DTO
{
    public class File
    {
        public string FileName { get; set; }
        public bool Result { get; set; }
        public List<ScanError> Errors { get; set; }
        public DateTime ScanTime { get; set; }
    }
}
