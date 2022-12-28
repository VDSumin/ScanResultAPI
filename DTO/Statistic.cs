namespace ScanResultAPI.DTO
{
    public class Statistic
    {
        public int Total { get; set; }
        public int Correct { get; set; }
        public int Errors { get; set; }
        public string[]? Files { get; set; }

    }
}
