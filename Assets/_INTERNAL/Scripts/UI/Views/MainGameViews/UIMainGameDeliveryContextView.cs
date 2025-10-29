using Core.Context;
using R3;
using UI.Base;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Views.MainGameViews
{
    public class UIMainGameDeliveryContextView : UISimpleItem
    {
        [SerializeField] private Button _startDeliveryButton;

        private Subject<DeliveryContext> _startDeliverySingal;

        public Observable<DeliveryContext> ContextIsReady => _startDeliverySingal.AsObservable();

        private void Start()
        {
            if (gameObject.activeSelf)
                Hide();

            if(_startDeliveryButton == null)
                return;

            _startDeliveryButton.onClick.AddListener(HandleStartDeliveryButtonClick);
        }

        private void OnDestroy()
        {
            _startDeliveryButton.onClick.RemoveListener(HandleStartDeliveryButtonClick);
        }

        public void Bind(Subject<DeliveryContext> startDeliverySignal) => _startDeliverySingal = startDeliverySignal; 

        private void HandleStartDeliveryButtonClick()
        {
            _startDeliverySingal.OnNext(new());
        }
    }
}