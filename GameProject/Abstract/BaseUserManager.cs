using GameProject.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameProject.Abstract
{
    public abstract class BaseUserManager : IUserService
    {
        public virtual bool CheckUser(string FirstName, string LastName, string NationalityId, string YearOfBirth)
        {
            throw new NotImplementedException();
        }

        public virtual List<User> Delete(List<User> users, int UserIndex)
        {
            throw new NotImplementedException();
        }

        public virtual List<User> AddOrder(List<User> users, string UserId, string OrderId, Game game)
        {
            throw new NotImplementedException();
        }

        public virtual void PrintUser(List<User> users)
        {
            throw new NotImplementedException();
        }

        public virtual int GetUser(List<User> users, string UserId)
        {
            throw new NotImplementedException();
        }
    }
}
