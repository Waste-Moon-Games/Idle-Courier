using UI.Views;
using UnityEngine;

namespace Entry.EntryData
{
    public class StageDependencies
    {
        [field: SerializeField] public DistrictListView DistrictListView { get; private set; }
        [field: SerializeField] public TransportListView TransportListView { get; private set; }


        public StageDependencies(DistrictListView districtListView, TransportListView transportListView)
        {
            DistrictListView = districtListView;
            TransportListView = transportListView;
        }
    }
}