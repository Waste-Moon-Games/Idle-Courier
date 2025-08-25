using System.Collections.Generic;
using Info;
using UnityEngine;

[CreateAssetMenu(fileName = "TransportData", menuName = "Scriptable Objects/TransportData")]
public class TransportData : ScriptableObject
{
    public List<TransportInfo> transport = new List<TransportInfo>();

    public TransportInfo GetTransportByName(string name)
    {
        return transport.Find(t => t.Name == name);
    }

    public List<RuntimeTransportData> GetRuntimeTransportData()
    {
        List<RuntimeTransportData> runtimeTransportData = new List<RuntimeTransportData>();

        foreach (var item in transport)
        {
            runtimeTransportData.Add(new RuntimeTransportData(item));
        }
        return runtimeTransportData;
    }
}