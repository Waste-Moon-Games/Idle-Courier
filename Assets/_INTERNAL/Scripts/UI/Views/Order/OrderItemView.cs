using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace UI.Views
{
    public class OrderItemView : MonoBehaviour, IPointerUpHandler
    {
        [SerializeField] private Image _icon;
        [SerializeField] private TextMeshProUGUI _name;
        [SerializeField] private TextMeshProUGUI _price;
        [SerializeField] private TextMeshProUGUI _distance;

        public event Action OnOrderSelected;

        public void SetIcon(Image icon) => _icon = icon;
        public void SetName(string name) => _name.text = name;
        public void SetPrice(string price) => _price.text = price;
        public void SetDistance(string distance) => _distance.text = distance;
        public void OnPointerUp(PointerEventData eventData) => OnOrderSelected?.Invoke();
    }
}