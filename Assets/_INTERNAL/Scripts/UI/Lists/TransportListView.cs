using Core.Controllers;
using Core.Instances;
using System;
using System.Collections.Generic;
using UI.Base;
using UI.Views;
using UnityEngine;

public class TransportListView : UIListBase
{
    [SerializeField] private TransportView _transportViewPrefab;
    [SerializeField] private Transform _content;

    private List<TransportView> _transportViews = new();
    private List<TransportController> _transportControllers = new();

    public event Action<TransportInstance> OnTransportSelected;

    private void OnDestroy()
    {
        foreach (var item in _transportControllers)
        {
            item.OnTransportSelected -= HandleSelectedTransport;
        }
    }

    public void Init(List<TransportInstance> transportInstances)
    {
        for (int i = 0; i < transportInstances.Count; i++)
        {
            TransportView newTransport = Instantiate(_transportViewPrefab, _content);
            _transportViews.Add(newTransport);

            TransportController newController = new(transportInstances[i], newTransport, i);
            newController.Init();
            _transportControllers.Add(newController);
        }
        foreach (var item in _transportControllers)
        {
            item.OnTransportSelected += HandleSelectedTransport;
        }
    }

    private void HandleSelectedTransport(TransportInstance obj)
    {
        OnTransportSelected?.Invoke(obj);
    }
}