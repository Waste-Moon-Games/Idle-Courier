using Core.Context;
using Core.Controllers.MainGame;
using Entry.SceneEntryes.Gameplay;
using R3;
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

        private void OnDestroy()
        {
            _disposables.Dispose();
        }

        public Observable<MainGameExitParams> Run(DIContainer sceneContainer)
        {
            CreateMainGameScene(sceneContainer);

            _loader.LoadRoot(out UIMainGameRootView rootView);
            _loader.LoadMainViews(out UIMainGameButtonsView buttonsView, out UIMainGameHUDView hudView, out UIMainGameDeliveryContextView contextView);

            rootView.AttachUI(buttonsView.gameObject);
            rootView.AttachUI(hudView.gameObject);
            rootView.AttachUI(contextView.gameObject);

            var startDeliverySignal = new Subject<DeliveryContext>();
            GameplayEnterParams gameplayEnterParams = new();

            contextView.Bind(startDeliverySignal);
            UIMainGameController mainGameViewController = new(buttonsView, contextView, hudView);

            contextView.ContextIsReady.Subscribe(contex =>
            {
                gameplayEnterParams.SetContex(contex);
            }).AddTo(_disposables);

            MainGameExitParams mainGameExitParams = new(gameplayEnterParams);

            return startDeliverySignal.Select(_ => mainGameExitParams);
        }

        private void CreateMainGameScene(DIContainer sceneContainer)
        {
            //todo распределение всех зависимостей на сцене
        }
    }
}