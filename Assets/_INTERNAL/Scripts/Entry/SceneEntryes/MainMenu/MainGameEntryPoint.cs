using Core.Controllers.MainGame;
using Core.GameWorldStates;
using Core.StageFactory;
using Core.StateMachine;
using Entry.EntryData;
using Entry.SceneEntryes.Gameplay;
using R3;
using UI.Lists;
using UI.Roots.MainGameRootView;
using UI.Views.MainGameViews;
using UnityEngine;
using Utils.DI;

namespace Entry.SceneEntryes.MainMenu
{
    public class MainGameEntryPoint : MonoBehaviour
    {
        [SerializeField] private ResourceLoader _loader;

        private readonly CompositeDisposable _disposables = new();

        private UIMainGameController _uiGameController;

        private void OnDestroy()
        {
            _disposables.Dispose();
            _uiGameController.Dispose();
        }

        public Observable<MainGameExitParams> Run(DIContainer sceneContainer)
        {
            CreateMainGameScene(sceneContainer);

            _loader.LoadRoot(out UIRootView rootView);
            _loader.LoadMainViews(out UIMainGameButtonsView buttonsView, out UIMainGameHUDView hudView, out UIMainGameDeliveryContextView contextView);
            _loader.LoadResources(out DistrictListView districtListView, out TransportListView transportListView, out OrderListView orderListView);
            _loader.LoadConfigs(out OrdersGeneratorConfig ordersGeneratorConfig, out ItemsCategoryConfigs itemsCategoryConfigs);

            rootView.AttachUI(buttonsView.gameObject);
            rootView.AttachUI(hudView.gameObject);
            rootView.AttachUI(contextView.gameObject);

            contextView.AttachView(districtListView.gameObject);
            contextView.AttachView(transportListView.gameObject);
            contextView.AttachView(orderListView.gameObject);

            GameplayEnterParams gameplayEnterParams = new();

            var playerState = sceneContainer.Resolve<GameState>().PlayerState;
            StageDependencies stageDependencies = new(districtListView, transportListView, orderListView, playerState);

            stageDependencies.InitConfigs(ordersGeneratorConfig, itemsCategoryConfigs);
            buttonsView.DeliverySignal
                .Subscribe(contex =>
                {
                    stageDependencies.SetContext(contex);
                    gameplayEnterParams.SetContext(contex);
                }).AddTo(_disposables);

            _uiGameController = new(buttonsView, contextView, hudView, new(new Factory(stageDependencies)));

            MainGameExitParams mainGameExitParams = new(gameplayEnterParams);

            return contextView.StartDeliverySignal.Select(_ => mainGameExitParams);
        }

        private void CreateMainGameScene(DIContainer sceneContainer)
        {
            //todo распределение всех зависимостей на сцене
        }
    }
}