using Core.Context;
using System;
using UI.Views.GameplayView;
using UnityEngine;

namespace Core.Controllers.Gameplay
{
    public class UIGameplayPauseController
    {
        private readonly UIGameplayPauseView _gameplayPauseView;
        private readonly DeliveryContext _context;

        public UIGameplayPauseController(UIGameplayPauseView gameplayPauseView, DeliveryContext context)
        {
            _gameplayPauseView = gameplayPauseView;
            _context = context;
            Init();
        }

        public void Init()
        {
            _gameplayPauseView.SetDistrictInfo(_context.SelectedDistrict.DData.Name);
            _gameplayPauseView.SetOrderInfo(_context.SelectedOrder.ItemData.Name);
            _gameplayPauseView.SetCountInfo(_context.SelectedOrder.Count);
            _gameplayPauseView.SetDistanceInfo(_context.SelectedOrder.Distance);

            _gameplayPauseView.PlayButtonClicked += PlayButtonClick;
            _gameplayPauseView.ExitButtonClicked += ExitButtonClick;
        }

        public void Dispose()
        {
            _gameplayPauseView.PlayButtonClicked -= PlayButtonClick;
            _gameplayPauseView.ExitButtonClicked -= ExitButtonClick;
        }

        private void PlayButtonClick()
        {
            _gameplayPauseView.gameObject.SetActive(false);
            Time.timeScale = 1.0f;
        }

        private void ExitButtonClick()
        {
            Debug.Log("ExitButtonClick()");
        }
    }
}