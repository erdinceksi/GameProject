using GameProject.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameProject.Entities
{
    public class User
    {
        public User(string FirstName, string LastName, string NationalityId, string YearOfBirth)
        {
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.NationalityId = NationalityId;
            this.YearOfBirth = YearOfBirth;
            Orders = new List<Order>();
        }
        public User() { }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NationalityId { get; set; }
        public string YearOfBirth { get; set; }
        public List<Order> Orders{ get; set; }        
    }
}
