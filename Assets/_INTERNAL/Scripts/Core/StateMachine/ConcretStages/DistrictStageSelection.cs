using Core.Instances;
using Core.StageFactory;
using Core.Stages;
using Entry.EntryData;
using UnityEngine;

namespace Core.StateMachine.ConcretStages
{
    public class DistrictStageSelection : IStage
    {
        private IStageController _controller;
        private IStageFactory _stageFactory;
        private DistrictListView _districtListView;

        public DistrictStageSelection(IStageController controller, StageDependencies stageDependencies)
        {
            _controller = controller;
            _stageFactory = _controller.StageFactory;
            _districtListView = stageDependencies.DistrictListView;
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
            _controller.SetStage(_stageFactory.CreateTransportSelectionStage(_controller));
        }
    }
}