using GameProject.Abstract;
using GameProject.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameProject.Concrete
{
    public class UserCheckManager : IUserCheckService
    {
        public bool CheckIfRealPerson(string FirstName, string LastName, string NationalityId, string YearOfBirth)
        {
            return true;
        }
    }
}
