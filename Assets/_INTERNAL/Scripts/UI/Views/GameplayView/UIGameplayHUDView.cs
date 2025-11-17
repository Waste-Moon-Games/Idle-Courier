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
            _progres.value = 0f;

            _pauseButton.onClick.AddListener(OnClickPauseButton);
        }

        private void OnDestroy()
        {
            _pauseButton.onClick.RemoveListener(OnClickPauseButton);
        }

        public void SetPeogressValue(float value) => _progres.value = value;
        public void SetRewardVale(string reward) => _reward.text = $"{reward}";

        private void OnClickPauseButton()
        {
            PauseButtonClicked?.Invoke();
        }
    }
}