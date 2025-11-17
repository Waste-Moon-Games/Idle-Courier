using Core.Context;
using Core.GameWorldStates;
using UI.Lists;
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
        [field: SerializeField] public PlayerState PlayerState { get; private set; }


        public StageDependencies(DistrictListView districtListView, TransportListView transportListView, OrderListView orderListView, PlayerState playerState)
        {
            DistrictListView = districtListView;
            TransportListView = transportListView;
            OrderListView = orderListView;
            PlayerState = playerState;
        }

        public void InitConfigs(OrdersGeneratorConfig ordersGeneratorConfig, ItemsCategoryConfigs itemsCategoryConfigs)
        {
            OrdersGeneratorConfig = ordersGeneratorConfig;
            ItemsCategoryConfigs = itemsCategoryConfigs;
        }

        public void SetContext(DeliveryContext deliveryContext)
        {
            DeliveryContex = deliveryContext;
        }
    }
}