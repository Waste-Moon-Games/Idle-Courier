using SO;
using UnityEngine;

namespace Core.GameWorldStates
{
    public class GameState
    {
        [field: SerializeField] public PlayerState PlayerState { get; private set; }

        public GameState(TransportConfigs transport, DistrictConfigs district)
        {
            PlayerState = new(transport, district);
        }
    }
}