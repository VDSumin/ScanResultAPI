using System.Text.Json.Serialization;

namespace ScanResultAPI.DTO
{
    public class Error
    {
        public string Module { get; set; }

        [JsonPropertyName("ecode")]
        public int Code { get; set; }

        [JsonPropertyName("error")]
        public string ErrorMessage { get; set; }
    }
}