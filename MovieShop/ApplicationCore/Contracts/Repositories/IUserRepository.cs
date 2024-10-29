using ApplicationCore.entity;

namespace ApplicationCore.Contracts.Repositories;

public interface IUserRepository:IRepository<User>
{
    Task<User> GetUserById(int id);
    Task<User> AddUser(User user);
    // Add more user-related repository methods
}