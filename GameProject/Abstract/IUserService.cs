using GameProject.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameProject.Abstract
{
    public interface IUserService
    {
        bool CheckUser(string FirstName, string LastName, string NationalityId, string YearOfBirth);
        List<User> Delete(List<User> users, int UserIndex);
        void PrintUser(List<User> users);
        int GetUser(List<User> users, string UserId);
        List<User> AddOrder(List<User> users, string UserId, string OrderId, Game game);
    }
}
