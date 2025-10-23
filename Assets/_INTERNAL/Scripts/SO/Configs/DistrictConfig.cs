using Data.DistrictData;
using UnityEngine;


[CreateAssetMenu(fileName = "DistrictConfig", menuName = "Configs/DistrictConfig")]
public class DistrictConfig : ScriptableObject
{
    [field: SerializeField]
    public DistrictData DistrictData
    {
        get;
        private set;
    }
}