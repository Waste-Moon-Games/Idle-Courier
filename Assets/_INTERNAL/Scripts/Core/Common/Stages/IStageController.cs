using Core.StageFactory;
using System;

namespace Core.Stages
{
    public interface IStageController
    {
        event Action OnStageCompleted;
        void SetStage(IStage newStage);
        void Tick();
        void StartCycle();
        void EndCycle();
        void ForceEnd();
        IStageFactory StageFactory { get; }
    }
}
