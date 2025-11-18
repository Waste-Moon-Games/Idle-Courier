using UI.Views.GameplayView;
using UnityEngine;

namespace SO.Configs
{
    [CreateAssetMenu(fileName = "LevelGeneratorConfig", menuName = "Configs/Gameplay/Level Generator Config")]
    public class LevelGeneratorConfig : ScriptableObject
    {
        [Header("Roadway settings")]
        [field: SerializeField] public RoadwayView RoadwayViewPrefab {  get; private set; }
        [field: SerializeField] public int RoadwayInitCount { get; private set; }
        [field: SerializeField] public Transform RoadwayPoolContainer { get; private set; }
    }
}