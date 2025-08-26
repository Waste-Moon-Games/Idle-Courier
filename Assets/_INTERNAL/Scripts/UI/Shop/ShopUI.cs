using Core.Instances;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace UI.Shop
{
    public class ShopUI : MonoBehaviour
    {
        [SerializeField] private Item _itemPrefab;
        [SerializeField] private RectTransform _content;

        private List<TransportItem> _items = new();

        public event Action<TransportInstance> OnTSelected;

        public void ShopInitialize(List<TransportInstance> instances)
        {
            SpawnItems(instances);
        }

        private void SpawnItems(List<TransportInstance> transports)
        {
            _items.Clear();

            foreach (var transport in transports)
            {
                var itemGO = Instantiate(_itemPrefab, _content);
                var item = itemGO.GetComponent<TransportItem>();

                item.Setup(transport);

                _items.Add(item);
            }
        }
    }
}