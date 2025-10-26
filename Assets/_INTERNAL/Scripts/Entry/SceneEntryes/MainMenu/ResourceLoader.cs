using UI.Lists;
using UI.Roots.MainGameRootView;
using UI.Views.MainGameViews;
using UnityEngine;

namespace Entry.SceneEntryes.MainMenu
{
    public class ResourceLoader : MonoBehaviour
    {
        public void LoadMainViews(out UIMainGameButtonsView buttonsView, out UIMainGameHUDView hudView)
        {
            UIMainGameButtonsView buttonsViewPrefab = Resources.Load<UIMainGameButtonsView>("UI/Views/MainGame/UIMainGameButtonsView");
            UIMainGameHUDView hudViewPrefab = Resources.Load<UIMainGameHUDView>("UI/Views/MainGame/UIMainGameHUDView");

            buttonsView = Instantiate(buttonsViewPrefab);
            hudView = Instantiate(hudViewPrefab);
        }

        public void LoadRoot(out UIMainGameRootView rootView)
        {
            UIMainGameRootView rootViewPrefab = Resources.Load<UIMainGameRootView>("UI/Roots/UIMainGameRootView");

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
    }
}