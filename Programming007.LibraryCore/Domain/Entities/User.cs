namespace Programming007.LibraryCore.Domain.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }

        //WRONG, DON'T DO IT 
        //public string Password { get; set; }
    }
}
