using Core.Instances;
using System;
using TMPro;
using UnityEngine;

namespace UI.Shop
{
    public class TransportItem : Item
    {
        [SerializeField] private TextMeshProUGUI _description;
        [SerializeField] private TextMeshProUGUI _speed;
        [SerializeField] private TextMeshProUGUI _multiplier;

        private TransportInstance _instance;

        public event Action<TransportInstance> OnTransportSelected;

        private void OnDestroy()
        {
            Button.onClick.RemoveListener(ClickHandler);
        }

        public void Setup(TransportInstance instance)
        {
            _instance = instance;
            TextSetup(instance);

            Button.onClick.AddListener(ClickHandler);
        }

        private void TextSetup(TransportInstance instance)
        {
            Name.text = $"{instance.TData.Name}";
            _speed.text = $"{instance.TData.MaxSpeed}";
        }

        private void ClickHandler()
        {
            OnTransportSelected?.Invoke(_instance);
            Debug.Log($"Transport {Name.text} clicked!");
        }
    }
}