using System.Text.Json.Serialization;

namespace JSONPlaceholder.TestFramework.Business.Models;

public record class Address
(
    [property: JsonPropertyName("street")] string Street,
    [property: JsonPropertyName("suite")] string Suite,
    [property: JsonPropertyName("city")] string City,
    [property: JsonPropertyName("zipcode")] string Zipcode,
    [property: JsonPropertyName("geo")] Geo Geo
);
