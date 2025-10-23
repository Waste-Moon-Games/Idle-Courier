using Data.OrderData;
using System.Collections.Generic;
using UnityEngine;
namespace Core.Controllers
{
    public class OrdersController
    {
        private readonly List<OrderItemData> _orderItemData = new();
    
        public OrdersController(List<OrderItemData> orderItemDatas)
        {
            _orderItemData.AddRange(orderItemDatas);
        }
    }
}