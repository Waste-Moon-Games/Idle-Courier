using UnityEngine;

namespace UI.Roots.MainGameRootView
{
    public class UIRootView : MonoBehaviour
    {
        [SerializeField] private Transform _sceneContentContainer;

        public void AttachUI(GameObject uiObject)
        {
            uiObject.transform.SetParent(_sceneContentContainer, false);
        }
    }
}