using System.Collections.Generic;
using Data.CategoriesData;
using UnityEngine;

namespace Data.DistrictData
{
    [System.Serializable]
    public class DistrictData
    {
        [Tooltip("Название района")] public string Name;
        [Tooltip("Максимальное количество активных заказов")] public int MaxOrder;
        [Tooltip("Доступные категории заказов")] public List<Category> Category;
    }

    public class DistrictRuntimeData
    {
        public string Name;
        public int MaxOrder;
        public List<Category> Category;

        public DistrictRuntimeData(DistrictData sourseData)
        {
            Name = sourseData.Name;
            MaxOrder = sourseData.MaxOrder;
            Category = sourseData.Category;
        }
    }
}