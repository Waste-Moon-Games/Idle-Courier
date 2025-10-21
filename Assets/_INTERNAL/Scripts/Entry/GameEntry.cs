using Core.Instances.Main;
using Data.DistrictData;
using Entry.GlobalServices.SceneLoader;
using SO;
using UnityEngine;
using Utils.DI;
using Utils.ModCoroutines;

namespace Entry
{
    public class GameEntry
    {
        private static GameEntry _instance;

        private readonly UILoadingScreen _loadingScreen;

        private readonly Coroutines _coroutines;
        private readonly DIContainer _rootContainer = new();
        private readonly SceneNavigatorService _sceneNavigatorService;

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        public static void AutoRunGame()
        {
            Application.targetFrameRate = 60;
            Screen.sleepTimeout = SleepTimeout.NeverSleep;

            _instance = new();
            _instance.Run();
        }

        private GameEntry()
        {
            UILoadingScreen uILoadingPrefab = Resources.Load<UILoadingScreen>("UI/UILoadingScreen");
            Coroutines coroutinesPrefab = Resources.Load<Coroutines>("Utils/[COROUTINES]");
            DistrictConfigs districtConfigs = Resources.Load<DistrictConfigs>("Configs/DistrictConfigs");
            TransportConfigs transportConfigs = Resources.Load<TransportConfigs>("Configs/TransportConfigs");

            _loadingScreen = Object.Instantiate(uILoadingPrefab);
            _coroutines = Object.Instantiate(coroutinesPrefab);

            RegisterGlobalServices(districtConfigs, transportConfigs);

            _sceneNavigatorService ??= new(_rootContainer.Resolve<SceneLoaderService>(), _rootContainer);
        }

        private void Run()
        {
            _sceneNavigatorService.StartFromMainMenu();
        }

        private void RegisterGlobalServices(DistrictConfigs districtConfigs, TransportConfigs transportConfigs)
        {
            _rootContainer.RegisterInstance(_loadingScreen);
            _rootContainer.RegisterInstance(_coroutines);

            _rootContainer.RegisterFactory(
                s => new SceneLoaderService(_rootContainer.Resolve<UILoadingScreen>(),
                _rootContainer.Resolve<Coroutines>())).AsSingle();

            _rootContainer.RegisterFactory(i => new InstanceHolder(transportConfigs, districtConfigs)).AsSingle();
        }
    }
}