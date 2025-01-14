using JSONPlaceholder.TestFramework.Business.Models;

namespace JSONPlaceholder.TestFramework.Business.Validations;

public static class UserListValidations
{
    public static bool IsAllIdUniq(this List<User> list)
    {
        var set = new HashSet<int?>();
        return list.All(user => set.Add(user.Id));
    }
}
