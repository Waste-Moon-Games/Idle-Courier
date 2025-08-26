using SO;
using System.Collections.Generic;
using UnityEngine;

namespace Core.Instances.Main
{
    public class InstanceHolder
    {
        [field: SerializeField] public List<TransportInstance> TransportInstances = new();

        public void InitInstances(TransportConfigs config)
        {
            InitTransport(config.Configs);
        }

        private void InitTransport(List<TransportConfig> transportConfigs)
        {
            TransportInstances.Clear();

            foreach(TransportConfig transport in transportConfigs)
            {
                TransportInstances.Add(new(transport));
            }
        }
    }
}