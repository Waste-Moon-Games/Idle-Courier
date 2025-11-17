using Core.Context;
using UI.Views.GameplayView;
using UnityEngine;
using Utils.Formatters;

namespace Core.Controllers.Gameplay
{
    public class UIGameplayHUDController
    {
        private readonly UIGameplayHUDView _gameplayHUDView;
        private readonly UIGameplayPauseView _gameplayPauseView;
        private readonly DeliveryContext _context;
    
        public UIGameplayHUDController(UIGameplayHUDView gameplayView, UIGameplayPauseView pauseView, DeliveryContext context)
        {
            _gameplayHUDView = gameplayView;
            _gameplayPauseView = pauseView;
            _context = context;

            Init();
        }

        public void Init()
        {
            NumberFormatter numberFormatter = new();

            _gameplayHUDView.PauseButtonClicked += OnPauseButtonClick;

            _gameplayHUDView.SetRewardVale(numberFormatter.FormatNumber(_context.SelectedOrder.Price));
            _gameplayHUDView.SetPeogressValue(0f);

            _gameplayPauseView.gameObject.SetActive(false);
        }

        public void Dispose()
        {
            _gameplayHUDView.PauseButtonClicked -= OnPauseButtonClick;
        }

        public void UpdateDynamicElement()
        {
            _gameplayHUDView.SetPeogressValue(0f);
        }

        private void OnPauseButtonClick()
        {
            _gameplayPauseView.gameObject.SetActive(true);
            Time.timeScale = 0;
        }
    }
}