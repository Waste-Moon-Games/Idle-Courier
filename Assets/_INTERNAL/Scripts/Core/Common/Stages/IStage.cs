namespace Core
{
    public interface IStage
    {
        void Enter();
        void Tick();
        void Exit();
    }
}