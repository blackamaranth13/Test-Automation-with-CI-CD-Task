namespace JSONPlaceholder.TestFramework.Business.Models;

public class UserBuilder
{
    public int? Id { get; set; }
    public required string Name { get; set; }
    public required string Username { get; set; }
    public string? Email { get; set; }
    public Address? Address { get; set; }
    public string? Phone { get; set; }
    public string? Website { get; set; }
    public Company? Company { get; set; }

    public User Build()
    {
        return new User(Id, Name, Username, Email, Address, Phone, Website, Company);
    }
}
