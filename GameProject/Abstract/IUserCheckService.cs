using GameProject.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameProject.Abstract
{
    public interface IUserCheckService
    {
        bool CheckIfRealPerson(string FirstName, string LastName, string NationalityId, string YearOfBirth);
    }
}
