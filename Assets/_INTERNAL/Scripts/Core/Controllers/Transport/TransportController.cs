using Core.Instances;
using System;
using UI.Views;

namespace Core.Controllers
{
    public class TransportController
    {
        private readonly int _controllerID;

        private readonly TransportInstance _instance;
        private readonly TransportView _transportView;

        public event Action<TransportInstance> OnTransportSelected;

        public TransportController(TransportInstance instance, TransportView transportView, int controllerID)
        {
            _instance = instance;
            _transportView = transportView;
            _controllerID = controllerID;
        }

        public void Init()
        {
            _transportView.SetLogo(_instance.TData.Logo);
            _transportView.SetName(_instance.TData.Name);
            _transportView.SetCategory(_instance.TData.Category.ToString());
            _transportView.SetDescription(_instance.TData.Description);
            _transportView.SetMultiplier(_instance.TData.Multiplier);
            _transportView.SetSpeed(_instance.TData.MaxSpeed);
            _transportView.SetCapacity(_instance.TData.Capacity);

            _transportView.OnTransportSelected += HandleSelectedTransport;
        }

        private void HandleSelectedTransport()
        {
            OnTransportSelected?.Invoke(_instance);
        }
    }
}