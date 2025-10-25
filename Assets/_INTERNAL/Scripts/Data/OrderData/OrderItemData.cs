using System;
using UnityEngine;

namespace Data.OrderData
{
    [Serializable]
    public class OrderItemData
    {
        [Tooltip("������")] public Sprite Icon;
        [Tooltip("������������")] public string Name;
        [Tooltip("������� ��������� �������� ������� ������")] public float PriceForDelivery;
    }
}