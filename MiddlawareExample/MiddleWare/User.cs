namespace MiddlawareExample.MiddleWare
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public User(int userId, string userName)
        {
            Id = userId;
            Name = userName;
        }
    }
}
