using System.Collections.Generic;
using System.Linq;
using if3250_2022_19_filantropi_backend.Models;

namespace if3250_2022_19_filantropi_backend.Helpers
{
  public static class ExtensionMethods
  {
    public static IEnumerable<User> WithoutPasswords(this IEnumerable<User> users)
    {
      if (users == null) return null;

      return users.Select(x => x.WithoutPassword());
    }

    public static User WithoutPassword(this User user)
    {
      if (user == null) return null;

      user.Password = null;
      return user;
    }
  }
}