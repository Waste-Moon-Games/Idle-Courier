using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Utils.Formatters;

namespace UI.Views
{
    public class OrderItemView : MonoBehaviour, IPointerUpHandler
    {
        [SerializeField] private Image _icon;
        [SerializeField] private TextMeshProUGUI _name;
        [SerializeField] private TextMeshProUGUI _price;
        [SerializeField] private TextMeshProUGUI _distance;
        [SerializeField] private TextMeshProUGUI _count;

        private readonly NumberFormatter _formatter = new();

        public event Action OnOrderSelected;
        
        public void SetIcon(Sprite icon)
        {
            _icon.sprite = icon;
            _icon.color = Color.black;
        }
        public void SetName(string name) => _name.text = name;
        public void SetPrice(float price) => _price.text = _formatter.FormatNumber(price);
        public void SetDistance(float distance) => _distance.text = $"{distance}";
        public void SetCount(float count) => _count.text = $"{count}";
        public void OnPointerUp(PointerEventData eventData) => OnOrderSelected?.Invoke();
    }
}