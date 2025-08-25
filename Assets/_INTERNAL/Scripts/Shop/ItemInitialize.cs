using System;
using Core;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemInitialize : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _name;
    [SerializeField] private TextMeshProUGUI _maxSpeed;
    [SerializeField] private TextMeshProUGUI _multiplier;
    [SerializeField] private Button _buyButton;

    public void SetDescription(RuntimeTransportData data)
    {
        _name.text = data.Name;
        _maxSpeed.text = Convert.ToString(data.MaxSpeed);
        _multiplier.text = Convert.ToString(data.Multiplier);

        _buyButton.onClick.AddListener(OnBuyButton);
    }

    private void OnBuyButton()
    {
        EventManager.OnSelectedTransport(_name.text);
    }
}