using System.Text.Json.Serialization;

namespace ScanResultAPI.DTO
{
    public class File
    {
        [JsonPropertyName("filename")]
        public string Name { get; set; }
        public bool? Result { get; set; }
        public List<Error>? Errors { get; set; }
        public DateTime? ScanTime { get; set; }
    }
}
