using System.Collections.Generic;
using Data.CategoriesData;
using UnityEngine;

namespace Data.DistrictData
{
    [System.Serializable]
    public class DistrictData
    {
        [Tooltip("Логотип района")] public Sprite Logo;
        [Tooltip("Название района")] public string Name;
        [Tooltip("Описание")] public string Description;
        [Tooltip("Стоимость за единицу расстояния")] public int PricePerDistanceUnit;
        [Tooltip("Максимальное количество активных заказов")] public int MaxOrder;
        [Tooltip("Доступные категории заказов")] public List<Category> Category;
    }

    public class DistrictRuntimeData
    {
        public Sprite Logo;
        public string Name;
        public string Description;
        public int PricePerDistanceUnit;
        public int MaxOrder;
        public List<Category> Category;

        public DistrictRuntimeData(DistrictData sourseData)
        {
            Logo = sourseData.Logo;
            Name = sourseData.Name;
            Description = sourseData.Description;
            PricePerDistanceUnit = sourseData.PricePerDistanceUnit;
            MaxOrder = sourseData.MaxOrder;
            Category = sourseData.Category;
        }
    }
}