using Core.Instances;
using Core.StageFactory;
using Core.Stages;
using Entry.EntryData;
using UI.Lists;

namespace Core.StateMachine.ConcretStages
{
    public class TransportStageSelection : IStage
    {
        private IStageController _controller;
        private IStageFactory _stageFactory;
        private TransportListView _transportListView;

        public TransportStageSelection(IStageController controller, StageDependencies deps)
        {
            _controller = controller;
            _stageFactory = _controller.StageFactory;
            _transportListView = deps.TransportListView;
        }

        public void Enter()
        {
            if (!_transportListView.gameObject.activeSelf)
                _transportListView.Show();

            _transportListView.OnTransportSelected += HandleSelectedTransport;
        }

        public void Exit()
        {
            _transportListView.OnTransportSelected -= HandleSelectedTransport;
            _transportListView.Hide();
            Dispose();
        }

        public void Tick()
        {
        }

        public void Dispose()
        {
            _controller = null;
            _stageFactory = null;
            _transportListView = null;
        }

        private void HandleSelectedTransport(TransportInstance selectedTransport)
        {
            _controller.SetStage(_stageFactory.CreateOrderSelectionStage(_controller));
        }
    }
}