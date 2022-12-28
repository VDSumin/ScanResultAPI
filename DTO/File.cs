using Newtonsoft.Json;

namespace ScanResultAPI.DTO
{
    public class File
    {
        [JsonProperty("filename")]
        public string Name { get; set; }
        public bool Result { get; set; }
        public List<Error> Errors { get; set; }
        public DateTime ScanTime { get; set; }
    }
}
