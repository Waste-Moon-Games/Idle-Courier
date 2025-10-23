using Data.CategoriesData;
using Data.OrderData;
using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemsCategoryConfig", menuName = "Configs/ItemsCategoryConfig")]
public class ItemsCategoryConfig : ScriptableObject
{
    [Tooltip("��������� �������")]
    [field: SerializeField] public Category Category {  get; private set; }

    [Tooltip("������ �������, ����������� � ��������� ���������")]
    [field:SerializeField] public List<OrderItemData> OrderItem { get; private set; } = new List<OrderItemData>();
}
