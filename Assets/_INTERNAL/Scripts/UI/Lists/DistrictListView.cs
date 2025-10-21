using Core.Controllers;
using Core.Instances;
using System;
using System.Collections.Generic;
using UI.Base;
using UI.Views;
using UnityEngine;

public class DistrictListView : UIListBase
{
    [SerializeField] private DistrictView _districtViewPrefab;
    [SerializeField] private Transform _content;

    private List<DistrictView> _districtViews = new();
    private List<DistrictController> _districtControllers = new();

    public event Action<DistrictInstance> OnDistrictSelected;

    private void OnDestroy()
    {
        foreach (var item in _districtControllers)
        {
            item.OnDistrictSelected -= HandleSelectedDistrict;
        }
    }

    public void Init(List<DistrictInstance> districtInstances)
    {
        for (int i = 0; i < districtInstances.Count; i++)
        {
            DistrictView newDistrict = Instantiate(_districtViewPrefab, _content);
            _districtViews.Add(newDistrict);

            DistrictController newController = new(districtInstances[i], newDistrict, i);
            newController.Init();
            _districtControllers.Add(newController);
        }
        foreach(var item in _districtControllers)
        {
            item.OnDistrictSelected += HandleSelectedDistrict;
        }
    }

    private void HandleSelectedDistrict(DistrictInstance obj)
    {
        OnDistrictSelected?.Invoke(obj);
    }
}
