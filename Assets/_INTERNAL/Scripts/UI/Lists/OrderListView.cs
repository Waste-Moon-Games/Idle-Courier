using Core.Controllers;
using Core.Instances;
using System;
using System.Collections.Generic;
using UI.Base;
using UI.Views;
using UnityEngine;

public class OrderListView : UIListBase
{
    [SerializeField] private OrderItemView _orderItemView;
    [SerializeField] private Transform _content;

    private List<OrderItemView> _orderViews = new();
    private List<OrdersController> _orderControllers = new();

    public event Action<OrderGeneratedData> OnOrderSelected;

    private void OnDestroy()
    {
        foreach (var item in _orderControllers)
        {
            item.OnOrderSelected -= HandleSelectedOrder;
        }
    }

    public void Init(List<OrderGeneratedData> orderGeneratedData)
    {
        for (int i = 0; i < orderGeneratedData.Count; i++)
        {
            OrderItemView newOrder = Instantiate(_orderItemView, _content);
            _orderViews.Add(newOrder);

            OrdersController newController = new(orderGeneratedData[i], newOrder, i);
            newController.Init();
            _orderControllers.Add(newController);
        }
        foreach (var item in _orderControllers)
        {
            item.OnOrderSelected += HandleSelectedOrder;
        }
    }

    private void HandleSelectedOrder(OrderGeneratedData obj)
    {
        OnOrderSelected?.Invoke(obj);
    }
}
