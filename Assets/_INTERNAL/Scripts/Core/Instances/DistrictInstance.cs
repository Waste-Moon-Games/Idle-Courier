using Data.DistrictData;

namespace Core.Instances
{
    public class DistrictInstance
    {
        private readonly DistrictRuntimeData _runtimeData;

        public DistrictRuntimeData DData => _runtimeData;

        public DistrictInstance(DistrictConfig config)
        {
            _runtimeData = new(config.DistrictData);
        }
    }
}