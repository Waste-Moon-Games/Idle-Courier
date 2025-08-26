using System.Collections.Generic;
using UnityEngine;

namespace SO
{
    [CreateAssetMenu(fileName = "TransportConfigs", menuName = "Scriptable Objects/TransportConfigs")]
    public class TransportConfigs : ScriptableObject
    {
        [field: SerializeField] public List<TransportConfig> Configs { get; private set; }
    }
}