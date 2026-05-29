namespace Book_Shop.Models
{
    public class User
    {
        public int Id { get; set; }

        public string? Name { get; set; } = null;

        public string? Password { get; set; }

        public int RoleId { get; set; }
        public Role? Role { get; set; }

        public User(int id, string? name, string? password,int roleId) {
            Id = id;
            Name = name;
            Password = password;
            RoleId = roleId;
        }
}
}
