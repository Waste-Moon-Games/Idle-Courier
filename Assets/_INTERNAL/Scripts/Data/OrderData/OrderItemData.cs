using System;
using UnityEngine;

namespace Data.OrderData
{
    [Serializable]
    public class OrderItemData
    {
        [Tooltip("Иконка")] public Sprite Icon;
        [Tooltip("Наименование")] public string Name;
        [Tooltip("Стоимость")] public float Price;
    }
}