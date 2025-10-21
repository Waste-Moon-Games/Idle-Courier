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

    public void Run(DIContainer rootContainer)
    {
        DIContainer sceneContainer = new(rootContainer);
        InstanceHolder holder = sceneContainer.Resolve<InstanceHolder>();

        LoadResources(out DistrictListView dListView, out TransportListView tListView);
        
        dListView.Init(holder.DistrictInstances);
        //dListView.Show();
        tListView.Init(holder.TransportInstances);

        StageDependencies sd = new(dListView, tListView);
        Factory fc = new(sd);

        StageController sc = new(fc);
        sc.StartCycle();
    }

    private void LoadResources(out DistrictListView districtListView, out TransportListView transportListView)
    {
        DistrictListView dPrefab = Resources.Load<DistrictListView>("UI/Lists/DistrictList");
        TransportListView tPrefab = Resources.Load<TransportListView>("UI/Lists/TransportList");

        districtListView = Instantiate(dPrefab, _parent.transform);
        transportListView = Instantiate(tPrefab, _parent.transform);
    }
}
