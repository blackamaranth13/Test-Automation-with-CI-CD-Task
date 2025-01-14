using JSONPlaceholder.TestFramework.Business.Models;

namespace JSONPlaceholder.TestFramework.Business.Validations;

public static class UserValidations
{
    public static bool IsHaveId(this User user)
    {
        return user.Id.HasValue;
    }
    public static bool IsNameNonEmpty(this User user)
    {
        return !string.IsNullOrEmpty(user.Name);
    }

    public static bool IsUserNameNonEmpty(this User user)
    {
        return !string.IsNullOrEmpty(user.Username);
    }

    public static bool IsHaveEmail(this User user)
    {
        return user.Email is not null;
    }

    public static bool IsHaveAddress(this User user)
    {
        return user.Address is not null;
    }

    public static bool IsHavePhone(this User user)
    {
        return user.Phone is not null;
    }

    public static bool IsHaveWebsite(this User user)
    {
        return user.Website is not null;
    }

    public static bool IsHaveCompany(this User user)
    {
        return user.Company is not null;
    }
}
