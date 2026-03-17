namespace TruckPartsInventoryExplorer.Models
{
    public class VehicleInfo
    {

        public string Vin { get; set; } = string.Empty;
        public string Make { get; set; } = "Unknown";
        public string Model { get; set; } = "Unknown";
        public string ModelYear { get; set; } = "Unknown";
        public string VehicleType { get; set; } = "Unknown";
        public string BodyClass { get; set; } = "Unknown";
        public string DriveType { get; set; } = "Unknown";
        public string EngineConfiguration { get; set; } = "Unknown";
        public string EngineCylinders { get; set; } = "Unknown";
        public string BrakeSystemType { get; set; } = "Unknown";
        public string GVWR { get; set; } = "Unknown";

    }
}
