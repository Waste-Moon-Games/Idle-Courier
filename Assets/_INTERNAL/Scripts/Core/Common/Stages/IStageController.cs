using Core.StageFactory;

namespace Core.Stages
{
    public interface IStageController
    {
        void SetStage(IStage newStage);
        void Tick();
        void StartCycle();
        void EndCycle();
        void ForceEnd();
        IStageFactory StageFactory { get; }
    }
}
