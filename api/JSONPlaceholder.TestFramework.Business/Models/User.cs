using System.Text.Json.Serialization;

namespace JSONPlaceholder.TestFramework.Business.Models;

public record User
(
    [property: JsonPropertyName("id")] int? Id,
    [property: JsonPropertyName("name")] string Name,
    [property: JsonPropertyName("username")] string Username,
    [property: JsonPropertyName("email")] string? Email,
    [property: JsonPropertyName("address")] Address? Address,
    [property: JsonPropertyName("phone")] string? Phone,
    [property: JsonPropertyName("website")] string? Website,
    [property: JsonPropertyName("company")] Company? Company
);
