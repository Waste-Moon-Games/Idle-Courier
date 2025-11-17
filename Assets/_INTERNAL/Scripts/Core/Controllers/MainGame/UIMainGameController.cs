using Core.StateMachine;
using R3;
using System;
using UI.Views.MainGameViews;

namespace Core.Controllers.MainGame
{
    //todo разделить этот "бог"-контроллер на три маленьких: для HUD, для кнопок и для DeliveryContexView
    public class UIMainGameController
    {
        private readonly UIMainGameButtonsView _buttonsView;
        private readonly UIMainGameDeliveryContextView _contextView;
        private readonly UIMainGameHUDView _hudView;

        private readonly CompositeDisposable _disposables = new();

        private readonly StageController _stageController;

        public UIMainGameController(UIMainGameButtonsView buttons, UIMainGameDeliveryContextView context, UIMainGameHUDView hud, StageController stageController)
        {
            _buttonsView = buttons;
            _contextView = context;
            _hudView = hud;
            _stageController = stageController;
            _stageController.OnStageCompleted += HandleCompletedStage;

            _buttonsView.MainGameActions
                .Where(action => action == MainGameSceneButtonActions.StartDeliveryPreparations)
                .Subscribe(_ => context.Show())
                .AddTo(_disposables);

            ButtonContextSubscribe();
            StartInitButtons();
        }

        public void Dispose()
        {
            _contextView.OnStartDeliveryButtonClick -= HandleStartDeliveryButtonClick;
            _stageController.OnStageCompleted -= HandleCompletedStage;

            _contextView.SelectDistrict.onClick.RemoveListener(HandleDistrictButtonClick);
            _contextView.SelectTransport.onClick.RemoveListener(HandleTransportButtonClick);
            _contextView.SelectOrder.onClick.RemoveListener(HandleOrderButtonClick);
        }

        private void ButtonContextSubscribe()
        {
            _contextView.SelectDistrict.onClick.AddListener(HandleDistrictButtonClick);
            _contextView.SelectTransport.onClick.AddListener(HandleTransportButtonClick);
            _contextView.SelectOrder.onClick.AddListener(HandleOrderButtonClick);

            _contextView.OnStartDeliveryButtonClick += HandleStartDeliveryButtonClick;
        }

        private void HandleStartDeliveryButtonClick()
        {
            if(!_contextView.SelectOrder.interactable)
                _contextView.NextScene();
        }

        private void StartInitButtons()
        {
            _contextView.SelectDistrict.gameObject.SetActive(true);
            _contextView.SelectTransport.gameObject.SetActive(false);
            _contextView.SelectOrder.gameObject.SetActive(false);
        }

        private void HandleDistrictButtonClick()
        {
            _contextView.SelectDistrict.interactable = false;
            _stageController.StartCycle();
        }

        private void HandleTransportButtonClick()
        {
            //
            _contextView.SelectTransport.interactable = false;
            _stageController.SetStage(_stageController.StageFactory.CreateTransportSelectionStage(_stageController));
        }

        private void HandleOrderButtonClick()
        {
            //
            _contextView.SelectOrder.interactable = false;
            _stageController.SetStage(_stageController.StageFactory.CreateOrderSelectionStage(_stageController));
        }

        private void HandleCompletedStage()
        {
            _stageController.EndCycle();

            if (!_contextView.SelectTransport.gameObject.activeSelf) {_contextView.SelectTransport.gameObject.SetActive(true);}
            else { _contextView.SelectOrder.gameObject.SetActive(true);}
        }
    }
}