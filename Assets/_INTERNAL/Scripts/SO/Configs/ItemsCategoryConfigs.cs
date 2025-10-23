using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemsCategoryConfigs", menuName = "Configs/ItemsCategoryConfigs")]
public class ItemsCategoryConfigs : ScriptableObject
{
    [field:SerializeField] public List<ItemsCategoryConfig> ItemsCategoryConfig {  get; private set; }
}
