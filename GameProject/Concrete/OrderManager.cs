using GameProject.Abstract;
using GameProject.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameProject.Concrete
{
    class OrderManager : BaseOrderManager
    {
        public override int GetOrder(List<Order> orders, string orderId)
        {
            int Index = -1;
            
            for (int i = 0; i < orders.Count; i++)
            {
                if (orders[i].Id == orderId)
                {
                    Index = i;
                }
            }
            return Index;
        }
    }
}
