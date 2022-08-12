using System.Text.Json.Serialization;

namespace WebSecurityDemo.Models
{
    public class CspReportRequest
    {
        [JsonPropertyName("csp-report")]
        public CspReport CspReport { get; set; }
    }
}
