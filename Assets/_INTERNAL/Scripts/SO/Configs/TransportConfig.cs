using Data.TransportData;
using UnityEngine;

namespace SO
{
    [CreateAssetMenu(fileName = "TransportConfig", menuName = "Configs/TransportConfig")]
    public class TransportConfig : ScriptableObject
    {
        [field: SerializeField] public TransportData TransportData { get; private set; }
    }
}