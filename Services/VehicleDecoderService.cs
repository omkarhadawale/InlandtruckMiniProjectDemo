using System.Text.Json;
using TruckPartsInventoryExplorer.Models;


namespace TruckPartsInventoryExplorer.Services;

public class VehicleDecoderService
{
    private readonly HttpClient _httpClient;

    public VehicleDecoderService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<VehicleInfo?> DecodeVinAsync(string vin)
    {
        if (string.IsNullOrWhiteSpace(vin))
            return null;

        vin = vin.Trim().ToUpperInvariant();

        var url = $"https://vpic.nhtsa.dot.gov/api/vehicles/DecodeVinValues/{vin}?format=json";

        using var response = await _httpClient.GetAsync(url);

        if (!response.IsSuccessStatusCode)
            throw new Exception("Failed to contact the vehicle decoding service.");

        var stream = await response.Content.ReadAsStreamAsync();
        var data = await JsonSerializer.DeserializeAsync<VpicResponse>(stream);

        if (data == null || data.Results.Count == 0)
            return null;

        var first = data.Results.First();

        return new VehicleInfo
        {
            Vin = vin,
            Make = string.IsNullOrWhiteSpace(first.Make) ? "Unknown" : first.Make,
            Model = string.IsNullOrWhiteSpace(first.Model) ? "Unknown" : first.Model,
            ModelYear = string.IsNullOrWhiteSpace(first.ModelYear) ? "Unknown" : first.ModelYear,
            VehicleType = string.IsNullOrWhiteSpace(first.VehicleType) ? "Unknown" : first.VehicleType,
            BodyClass = string.IsNullOrWhiteSpace(first.BodyClass) ? "Unknown" : first.BodyClass,
            DriveType = string.IsNullOrWhiteSpace(first.DriveType) ? "Unknown" : first.DriveType,
            EngineConfiguration = string.IsNullOrWhiteSpace(first.EngineConfiguration) ? "Unknown" : first.EngineConfiguration,
            EngineCylinders = string.IsNullOrWhiteSpace(first.EngineNumberOfCylinders) ? "Unknown" : first.EngineNumberOfCylinders,
            BrakeSystemType = string.IsNullOrWhiteSpace(first.BrakeSystemType) ? "Unknown" : first.BrakeSystemType,
            GVWR = string.IsNullOrWhiteSpace(first.GrossVehicleWeightRatingFrom) ? "Unknown" : first.GrossVehicleWeightRatingFrom
        };
    }
}