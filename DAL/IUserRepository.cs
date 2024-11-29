
using Exam.Models;

namespace Exam.DAL
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>?> GetAllUsers();
        Task<User?> GetUserById(int id);
        Task<bool> CreateUser(User user);
        Task<bool> UpdateUser(User user);
        Task<bool> DeleteUser(int id);
    }
}