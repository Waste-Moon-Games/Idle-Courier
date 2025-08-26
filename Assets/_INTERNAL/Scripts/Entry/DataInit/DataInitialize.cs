using Core.Instances.Main;
using SO;
using UnityEngine;

public class DataInitialize : MonoBehaviour
{
    [Header("Data configs")]
    [field: SerializeField] public TransportConfigs TransportConfigs { get; private set; }

    [Header("Instance holder")]
    [field: SerializeField] public InstanceHolder InstanceHolder {  get; private set; }

    public void InitializeInstance()
    {
        InstanceHolder = new();
        InstanceHolder.InitInstances(TransportConfigs);
    }
}