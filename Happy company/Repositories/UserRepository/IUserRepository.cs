using Happy_company.Model.Domain;

namespace Happy_company.Repositories.UserRepository
{
    public interface IUserRepository
    {
        Task<List<User>> GetAllUsers(int pageNumber, int pageSize);
        Task<User> GetUserById(Guid id);
        Task<int> GetTotalUsers();
        Task<bool> UserExistsByEmail(string email, Guid? userId = null);
        Task<User> CreateUser(User user);
        Task UpdateUser(User user);
        Task DeleteUser(User user);
    }
}
