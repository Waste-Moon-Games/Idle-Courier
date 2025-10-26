using SO;
using System.Collections.Generic;
using UnityEngine;

namespace Core.Instances.Main
{
    public class AvaliableInstancesHolder
    {
        [field: SerializeField] public List<TransportInstance> TransportInstances = new();
        [field: SerializeField] public List<DistrictInstance> DistrictInstances = new();

        public AvaliableInstancesHolder(TransportConfigs transportConfigs, DistrictConfigs districtConfigs)
        {
            InitTransport(transportConfigs.Configs);
            InitDistrict(districtConfigs.Configs);
        }

        private void InitTransport(List<TransportConfig> transportConfigs)
        {
            TransportInstances.Clear();

            foreach (TransportConfig transport in transportConfigs)
            {
                TransportInstances.Add(new(transport));
            }
        }

        private void InitDistrict(List<DistrictConfig> districtConfigs)
        {
            DistrictInstances.Clear();

            foreach (DistrictConfig district in districtConfigs)
            {
                DistrictInstances.Add(new(district));
            }
        }
    }
}