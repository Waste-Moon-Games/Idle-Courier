using System.Collections;
using UnityEngine;

namespace UI.Base
{
    public abstract class UISimpleItem : MonoBehaviour
    {
        public virtual void Show() => gameObject.SetActive(true);
        public virtual void Hide() => gameObject.SetActive(false);
    }
}