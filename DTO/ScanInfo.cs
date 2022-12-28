namespace ScanResultAPI.DTO
{
    public class ScanInfo
    {
        public DateTime ScanTime { get; set; }
        public string DB { get; set; }
        public string Server { get; set; }
        public int ErrorCount { get; set; }
    }
}
