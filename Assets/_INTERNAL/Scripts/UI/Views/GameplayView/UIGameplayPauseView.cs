using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Views.GameplayView
{
    public class UIGameplayPauseView : MonoBehaviour
    {
        [SerializeField] private Button _exitButton;
        [SerializeField] private Button _playButton;

        [SerializeField] private TextMeshProUGUI _districtField;
        [SerializeField] private TextMeshProUGUI _orderField;
        [SerializeField] private TextMeshProUGUI _countField;
        [SerializeField] private TextMeshProUGUI _distanceField;

        public event Action ExitButtonClicked;
        public event Action PlayButtonClicked;

        private void Start()
        {
            _exitButton.onClick.AddListener(OnClickExitButton);
            _playButton.onClick.AddListener(OnClickPlayButton);
        }

        public void SetDistrictInfo(string district) => _districtField.text = district;
        public void SetOrderInfo(string order) => _orderField.text = order;
        public void SetCountInfo(int count) => _countField.text = $"{count}";
        public void SetDistanceInfo(int distance) => _distanceField.text = $"{distance}";


        private void OnClickExitButton() => ExitButtonClicked?.Invoke();
        private void OnClickPlayButton() => PlayButtonClicked?.Invoke();
    }
}