
using Microsoft.EntityFrameworkCore;
using Exam.Models;

namespace Exam.DAL
{
    public class UserRepository : IUserRepository
    {
        private readonly UserDbContext _db;
        private readonly ILogger<UserRepository> _logger;

        public UserRepository(UserDbContext db, ILogger<UserRepository> logger)
        {
            _db = db;
            _logger = logger;
        }

        public async Task<IEnumerable<User>?> GetAllUsers()
        {
            try
            {
                return await _db.Users.ToListAsync();
            }
            catch (Exception e)
            {
                _logger.LogError("[UserRepository] Users.ToListAsync() failed when GetAllUsers(), error message: {e}", e.Message);
                return null;
            }
        }

        public async Task<User?> GetUserById(int id)
        {
            try
            {
                return await _db.Users.FindAsync(id);
            }
            catch (Exception e)
            {
                _logger.LogError("[UserRepository] Users.FindAsync() failed when GetUserById() for UserId {id}, error message: {e}", id, e.Message);
                return null;
            }
        }

        public async Task<bool> CreateUser(User user)
        {
            try
            {
                _db.Users.Add(user);
                await _db.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                _logger.LogError("[UserRepository] Failed to create user {@user}, error message: {e}", user, e.Message);
                return false;
            }
        }

        public async Task<bool> UpdateUser(User user)
        {
            try
            {
                _db.Users.Update(user);
                await _db.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                _logger.LogError("[UserRepository] Failed to update user {@user}, error message: {e}", user, e.Message);
                return false;
            }
        }

        public async Task<bool> DeleteUser(int id)
        {
            try
            {
                var user = await _db.Users.FindAsync(id);
                if (user == null)
                {
                    _logger.LogError("[UserRepository] User not found in DeleteUser() for UserId: {id}", id);
                    return false;
                }
                _db.Users.Remove(user);
                await _db.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                _logger.LogError("[UserRepository] DeleteUser failed for UserId {id}, error message: {e}", id, e.Message);
                return false;
            }
        }
    }
}