using Core.Context;
using UnityEngine;

namespace Entry.EntryData
{
    public class StageDependencies
    {
        [field: SerializeField] public DistrictListView DistrictListView { get; private set; }
        [field: SerializeField] public TransportListView TransportListView { get; private set; }
        [field: SerializeField] public OrderListView OrderListView { get; private set; }
        [field: SerializeField] public OrdersGeneratorConfig OrdersGeneratorConfig { get; private set; }
        [field: SerializeField] public ItemsCategoryConfigs ItemsCategoryConfigs { get; private set; }
        [field: SerializeField] public DeliveryContext DeliveryContex { get; private set; }


        public StageDependencies(DistrictListView districtListView, TransportListView transportListView, OrderListView orderListView)
        {
            DistrictListView = districtListView;
            TransportListView = transportListView;
            OrderListView = orderListView;
            DeliveryContex = new();
        }

        public void InitConfigs(OrdersGeneratorConfig ordersGeneratorConfig, ItemsCategoryConfigs itemsCategoryConfigs)
        {
            OrdersGeneratorConfig = ordersGeneratorConfig;
            ItemsCategoryConfigs = itemsCategoryConfigs;
        }
    }
}