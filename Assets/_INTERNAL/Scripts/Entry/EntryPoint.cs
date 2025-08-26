using UnityEngine;

namespace Entry
{
    public class EntryPoint : MonoBehaviour
    {
        [field: SerializeField] public DataInitialize InitData { get; private set; }

        private void Awake()
        {
            if (InitData != null)
                InitData.InitializeInstance();
            else
                throw new System.Exception("Data initializer is mising");

            //todo остальные инициализации других систем
        }
    }
}