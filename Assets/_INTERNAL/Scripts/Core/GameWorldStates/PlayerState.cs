using Core.Instances.Main;
using SO;
using UnityEngine;

namespace Core.GameWorldStates
{
    public class PlayerState
    {
        //todo хранит в себе всё о состоянии игрока: информацию о деньгах/рейтинге, доступные тс/районы
        [field: SerializeField] public AvaliableInstancesHolder AvaliableInstances { get; private set; }

        public PlayerState(TransportConfigs transport, DistrictConfigs district)
        {
            AvaliableInstances = new(transport, district);
        }
    }
}
