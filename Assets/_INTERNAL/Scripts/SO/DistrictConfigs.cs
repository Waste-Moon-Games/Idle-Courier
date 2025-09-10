using System.Collections.Generic;
using Data.DistrictData;
using UnityEngine;

[CreateAssetMenu(fileName = "DistrictConfigs", menuName = "Scriptable Objects/DistrictConfigs")]
public class DistrictConfigs : ScriptableObject
{
    [field: SerializeField]
    public List<DistrictConfig> Configs
    {
        get;
        private set;
    }
}