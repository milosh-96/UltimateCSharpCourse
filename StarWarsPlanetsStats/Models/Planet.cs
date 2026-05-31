using StarWarsPlanetsStats.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace StarWarsPlanetsStats.Models;
public record Planet
{
    [JsonPropertyName("name")]
    public required string Name { get; init; }

    [JsonPropertyName("diameter")]
    public int? Diameter { get; init; }

    [JsonPropertyName("surface_water")]
    [DisplayName("Surface Water %")]
    public int? SurfaceWaterPercentage { get; init; }

    [JsonPropertyName("population")]
    public int? Population { get; init; }   

    public override string ToString() => $"{Name}, {Population}, {Diameter}, {SurfaceWaterPercentage}%";
}
