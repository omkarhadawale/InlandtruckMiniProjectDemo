using TruckPartsInventoryExplorer.Models;

namespace TruckPartsInventoryExplorer.Services;

public class PartsSuggestionService
{
    public List<PartSuggestion> GetSuggestions(VehicleInfo vehicle)
    {
        var suggestions = new List<PartSuggestion>();

        var isTruck = Contains(vehicle.VehicleType, "TRUCK");
        var is4wd = Contains(vehicle.DriveType, "4WD") ||
                    Contains(vehicle.DriveType, "4-WHEEL DRIVE") ||
                    Contains(vehicle.DriveType, "4X4") ||
                    Contains(vehicle.DriveType, "AWD");
        var hasHydraulicBrakes = Contains(vehicle.BrakeSystemType, "HYDRAULIC");
        var hasAirBrakes = Contains(vehicle.BrakeSystemType, "AIR");
        var hasEngineInfo = !IsUnknown(vehicle.EngineConfiguration) || !IsUnknown(vehicle.EngineCylinders);
        var hasGvwr = !IsUnknown(vehicle.GVWR);

        if (isTruck)
        {
            suggestions.Add(new PartSuggestion
            {
                Category = "Driveline",
                Relevance = "High",
                Reason = "Vehicle type is Truck, which strongly suggests driveline-related component needs.",
                InlandMatch = "Driveline parts and driveline repair services"
            });

            suggestions.Add(new PartSuggestion
            {
                Category = "Transmission",
                Relevance = "High",
                Reason = "Vehicle type is Truck, making transmission-related service and replacement categories highly relevant.",
                InlandMatch = "Transmission parts and related shop inspection"
            });

            suggestions.Add(new PartSuggestion
            {
                Category = "Differential",
                Relevance = "High",
                Reason = "Truck drivetrains commonly require axle and differential component support.",
                InlandMatch = "Differential parts and gear rebuilding services"
            });
        }

        if (is4wd)
        {
            suggestions.Add(new PartSuggestion
            {
                Category = "Transfer Case",
                Relevance = "High",
                Reason = $"Drive type detected: {vehicle.DriveType}. This directly indicates transfer-case relevance.",
                InlandMatch = "Transfer case parts and drivetrain service"
            });
        }

        if (hasHydraulicBrakes || hasAirBrakes)
        {
            suggestions.Add(new PartSuggestion
            {
                Category = "Brake System",
                Relevance = "High",
                Reason = $"Brake system type detected: {vehicle.BrakeSystemType}.",
                InlandMatch = "Brake components and brake system inspection/service"
            });
        }

        if (isTruck || hasGvwr)
        {
            suggestions.Add(new PartSuggestion
            {
                Category = "Suspension / Springs",
                Relevance = "Medium",
                Reason = "Truck classification or GVWR presence suggests load-bearing suspension relevance.",
                InlandMatch = "Suspension parts, spring parts, and spring repair services"
            });
        }

        if (hasEngineInfo)
        {
            var engineText = $"{Normalize(vehicle.EngineConfiguration)} / {Normalize(vehicle.EngineCylinders)} cylinders";

            suggestions.Add(new PartSuggestion
            {
                Category = "Engine Parts",
                Relevance = "Medium",
                Reason = $"Engine-related data detected: {engineText}.",
                InlandMatch = "Engine-related parts and engine service categories"
            });
        }

        if (isTruck)
        {
            suggestions.Add(new PartSuggestion
            {
                Category = "Shop Services",
                Relevance = "General",
                Reason = "Commercial truck classification makes Inland-style inspection and repair services broadly relevant.",
                InlandMatch = "Gear rebuilding, driveline repair, spring repair, flywheel grinding, custom U-bolt bending"
            });
        }

        return suggestions
            .GroupBy(x => x.Category)
            .Select(g => g.First())
            .OrderByDescending(x => Score(x.Relevance))
            .ThenBy(x => x.Category)
            .ToList();
    }

    private static int Score(string relevance) => relevance switch
    {
        "High" => 3,
        "Medium" => 2,
        _ => 1
    };

    private static bool Contains(string? value, string text) =>
        !string.IsNullOrWhiteSpace(value) &&
        value.Contains(text, StringComparison.OrdinalIgnoreCase);

    private static bool IsUnknown(string? value) =>
        string.IsNullOrWhiteSpace(value) ||
        value.Equals("Unknown", StringComparison.OrdinalIgnoreCase) ||
        value.Equals("Not available from public VIN data", StringComparison.OrdinalIgnoreCase);

    private static string Normalize(string? value) => IsUnknown(value) ? "Unknown" : value!;
}