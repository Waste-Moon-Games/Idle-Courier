using UI.Lists;
using UI.Roots.MainGameRootView;
using UI.Views.GameplayView;
using UI.Views.MainGameViews;
using UnityEngine;

namespace Entry.SceneEntryes.MainMenu
{
    public class ResourceLoader : MonoBehaviour
    {
        public void LoadMainViews(out UIMainGameButtonsView buttonsView, out UIMainGameHUDView hudView, out UIMainGameDeliveryContextView contextView)
        {
            UIMainGameButtonsView buttonsViewPrefab = Resources.Load<UIMainGameButtonsView>("UI/Views/MainGame/UIMainGameButtonsView");
            UIMainGameHUDView hudViewPrefab = Resources.Load<UIMainGameHUDView>("UI/Views/MainGame/UIMainGameHUDView");
            UIMainGameDeliveryContextView contextViewPrefab = Resources.Load<UIMainGameDeliveryContextView>("UI/Views/MainGame/UIMainGameDeliveryContextView");

            buttonsView = Instantiate(buttonsViewPrefab);
            hudView = Instantiate(hudViewPrefab);
            contextView = Instantiate(contextViewPrefab);
        }

        public void LoadGameplayView(out UIGameplayHUDView hudView, out UIGameplayPauseView pauseView)
        {
            UIGameplayHUDView hudViewPrefab = Resources.Load<UIGameplayHUDView>("UI/Views/Gameplay/UIGameplayHUDView");
            UIGameplayPauseView pauseViewPrefab = Resources.Load<UIGameplayPauseView>("UI/Views/Gameplay/UIGameplayPauseView");

            hudView = Instantiate(hudViewPrefab);
            pauseView = Instantiate(pauseViewPrefab);
        }

        public void LoadRoot(out UIRootView rootView)
        {
            UIRootView rootViewPrefab = Resources.Load<UIRootView>("UI/Roots/UIMainGameRootView");

            rootView = Instantiate(rootViewPrefab);
        }

        public void LoadResources(out DistrictListView districtListView, out TransportListView transportListView, out OrderListView orderListView)
        {
            DistrictListView dPrefab = Resources.Load<DistrictListView>("UI/Lists/DistrictList");
            TransportListView tPrefab = Resources.Load<TransportListView>("UI/Lists/TransportList");
            OrderListView oPrefab = Resources.Load<OrderListView>("UI/Lists/OrderList");

            districtListView = Instantiate(dPrefab);
            transportListView = Instantiate(tPrefab);
            orderListView = Instantiate(oPrefab);
        }

        public void LoadConfigs(out OrdersGeneratorConfig ordersGeneratorConfig, out ItemsCategoryConfigs itemsCategoryConfigs)
        {
            ordersGeneratorConfig = Resources.Load<OrdersGeneratorConfig>("Configs/OrderGenerator/GeneratorConfig/GeneratorConfig");
            itemsCategoryConfigs = Resources.Load<ItemsCategoryConfigs>("Configs/OrderGenerator/ItemsCategoryConfigs");
        }
    }
}