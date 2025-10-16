using Core.StageFactory;
using Core.Stages;

namespace Core.StateMachine
{
    public class StageController : IStageController
    {
        private readonly IStageFactory _stageFactory;
        private IStage _curentStage;

        public IStageFactory StageFactory => _stageFactory;

        public StageController(IStageFactory stageFactory)
        {
            _stageFactory = stageFactory ?? throw new System.ArgumentNullException(nameof(stageFactory));
        }

        public void StartCycle()
        {
            SetStage(_stageFactory.CreateDistrictSelectionStage(this));
        }

        public void SetStage(IStage newStage)
        {
            if (newStage == null)
                throw new System.ArgumentNullException(nameof(newStage));

            if (_curentStage == newStage) return;

            _curentStage?.Exit();
            _curentStage = newStage;
            _curentStage?.Enter();
        }

        public void Tick()
        {
            _curentStage?.Tick();
        }

        public void ForceEnd()
        {
            _curentStage?.Exit();
        }

        public void EndCycle()
        {
            _curentStage?.Exit();
            _curentStage = null;
        }
    }
}
