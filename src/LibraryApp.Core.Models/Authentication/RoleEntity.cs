namespace LibraryApp.Core.Models.Authentication
{
    public class RoleEntity : IDataEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public static class RoleIds
    {
        public const int Admin = 1;
        public const int Librarian = 2;
        public const int User = 3;
    }
}
