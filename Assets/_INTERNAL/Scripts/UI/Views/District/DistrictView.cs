using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace UI.Views
{
    public class DistrictView : MonoBehaviour, IPointerUpHandler
    {
        [SerializeField] private Image _logoField;
        [SerializeField] private TextMeshProUGUI _nameField;
        [SerializeField] private TextMeshProUGUI _categoryField;
        [SerializeField] private TextMeshProUGUI _descriptionField;

        public event Action OnDistrictSelected;

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

        public void OnPointerUp(PointerEventData eventData)
        {
            OnDistrictSelected?.Invoke();
        }
    }
}