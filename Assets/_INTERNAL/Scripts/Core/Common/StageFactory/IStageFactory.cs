using Core.Stages;
using System;

namespace Core.StageFactory
{
    public interface IStageFactory
    {
        event Action OnStageCreated;
        IStage CreateDistrictSelectionStage(IStageController controller);
        IStage CreateTransportSelectionStage(IStageController controller);
        IStage CreateOrderSelectionStage(IStageController controller);
        IStage CreateExecutionStage(IStageController controller);
        IStage CreateResultStage(IStageController controller);
    }
}
