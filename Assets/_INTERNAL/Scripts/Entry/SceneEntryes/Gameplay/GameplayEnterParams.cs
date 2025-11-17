using Core.Consts;
using Core.Context;
using Core.GameRoot;
using UnityEngine;

namespace Entry.SceneEntryes.Gameplay
{
    public class GameplayEnterParams : SceneEnterParams
    {
        private DeliveryContext _contex;
        public DeliveryContext Contex { get { return _contex; } }

        public GameplayEnterParams() : base(SceneNames.GAMEPLAY_SCENE) { }

        public void SetContext(DeliveryContext context) => _contex = context;
    }
}