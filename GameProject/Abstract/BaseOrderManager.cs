using GameProject.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameProject.Abstract
{
    public abstract class BaseOrderManager : IOrderService
    {
        public virtual int GetOrder(List<Order> orders, string orderId)
        {
            throw new NotImplementedException();
        }
    }
}
