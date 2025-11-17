using Core.Context;
using Core.GameWorldStates;
using Core.Instances;
using Core.Stages;
using Entry.EntryData;
using System;
using UI.Lists;

namespace Core.StateMachine.ConcretStages
{
    public class DistrictStageSelection : IStage
    {
        private IStageController _controller;
        private DistrictListView _districtListView;
        private DeliveryContext _contex;
        private PlayerState _playerState;

        public event Action OnStageCompleted;

        public DistrictStageSelection(IStageController controller, StageDependencies stageDependencies)
        {
            _controller = controller;
            _districtListView = stageDependencies.DistrictListView;
            _contex = stageDependencies.DeliveryContex;
            _playerState = stageDependencies.PlayerState;
        }

        public void Enter()
        {
            if (!_districtListView.gameObject.activeSelf)
                _districtListView.Show();
            _districtListView.Init(_playerState.AvaliableInstances.DistrictInstances);

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
            _districtListView = null;
            _contex = null;
        }

        private void HandleSelectedDistrict(DistrictInstance obj)
        {
            _contex.SetDistrict(obj);
            OnStageCompleted?.Invoke();
        }
    }
}