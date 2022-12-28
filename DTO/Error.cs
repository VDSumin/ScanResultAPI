using Newtonsoft.Json;

namespace ScanResultAPI.DTO
{
    public class Error
    {
        public string Module { get; set; }

        [JsonProperty("ecode")]
        public int Code { get; set; }

        [JsonProperty("error")]
        public string ErrorMessage { get; set; }
    }
}