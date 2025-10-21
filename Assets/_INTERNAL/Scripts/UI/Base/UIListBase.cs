using UnityEngine;

namespace UI.Base
{
    public abstract class UIListBase : MonoBehaviour
    {
        public virtual void Show() => gameObject.SetActive(true);
        public virtual void Hide() => gameObject.SetActive(false);
    }
}