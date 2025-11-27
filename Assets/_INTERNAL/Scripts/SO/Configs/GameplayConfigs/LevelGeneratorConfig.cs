using System.Collections.Generic;
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
        [Header("Bariers")]
        [field: SerializeField] public List<BariersView> BariersViewPrefab {  get; private set; }
        [field: SerializeField] public Transform BariersPoolContainer { get; private set; }
    }
}