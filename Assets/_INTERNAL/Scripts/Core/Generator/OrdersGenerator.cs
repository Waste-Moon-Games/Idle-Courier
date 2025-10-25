using Data.CategoriesData;
using Data.OrderData;
using System.Collections.Generic;
using UnityEngine;

namespace Core.Generator
{
    public class OrdersGenerator
    {
        private readonly OrdersGeneratorConfig _config;
        private readonly int _pricePerDistance;

        private readonly List<ItemsCategoryConfig> _categoryConfigs = new();

        public OrdersGenerator(OrdersGeneratorConfig config, ItemsCategoryConfigs categoryConfigs, int pricePerDistance)
        {
            _config = config;

            _pricePerDistance = pricePerDistance;
            _categoryConfigs.AddRange(categoryConfigs.ItemsCategoryConfig);
        }

        private float GenerateDistance()
        {
            return Random.Range(_config.MinDistance,_config.MaxDistance);
        }

        private float GenerateUrgencyMultipler()
        {
            return Random.Range(_config.MinUrgencyMultiplier, _config.MaxUrgencyMultiplier);
        }

        private int GenerateItemCount()
        {
            return Random.Range(_config.MinItemCount, _config.MaxItemCount);
        }

        private int GenerateRandomCategoryID()
        {
            int randomCategory = Random.Range(0, _categoryConfigs.Count);
            return randomCategory;
        }

        private int GenerateRandomItemID(int categoryID)
        {
            int randomItemID = Random.Range(0, _categoryConfigs[categoryID].OrderItem.Count);
            return randomItemID;
        }

        private float CalculateFinalPrice(int categoryID, int itemID, float multiplier, int count, float distance)
        {
            float basePrice = _categoryConfigs[categoryID].OrderItem[itemID].PriceForDelivery;
            float result = (basePrice * count + _pricePerDistance * distance) * multiplier;

            return result;
        }

        public OrderGeneratedData GenerateItem()
        {
            int randomCategoryID = GenerateRandomCategoryID();
            int randomItemID = GenerateRandomItemID(randomCategoryID);

            OrderItemData newItem = new()
            {
                Icon = _categoryConfigs[randomCategoryID].OrderItem[randomItemID].Icon,
                Name = _categoryConfigs[randomCategoryID].OrderItem[randomItemID].Name,
                PriceForDelivery = _categoryConfigs[randomCategoryID].OrderItem[randomItemID].PriceForDelivery,
            };
            OrderGeneratedData generatedItem = new()
            {
                ItemData = newItem,
                Distance = GenerateDistance(),
                UrgencyMultipler = GenerateUrgencyMultipler(),
                Count = GenerateItemCount()
            };
            generatedItem.Price = CalculateFinalPrice
                (randomCategoryID, randomItemID, generatedItem.UrgencyMultipler, generatedItem.Count, generatedItem.Distance);
            Debug.Log($"{generatedItem.ItemData.Name} price: {generatedItem.Price} ppud: {_pricePerDistance}");
            return generatedItem;
        }
        
        public List<OrderGeneratedData> GenerateItemList(int count)
        {
            List<OrderGeneratedData> items = new();

            for(int i = 0; i < count; i++)
            {
                items.Add(GenerateItem());
            }

            return items;
        }
    }
}