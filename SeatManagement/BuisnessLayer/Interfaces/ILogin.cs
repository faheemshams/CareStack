using DataAccessLayer.Entities;

namespace BuisnessLayer.Interfaces
{
    public interface ILogin
    {
        string? login(User userCredentials);
        void signUp(User userCredentials);
    }
}
