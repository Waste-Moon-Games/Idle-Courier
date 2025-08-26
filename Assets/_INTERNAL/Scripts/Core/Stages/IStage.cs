namespace Core
{
    interface IStage
    {
        void Enter();
        void Tick();
        void Exit();
    }
}