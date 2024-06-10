using CRUD_application_2.Models;
using System.Collections.Generic;

public interface IUserRepository
{
    List<User> GetUsers();
    User GetUser(int id);
    void AddUser(User user);
    void UpdateUser(User user);
    void DeleteUser(int id);
}
