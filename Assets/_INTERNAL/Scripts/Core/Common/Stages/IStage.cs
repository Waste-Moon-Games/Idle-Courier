using System;

namespace Core
{
    public interface IStage
    {
        event Action OnStageCompleted;
        void Enter();
        void Tick();
        void Exit();
        void Dispose();
    }
}