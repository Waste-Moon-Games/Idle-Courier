using System.Collections.Generic;
using UnityEngine;

public class ShopInitialize : MonoBehaviour
{
    [SerializeField] private TransportData _transportData;
    [SerializeField] private GameObject _itemPrefab;
    [SerializeField] private Transform contentParent;

    private List<RuntimeTransportData> _runtimeTransport;

    void Start()
    {
        _runtimeTransport = _transportData.GetRuntimeTransportData();

        foreach (var transport in _runtimeTransport)
        {
            GameObject itemObject = Instantiate(_itemPrefab, contentParent);
            ItemInitialize itemInit = itemObject.GetComponent<ItemInitialize>();
            itemInit.SetDescription(transport);
        }
    }
}