using System;
using System.Collections.Generic;
using System.Text;

namespace GameProject.Entities
{
    public class Order
    {
        public Order(string Id, string NationalityId, string ShipCity, string ShipCountry, DateTime OrderDate)
        {
            this.Id = Id;
            this.NationalityId = NationalityId;
            this.ShipCity = ShipCity;
            this.ShipCountry = ShipCountry;
            this.OrderDate = OrderDate;
            Games = new List<Game>();
        }
        public string Id { get; set; }
        public string NationalityId { get; set; }
        public string ShipCity { get; set; }
        public string ShipCountry { get; set; }
        public DateTime OrderDate { get; set; }
        public List<Game> Games;
    }
}
