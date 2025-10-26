using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Views.GameplayView
{
    public class UIGameplayHUDView : MonoBehaviour
    {
        [SerializeField] private Slider _progres;
        [SerializeField] private TextMeshProUGUI _reward;
        [SerializeField] Button _pauseButton;

        public event Action PauseButtonClicked;

        private void Start()
        {
            _pauseButton.onClick.AddListener(OnClickPauseButton);
        }

        public void SetPeogressValue(float value) => _progres.value = value;
        public void SetRewardVale(float reward) => _reward.text = $"{_reward}";

        private void OnClickPauseButton()
        {
            PauseButtonClicked?.Invoke();
        }
    }
}