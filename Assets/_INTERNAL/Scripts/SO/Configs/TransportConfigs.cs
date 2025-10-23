using System.Collections.Generic;
using UnityEngine;

namespace SO
{
    [CreateAssetMenu(fileName = "TransportConfigs", menuName = "Configs/TransportConfigs")]
    public class TransportConfigs : ScriptableObject
    {
        [field: SerializeField] public List<TransportConfig> Configs { get; private set; }
    }
}