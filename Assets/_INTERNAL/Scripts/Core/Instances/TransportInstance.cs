using Data.TransportData;
using SO;
using UnityEngine;

namespace Core.Instances
{
    public class TransportInstance
    {
        private readonly TransportRuntimeData _runtimeData;

        public TransportRuntimeData TData => _runtimeData;

        public TransportInstance(TransportConfig config)
        {
            _runtimeData = new(config.TransportData);
            Debug.Log($"{_runtimeData.Name} is initialized!");
        }
    }
}