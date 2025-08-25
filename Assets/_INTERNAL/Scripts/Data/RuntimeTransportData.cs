using Info;

public class RuntimeTransportData
{
    public string Name;
    public float MaxSpeed;
    public float Multiplier;

    public RuntimeTransportData(TransportInfo info)
    {
        Name = info.Name;
        MaxSpeed = info.MaxSpeed;
        Multiplier = info.Multiplier;
    }
}