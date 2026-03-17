using System.Text.Json.Serialization;

namespace TruckPartsInventoryExplorer.Models
{
    public class VpicResponse
    {
        [JsonPropertyName("Results")]
        public List<VpicVehicleResult> Results { get; set; } = new();
    }

    public class VpicVehicleResult
    {
        [JsonPropertyName("Make")]
        public string? Make { get; set; }

        [JsonPropertyName("Model")]
        public string? Model { get; set; }

        [JsonPropertyName("ModelYear")]
        public string? ModelYear { get; set; }

        [JsonPropertyName("VehicleType")]
        public string? VehicleType { get; set; }

        [JsonPropertyName("BodyClass")]
        public string? BodyClass { get; set; }

        [JsonPropertyName("DriveType")]
        public string? DriveType { get; set; }

        [JsonPropertyName("EngineConfiguration")]
        public string? EngineConfiguration { get; set; }

        [JsonPropertyName("EngineNumberOfCylinders")]
        public string? EngineNumberOfCylinders { get; set; }

        [JsonPropertyName("BrakeSystemType")]
        public string? BrakeSystemType { get; set; }

        [JsonPropertyName("GrossVehicleWeightRatingFrom")]
        public string? GrossVehicleWeightRatingFrom { get; set; }

        [JsonPropertyName("ErrorCode")]
        public string? ErrorCode { get; set; }

        [JsonPropertyName("ErrorText")]
        public string? ErrorText { get; set; }
    }
}
