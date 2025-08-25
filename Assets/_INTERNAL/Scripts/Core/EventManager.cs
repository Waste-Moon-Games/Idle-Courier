using System;

namespace Core
{
    public class EventManager
    {
        public static event Action<String> SelectedTransport;

        public static void OnSelectedTransport(string Name)
        {
            SelectedTransport?.Invoke(Name);
        }
    }
}