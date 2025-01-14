using System.Text.Json.Serialization;

namespace JSONPlaceholder.TestFramework.Business.Models;

public record class Geo
(
    [property: JsonPropertyName("lat")] string Lat,
    [property: JsonPropertyName("lng")] string Lng
);
