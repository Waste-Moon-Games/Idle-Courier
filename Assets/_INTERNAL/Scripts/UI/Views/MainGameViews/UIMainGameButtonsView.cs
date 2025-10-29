using R3;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Views.MainGameViews
{
    public enum MainGameSceneButtonActions
    {
        StartDeliveryPreparations, SecondSomeTo
    }

    public class UIMainGameButtonsView : MonoBehaviour
    {
        [SerializeField] private Button _openDeliveryPreparations;
        [SerializeField] private Button _secondSomeGoToButton;

        private readonly Subject<MainGameSceneButtonActions> _actions = new();

        public Observable<MainGameSceneButtonActions> MainGameActions => _actions.AsObservable();

        private void Start()
        {
            ButtonsSubscribe();
        }

        private void OnDestroy()
        {
            ButtonsUnsubscribe();   
        }

        private void ButtonsSubscribe()
        {
            if (_openDeliveryPreparations == null || _secondSomeGoToButton == null)
                return;

            _openDeliveryPreparations.onClick.AddListener(HandleDeliveryPreparations);
            _secondSomeGoToButton.onClick.AddListener(HandleSecondSomeToGoClick);
        }

        private void ButtonsUnsubscribe()
        {
            if (_openDeliveryPreparations == null || _secondSomeGoToButton == null)
                return;

            _openDeliveryPreparations.onClick.RemoveListener(HandleDeliveryPreparations);
            _secondSomeGoToButton.onClick.RemoveListener(HandleSecondSomeToGoClick);
        }

        private void HandleDeliveryPreparations()
        {
            _actions.OnNext(MainGameSceneButtonActions.StartDeliveryPreparations);
        }

        private void HandleSecondSomeToGoClick()
        {
            _actions.OnNext(MainGameSceneButtonActions.SecondSomeTo);
        }
    }
}