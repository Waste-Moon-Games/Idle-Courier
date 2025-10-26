using UI.Views.GameplayView;

namespace Core.Controllers.Gameplay
{
    public class UIGameplayPauseController
    {
        private readonly UIGameplayPauseView _gameplayPauseView;

        public UIGameplayPauseController(UIGameplayPauseView gameplayPauseView)
        {
            _gameplayPauseView = gameplayPauseView;
        }

        public void Init()
        {
            _gameplayPauseView.SetDistrictInfo("");
            _gameplayPauseView.SetOrderInfo("");
            _gameplayPauseView.SetCountInfo(0);
            _gameplayPauseView.SetDistanceInfo(0);
        }
    }
}