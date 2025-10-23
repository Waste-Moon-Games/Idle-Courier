using Core.Stages;
using Core.StateMachine.ConcretStages;
using Entry.EntryData;
using System;

namespace Core.StageFactory
{
    public class Factory : IStageFactory
    {
        private readonly StageDependencies _deps;

        public event Action OnStageCreated;

        public Factory(StageDependencies stageDependencies)
        {
            _deps = stageDependencies;
        }

        public IStage CreateDistrictSelectionStage(IStageController controller)
        {
            return new DistrictStageSelection(controller, _deps);
        }

        public IStage CreateTransportSelectionStage(IStageController controller)
        {
            return new TransportStageSelection(controller, _deps);
        }

        public IStage CreateOrderSelectionStage(IStageController controller)
        {
            return new OrderStageSelection(controller, _deps);
        }

        public IStage CreateExecutionStage(IStageController controller)
        {
            return new ExecutionStageSelection(controller, _deps);
        }

        public IStage CreateResultStage(IStageController controller)
        {
            return new ResultStage(controller, _deps);
        }
    }
}