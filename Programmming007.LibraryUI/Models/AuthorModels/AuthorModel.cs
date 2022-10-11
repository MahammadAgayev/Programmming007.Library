namespace Programmming007.LibraryUI.Models.AuthorModels
{
    public class AuthorModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }

        public override string ToString()
        {
            return $"{Name} {Surname}";
        }
    }
}
