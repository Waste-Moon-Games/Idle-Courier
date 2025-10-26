using R3;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Views.MainGameViews
{
    public enum MainGameSceneButtonActions
    {
        SomeTo, SecondSomeTo
    }

    public class UIMainGameButtonsView : MonoBehaviour
    {
        [SerializeField] private Button _someGoToButton;
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
            if (_someGoToButton == null || _secondSomeGoToButton == null)
                return;

            _someGoToButton.onClick.AddListener(HandleSomeGoToClick);
            _secondSomeGoToButton.onClick.AddListener(HandleSecondSomeToGoClick);
        }

        private void ButtonsUnsubscribe()
        {
            if (_someGoToButton == null || _secondSomeGoToButton == null)
                return;

            _someGoToButton.onClick.RemoveListener(HandleSomeGoToClick);
            _secondSomeGoToButton.onClick.RemoveListener(HandleSecondSomeToGoClick);
        }

        private void HandleSomeGoToClick()
        {
            _actions.OnNext(MainGameSceneButtonActions.SomeTo);
        }

        private void HandleSecondSomeToGoClick()
        {
            _actions.OnNext(MainGameSceneButtonActions.SecondSomeTo);
        }
    }
}