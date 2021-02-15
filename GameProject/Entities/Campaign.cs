using GameProject.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameProject.Entities
{
    public class Campaign
    {
        public Campaign(string Id, string Name, decimal DiscountRate = 0)
        {
            this.Id = Id;
            this.Name = Name;
            this.DiscountRate = DiscountRate;
        }
        public Campaign() { }
        public string Id { get; set; }
        public string Name { get; set; }
        public decimal DiscountRate { get; set; }
    }
}
