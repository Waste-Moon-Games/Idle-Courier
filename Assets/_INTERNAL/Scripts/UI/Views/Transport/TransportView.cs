using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace UI.Views
{
    public class TransportView : MonoBehaviour, IPointerUpHandler
    {
        [SerializeField] private Image _logoField;
        [SerializeField] private TextMeshProUGUI _nameField;
        [SerializeField] private TextMeshProUGUI _categoryField;
        [SerializeField] private TextMeshProUGUI _descriptionField;
        [SerializeField] private TextMeshProUGUI _multiplierField;
        [SerializeField] private TextMeshProUGUI _speedField;
        [SerializeField] private TextMeshProUGUI _capacityField;

        public event Action OnTransportSelected;

        public void SetLogo(Sprite logo)
        {
            _logoField.sprite = logo;
        }

        public void SetName(string name)
        {
            _nameField.text = name;
        }

        public void SetCategory(string category)
        {
            _categoryField.text = category;
        }

        public void SetDescription(string description)
        {
            _descriptionField.text = description;
        }

        public void SetMultiplier(float multiplier)
        {
            _multiplierField.text = $"{multiplier}";
        }

        public void SetSpeed(float speed)
        {
            _speedField.text = $"{speed}";
        }

        public void SetCapacity(float capacity)
        {
            _capacityField.text = $"{capacity}";
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            OnTransportSelected?.Invoke();
        }
    }
}