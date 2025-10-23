using Core.Instances;
using System;
using UnityEngine;

namespace Core.Context
{
    public class DeliveryContext
    {
        [field: SerializeField] public DistrictInstance SelectedDistrict {  get; private set; }
        [field: SerializeField] public TransportInstance SelectedTransport { get; private set; }

        public event Action<DistrictInstance> OnSelectedDistrict;
        public event Action<TransportInstance> OnSelectedTransport;

        public DeliveryContext()
        {

        }

        public void SetDistrict(DistrictInstance district)
        {
            SelectedDistrict = district;

            OnSelectedDistrict?.Invoke(SelectedDistrict);
        }

        public void SetTransport(TransportInstance transport)
        {
            SelectedTransport = transport;

            OnSelectedTransport?.Invoke(SelectedTransport);
        }
    }
}