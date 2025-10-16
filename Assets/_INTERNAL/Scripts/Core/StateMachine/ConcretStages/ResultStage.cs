using Core.Stages;
using System;
using UnityEngine;

namespace Core.StateMachine.ConcretStages
{
    public class ResultStage : IStage
    {
        private IStageController _controller;
        private Example _example;

        public ResultStage(IStageController controller, Example example)
        {
            _controller = controller;
            _example = example;
        }

        public void Enter()
        {
            _example.OnButtonClicked += HandleButtonClick;
            Debug.Log($"Enter {GetType().Name}");
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
            _controller.EndCycle();
        }
    }
}