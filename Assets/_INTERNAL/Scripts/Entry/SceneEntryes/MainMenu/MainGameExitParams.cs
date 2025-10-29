using Core.Context;
using Core.GameRoot;
using UnityEngine;

namespace Entry.SceneEntryes.MainMenu
{
    public class MainGameExitParams
    {
        public SceneEnterParams TargetSceneEnterParams { get; }

        [field: SerializeField] public DeliveryContext Context { get; private set; }

        public MainGameExitParams(SceneEnterParams targetSceneEnterParams)
        {
            TargetSceneEnterParams = targetSceneEnterParams;
        }

        public void SetContex(DeliveryContext context) => Context = context;
    }
}