namespace Diazzo.Domain;

[Table("Disc")]
public class Disc : EntityBase
{
    [JsonPropertyName("Manufacturer / Distributor")]
    public string ManufacturerDistributor { get; set; } = string.Empty;

    [JsonPropertyName("Disc Model")]
    public string DiscModel { get; set; } = string.Empty;

    [JsonIgnore]
    [JsonPropertyName("Max Weight (gr)")]
    public double? MaxWeightgr { get; set; }

    [JsonIgnore]
    [JsonPropertyName("Diameter (cm)")]
    public double Diametercm { get; set; }

    [JsonIgnore]
    [JsonPropertyName("Height (cm)")]
    public double Heightcm { get; set; }

    [JsonIgnore]
    [JsonPropertyName("Rim Depth (cm)")]
    public double RimDepthcm { get; set; }

    [JsonIgnore]
    [JsonPropertyName("Inside Rim Diameter (cm)")]
    public double InsideRimDiametercm { get; set; }

    [JsonIgnore]
    [JsonPropertyName("Rim Thickness (cm)")]
    public double RimThicknesscm { get; set; }

    [JsonIgnore]
    [JsonPropertyName("Rim Depth / Diameter Ratio (%)")]
    public double RimDepthDiameterRatio { get; set; }

    [JsonIgnore]
    [JsonPropertyName("Rim Configuration")]
    public double RimConfiguration { get; set; }

    [JsonIgnore]
    [JsonPropertyName("Flexibility (kg)")]
    public double Flexibilitykg { get; set; }

    [JsonIgnore]
    public string Class { get; set; } = string.Empty;

    [JsonIgnore]
    [JsonPropertyName("Max Weight Vint (gr)")]
    public string MaxWeightVintgr { get; set; }

    [JsonIgnore]
    [JsonPropertyName("Last Year Production")]
    public string LastYearProduction { get; set; } = string.Empty;

    [JsonPropertyName("Certification Number")]
    public string CertificationNumber { get; set; } = string.Empty;

    [JsonPropertyName("Approved Date")]
    public string ApprovedDate { get; set; } = string.Empty;
}
