using Data.TransportData;
using SO;

namespace Core.Instances
{
    public class TransportInstance
    {
        private readonly TransportRuntimeData _runtimeData;

        public TransportRuntimeData TData => _runtimeData;

        public TransportInstance(TransportConfig config)
        {
            _runtimeData = new(config.TransportData);
        }
    }
}