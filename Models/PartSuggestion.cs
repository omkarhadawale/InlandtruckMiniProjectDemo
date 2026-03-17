namespace TruckPartsInventoryExplorer.Models
{
    public class PartSuggestion
    {
        public string Category { get; set; } = string.Empty;
        public string Relevance { get; set; } = string.Empty; // High / Medium / General
        public string Reason { get; set; } = string.Empty;
        public string InlandMatch { get; set; } = string.Empty;
    }
}
