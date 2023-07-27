using LibraryApp.Core.Models.Authentication;

namespace LibraryApp.Core.SQL.Seeds
{
    internal static class RolesSeed
    {

        public static readonly List<RoleEntity> RoleSeed = new()
        {
            new RoleEntity { Id = RoleIds.Admin, Name = "Admin" },
            new RoleEntity { Id = RoleIds.Librarian, Name = "Librarian" },
            new RoleEntity { Id = RoleIds.User, Name = "User" }
        };
    }
}
