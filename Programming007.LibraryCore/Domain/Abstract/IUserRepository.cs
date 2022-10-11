using Programming007.LibraryCore.Domain.Entities;

namespace Programming007.LibraryCore.Domain.Abstract
{
    public interface IUserRepository
    {
        User Get(string username); 
    }
}
