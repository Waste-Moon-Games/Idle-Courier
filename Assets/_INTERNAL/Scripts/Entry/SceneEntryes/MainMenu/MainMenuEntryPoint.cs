using Core.Instances.Main;
using Core.StageFactory;
using Core.StateMachine;
using Entry.EntryData;
using System;
using UnityEngine;
using Utils.DI;

public class MainMenuEntryPoint : MonoBehaviour
{
    [SerializeField] private Canvas _parent;

    [SerializeField] private ItemsCategoryConfigs _itemsCategoryConfigs;
    [SerializeField] private OrdersGeneratorConfig _ordersGeneratorConfig;

    public void Run(DIContainer rootContainer)
    {
        DIContainer sceneContainer = new(rootContainer);
        InstanceHolder holder = sceneContainer.Resolve<InstanceHolder>();

        LoadResources(out DistrictListView dListView, out TransportListView tListView, out OrderListView oListView);
        
        dListView.Init(holder.DistrictInstances);
        tListView.Init(holder.TransportInstances);

        StageDependencies sd = new(dListView, tListView, oListView);
        sd.InitConfigs(_ordersGeneratorConfig, _itemsCategoryConfigs);
        Factory fc = new(sd);

        StageController sc = new(fc);
        sc.StartCycle();
    }

    private void LoadResources(out DistrictListView districtListView, out TransportListView transportListView, out OrderListView orderListView)
    {
        DistrictListView dPrefab = Resources.Load<DistrictListView>("UI/Lists/DistrictList");
        TransportListView tPrefab = Resources.Load<TransportListView>("UI/Lists/TransportList");
        OrderListView oPrefab = Resources.Load<OrderListView>("UI/Lists/OrderList");

        districtListView = Instantiate(dPrefab, _parent.transform);
        transportListView = Instantiate(tPrefab, _parent.transform);
        orderListView = Instantiate(oPrefab, _parent.transform);
    }
}
