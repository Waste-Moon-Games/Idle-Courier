using Core.Stages;
using Core.StateMachine.ConcretStages;
using System;

namespace Core.StageFactory
{
    public class Factory : IStageFactory
    {
        private Example _example;
        
        public event Action OnStageCreated;

        public Factory(Example example)
        {
            _example = example;
        }

        public IStage CreateDistrictSelectionStage(IStageController controller)
        {
            return new DistrictStageSelection(controller, _example);
        }

        public IStage CreateExecutionStage(IStageController controller)
        {
            return new ExecutionStageSelection(controller, _example);
        }

        public IStage CreateOrderSelectionStage(IStageController controller)
        {
            return new OrderStageSelection(controller, _example);
        }

        public IStage CreateResultStage(IStageController controller)
        {
            return new ResultStage(controller, _example);
        }

        public IStage CreateTransportSelectionStage(IStageController controller)
        {
            return new TransportStageSelection(controller, _example);
        }
    }
}
