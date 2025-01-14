using JSONPlaceholder.TestFramework.Business.Models;

namespace JSONPlaceholder.TestFramework.Business.Validations;

public static class CompanyValidations
{
    public static bool IsHaveName(this Company company)
    {
        return !string.IsNullOrEmpty(company?.Name);
    }
}
