using UnityEngine;
using Utils.Pool;

namespace Core.Generator
{
    public class LevelGenerator
    {
        //создать SO где будут храиться префабы необходимые для генерации уровня

        private Transform _transform;
        private MonoBehaviour _prefab;
        private int _poolSize;

        private ObjectPool<MonoBehaviour> _pool;

        public LevelGenerator()
        {
            _pool = new(_prefab, _poolSize, _transform) { AutoExpand = true};
        }
    }
}