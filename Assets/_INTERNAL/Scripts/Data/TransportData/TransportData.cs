using UnityEngine;

namespace Data.TransportData
{
    [System.Serializable]
    public class TransportData
    {
        [Tooltip("Наименование транспорта")] public string Name;
        [Tooltip("Максимальная скорость в км/ч"), Range(1, 150)] public float MaxSpeed;
        [Tooltip("Коэффициент"), Range(1f, 100f)] public float Multiplier;
    }

    public class TransportRuntimeData
    {
        public string Name;
        public float MaxSpeed;
        public float Multiplier;

        public TransportRuntimeData(TransportData sourceData)
        {
            Name = sourceData.Name;
            MaxSpeed = sourceData.MaxSpeed;
            Multiplier = sourceData.Multiplier;
        }
    }
}