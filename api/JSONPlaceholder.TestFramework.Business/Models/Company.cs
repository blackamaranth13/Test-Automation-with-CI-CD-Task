using System.Text.Json.Serialization;

namespace JSONPlaceholder.TestFramework.Business.Models;

public record class Company
(
    [property: JsonPropertyName("name")] string Name,
    [property: JsonPropertyName("catchPhrase")] string CatchPhrase,
    [property: JsonPropertyName("bs")] string Bs
);