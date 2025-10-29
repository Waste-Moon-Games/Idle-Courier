using UnityEngine;

namespace UI.Roots.MainGameRootView
{
    public class UIMainGameRootView : MonoBehaviour
    {
        [SerializeField] private Transform _sceneContentContainer;

        public void AttachUI(GameObject uiObject)
        {
            uiObject.transform.SetParent(_sceneContentContainer, false);
            Debug.Log($"View attached: {uiObject.GetType().Name}");
        }
    }
}