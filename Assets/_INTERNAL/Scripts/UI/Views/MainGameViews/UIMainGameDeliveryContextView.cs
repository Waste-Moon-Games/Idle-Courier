using Core.Context;
using R3;
using TMPro;
using UI.Base;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Views.MainGameViews
{
    public class UIMainGameDeliveryContextView : UISimpleItem
    {
        [SerializeField] private Button _startDeliveryButton;

        [field: SerializeField] public Button SelectDistrict {  get; private set; }
        [field: SerializeField] public Button SelectTransport { get; private set; }
        [field: SerializeField] public Button SelectOrder { get; private set; }

        private readonly Subject<Unit> _startDeliverySignal = new();

        public Observable<Unit> StartDeliverySignal => _startDeliverySignal.AsObservable();

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

        public void AttachView(GameObject view)
        {
            view.transform.SetParent(transform, false);
        }

        private void HandleStartDeliveryButtonClick()
        {
            _startDeliverySignal.OnNext(Unit.Default);
        }
    }
}