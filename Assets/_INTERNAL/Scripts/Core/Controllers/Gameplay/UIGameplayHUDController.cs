using UI.Views.GameplayView;

namespace Core.Controllers.Gameplay
{
    public class UIGameplayHUDController
    {
        private readonly UIGameplayHUDView _gameplayHUDView;
    
        public UIGameplayHUDController(UIGameplayHUDView gameplayView)
        {
            _gameplayHUDView = gameplayView;
        }

        public void Init()
        {
            _gameplayHUDView.SetRewardVale(1);
        }

        public void UpdateDynamicElement()
        {
            _gameplayHUDView.SetPeogressValue(0.5f);
        }
    }
}