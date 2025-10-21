using Core.Stages;
using Entry.EntryData;
using System;
using UnityEngine;

namespace Core.StateMachine.ConcretStages
{
    public class ResultStage : IStage
    {
        private IStageController _controller;

        public ResultStage(IStageController controller, StageDependencies deps)
        {
            _controller = controller;
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
        }

        private void HandleButtonClick()
        {
            _controller.EndCycle();
        }
    }
}