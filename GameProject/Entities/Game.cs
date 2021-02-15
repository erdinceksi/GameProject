using System;
using System.Collections.Generic;
using System.Text;

namespace GameProject.Entities
{
    public class Game
    {
        public Game(string Id, string Name, decimal Price)
        {
            this.Id = Id;
            this.Name = Name;
            this.Price = Price;
            Campaigns = new List<Campaign>(); 
        }
        public Game(){}

        public string Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public List<Campaign> Campaigns { get; set; }
    }
}
