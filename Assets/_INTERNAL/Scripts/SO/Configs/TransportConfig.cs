using Data.TransportData;
using UnityEngine;

namespace SO
{
    [CreateAssetMenu(fileName = "TransportConfig", menuName = "Scriptable Objects/TransportConfig")]
    public class TransportConfig : ScriptableObject
    {
        [field: SerializeField] public TransportData TransportData { get; private set; }
    }
}