using Core.Context;
using Core.Instances;
using Core.StageFactory;
using Core.Stages;
using Entry.EntryData;
using UI.Lists;

namespace Core.StateMachine.ConcretStages
{
    public class DistrictStageSelection : IStage
    {
        private IStageController _controller;
        private IStageFactory _stageFactory;
        private DistrictListView _districtListView;
        private DeliveryContext _contex;

        public DistrictStageSelection(IStageController controller, StageDependencies stageDependencies)
        {
            _controller = controller;
            _stageFactory = _controller.StageFactory;
            _districtListView = stageDependencies.DistrictListView;
            _contex = stageDependencies.DeliveryContex;
        }

        public void Enter()
        {
            if (!_districtListView.gameObject.activeSelf)
                _districtListView.Show();

            _districtListView.OnDistrictSelected += HandleSelectedDistrict;
        }

        public void Exit()
        {
            _districtListView.OnDistrictSelected -= HandleSelectedDistrict;
            _districtListView.Hide();
            Dispose();
        }

        public void Tick()
        {
        }

        public void Dispose()
        {
            _controller = null;
            _stageFactory = null;
            _districtListView = null;
        }

        private void HandleSelectedDistrict(DistrictInstance obj)
        {
            _contex.SetDistrict(obj);
            _controller.SetStage(_stageFactory.CreateTransportSelectionStage(_controller));
        }
    }
}