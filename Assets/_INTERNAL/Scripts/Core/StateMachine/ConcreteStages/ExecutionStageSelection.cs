using Core.StageFactory;
using Core.Stages;
using Entry.EntryData;
using System;
using UnityEngine;

namespace Core.StateMachine.ConcretStages
{
    public class ExecutionStageSelection : IStage
    {
        private IStageController _controller;
        private IStageFactory _stageFactory;

        public event Action OnStageCompleted;

        public ExecutionStageSelection(IStageController controller, StageDependencies deps)
        {
            _controller = controller;
            _stageFactory = _controller.StageFactory;
        }

        public void Enter()
        {
            Debug.Log($"Enter {GetType().Name}");
        }

        public void Exit()
        {
            Debug.Log($"Exit {GetType().Name}");
        }

        public void Tick()
        {
        }

        public void Dispose()
        {

        }

        private void HandleButtonClick()
        {
            OnStageCompleted?.Invoke();
        }
    }
}