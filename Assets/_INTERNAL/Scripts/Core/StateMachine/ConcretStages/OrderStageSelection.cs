using Core.StageFactory;
using Core.Stages;
using Entry.EntryData;
using System;
using UnityEngine;

namespace Core.StateMachine.ConcretStages
{
    public class OrderStageSelection : IStage
    {
        private IStageController _controller;
        private IStageFactory _stageFactory;

        public OrderStageSelection(IStageController controller, StageDependencies deps)
        {
            _controller = controller;
            _stageFactory = _controller.StageFactory;
        }

        public void Enter()
        {
        }

        public void Exit()
        {
            Dispose();
        }

        public void Tick()
        {
        }

        public void Dispose()
        {
            _controller = null;
            _stageFactory = null;
        }

        private void HandleButtonClick()
        {
            _controller.SetStage(_stageFactory.CreateExecutionStage(_controller));
        }
    }
}