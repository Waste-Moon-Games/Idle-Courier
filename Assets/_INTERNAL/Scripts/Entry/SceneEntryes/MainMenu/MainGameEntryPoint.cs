using Core.Instances.Main;
using Core.StageFactory;
using Core.StateMachine;
using Entry.EntryData;
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

        [SerializeField] private ItemsCategoryConfigs _itemsCategoryConfigs;
        [SerializeField] private OrdersGeneratorConfig _ordersGeneratorConfig;

        public Observable<MainGameSceneButtonActions> Run(DIContainer sceneContainer)
        {
            CreateMainGameScene(sceneContainer);

            _loader.LoadRoot(out UIMainGameRootView rootView);
            _loader.LoadViews(out UIMainGameButtonsView buttonsView, out UIMainGameHUDView hudView);

            rootView.AttachUI(buttonsView.gameObject);
            rootView.AttachUI(hudView.gameObject);

            return buttonsView.MainGameActions;
        }

        private void CreateMainGameScene(DIContainer sceneContainer)
        {
            //todo распределение всех зависимостей на сцене
        }
    }
}