using UnityEngine;

namespace Info
{
    [System.Serializable]
    public class TransportInfo
    {
        //[Tooltip("Идентификационный номер")] public int ID;
        [Tooltip("Наименование транспорта")] public string Name;
        [Tooltip("Максимальная скорость")] public float MaxSpeed;
        [Tooltip("Коэффициент")] public float Multiplier;
    }
}