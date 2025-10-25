using Core.Instances;
using Data.OrderData;
using System;
using System.Collections.Generic;
using UI.Views;
using UnityEngine;
namespace Core.Controllers
{
    public class OrdersController
    {
        private readonly int _controllerID;

        private readonly OrderItemView _orderItemView;

        private readonly OrderGeneratedData _orderGeneratedData;

        public event Action<OrderGeneratedData> OnOrderSelected;

        public OrdersController(OrderGeneratedData orderGeneratedData, OrderItemView orderItemView, int controllerID)
        {
            _orderGeneratedData = orderGeneratedData;

            _orderItemView = orderItemView;
            _controllerID = controllerID;
        }

        public void Init()
        {
            _orderItemView.SetIcon(_orderGeneratedData.ItemData.Icon);
            _orderItemView.SetName(_orderGeneratedData.ItemData.Name);
            _orderItemView.SetPrice(_orderGeneratedData.Price);
            _orderItemView.SetDistance(_orderGeneratedData.Distance);
            _orderItemView.SetCount(_orderGeneratedData.Count);

            _orderItemView.OnOrderSelected += HandleSelectedOrder;
        }

        private void HandleSelectedOrder()
        {
            OnOrderSelected?.Invoke(_orderGeneratedData);
        }
    }
}