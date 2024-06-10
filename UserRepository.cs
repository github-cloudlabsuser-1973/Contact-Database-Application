using CRUD_application_2.Models;
using System.Collections.Generic;
using System.Linq;

public class UserRepository : IUserRepository
{
    private List<User> userlist = new List<User>();

    public List<User> GetUsers()
    {
        return userlist;
    }

    public User GetUser(int id)
    {
        return userlist.FirstOrDefault(u => u.Id == id);
    }

    public void AddUser(User user)
    {
        userlist.Add(user);
    }

    public void UpdateUser(User user)
    {
        var existingUser = GetUser(user.Id);
        if (existingUser != null)
        {
            existingUser.Name = user.Name;
            existingUser.Email = user.Email;
            // Update other properties here
        }
    }

    public void DeleteUser(int id)
    {
        var user = GetUser(id);
        if (user != null)
        {
            userlist.Remove(user);
        }
    }
}
