using UI.Shop;
using UnityEngine;

namespace Entry
{
    public class EntryPoint : MonoBehaviour
    {
        [field: SerializeField] public DataInitialize InitData { get; private set; }
        [SerializeField] private ShopUI _shop;

        private void Awake()
        {
            if (InitData != null)
                InitData.InitializeInstance();
            else
                throw new System.Exception("Data initializer is mising");

            //todo остальные инициализации других систем
            _shop.ShopInitialize(InitData.InstanceHolder.TransportInstances);
        }
    }
}