using UI.Views.GameplayView;
using UnityEngine;
using Utils.Pool;

namespace Core.Generator
{
    public class LevelGenerator
    {
        private readonly RoadwayView _roadViewPrefab;
        private readonly Transform _roadViewPoolContainer;
        private readonly int _roadwayViewInitCount;

        private readonly ObjectPool<RoadwayView> _roadViewPool;

        public LevelGenerator(Transform roadViewPoolContainer, int roadwayViewInitCount, RoadwayView roadViewPrefab)
        {
            _roadViewPoolContainer = roadViewPoolContainer;
            _roadwayViewInitCount = roadwayViewInitCount;
            _roadViewPrefab = roadViewPrefab;

            _roadViewPool = new(_roadViewPrefab, _roadwayViewInitCount, _roadViewPoolContainer)
            {
                AutoExpand = true,
            };
        }
    }
}