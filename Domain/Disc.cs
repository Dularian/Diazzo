namespace Diazzo.Domain;

public class Disc
{
    [JsonPropertyName("Manufacturer / Distributor")]
    public string ManufacturerDistributor { get; set; } = string.Empty;

    [JsonPropertyName("Disc Model")]
    public string DiscModel { get; set; } = string.Empty;

    [JsonPropertyName("Max Weight (gr)")]
    public double MaxWeightgr { get; set; }

    [JsonPropertyName("Diameter (cm)")]
    public double Diametercm { get; set; }

    [JsonPropertyName("Height (cm)")]
    public int Heightcm { get; set; }

    [JsonPropertyName("Rim Depth (cm)")]
    public double RimDepthcm { get; set; }

    [JsonPropertyName("Inside Rim Diameter (cm)")]
    public double InsideRimDiametercm { get; set; }

    [JsonPropertyName("Rim Thickness (cm)")]
    public double RimThicknesscm { get; set; }

    [JsonPropertyName("Rim Depth / Diameter Ratio (%)")]
    public double RimDepthDiameterRatio { get; set; }

    [JsonPropertyName("Rim Configuration")]
    public double RimConfiguration { get; set; }

    [JsonPropertyName("Flexibility (kg)")]
    public double Flexibilitykg { get; set; }
    public string Class { get; set; } = string.Empty;

    [JsonPropertyName("Max Weight Vint (gr)")]
    public double MaxWeightVintgr { get; set; }

    [JsonPropertyName("Last Year Production")]
    public string LastYearProduction { get; set; } = string.Empty;

    [JsonPropertyName("Certification Number")]
    public string CertificationNumber { get; set; } = string.Empty;

    [JsonPropertyName("Approved Date")]
    public string ApprovedDate { get; set; } = string.Empty;
}
