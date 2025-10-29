using R3;
using UI.Views.MainGameViews;

namespace Core.Controllers.MainGame
{
    //todo разделить этот "бог"-контроллер на три маленьких: для HUD, для кнопок и для DeliveryContexView
    public class UIMainGameController
    {
        private readonly UIMainGameButtonsView _buttons;
        private readonly UIMainGameDeliveryContextView _context;
        private readonly UIMainGameHUDView _hud;

        private readonly CompositeDisposable _disposables = new();

        public UIMainGameController(UIMainGameButtonsView buttons, UIMainGameDeliveryContextView context, UIMainGameHUDView hud)
        {
            _buttons = buttons;
            _context = context;
            _hud = hud;

            _buttons.MainGameActions
                .Where(action => action == MainGameSceneButtonActions.StartDeliveryPreparations)
                .Subscribe(_ => context.Show())
                .AddTo(_disposables);
        }
    }
}