using Core.Consts;
using Core.Context;
using Core.GameRoot;

namespace Entry.SceneEntryes.Gameplay
{
    public class GameplayEnterParams : SceneEnterParams
    {
        private DeliveryContext _contex;

        public GameplayEnterParams() : base(SceneNames.GAMEPLAY_SCENE) { }

        public void SetContex(DeliveryContext context) => _contex = context;
    }
}