using Core.StageFactory;
using Core.Stages;
using UnityEngine;

namespace Core.StateMachine.ConcretStages
{
    public class DistrictStageSelection : IStage
    {
        private IStageController _controller;
        private IStageFactory _stageFactory;
        private Example _example;

        public DistrictStageSelection(IStageController controller, Example example)
        {
            _controller = controller;
            _stageFactory = _controller.StageFactory;
            _example = example;
        }

        public void Enter()
        {
            Debug.Log($"Enter {GetType().Name}");
            _example.OnButtonClicked += HandleButtonClick;
        }

        public void Exit()
        {
            _example.OnButtonClicked -= HandleButtonClick;
            Debug.Log($"Exit {GetType().Name}");
        }

        public void Tick()
        {
        }

        private void HandleButtonClick()
        {
            _controller.SetStage(_stageFactory.CreateTransportSelectionStage(_controller));
        }
    }
}