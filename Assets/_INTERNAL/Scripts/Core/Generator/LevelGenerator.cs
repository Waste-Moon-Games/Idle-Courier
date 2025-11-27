using System.Collections.Generic;
using System.Linq;
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

        private readonly List<BariersView> _bariersViewPrefab;
        private readonly Transform _bariersViewPoolContainer;

        private readonly float _roadwayLenght;

        private RoadwayView _currentRoadway;
        private RoadwayView _previousRoadway;

        private readonly ObjectPool<RoadwayView> _roadViewPool;
        private readonly ObjectPool<BariersView> _bariersPool;

        public LevelGenerator(Transform roadViewPoolContainer, int roadwayViewInitCount, RoadwayView roadViewPrefab, Transform bariersViewPoolContainer, List<BariersView> bariersViewPrefab)
        {
            _roadViewPoolContainer = roadViewPoolContainer;
            _roadwayViewInitCount = roadwayViewInitCount;
            _roadViewPrefab = roadViewPrefab;
            _bariersViewPrefab = bariersViewPrefab;
            _bariersViewPoolContainer = bariersViewPoolContainer;
            _roadwayLenght = roadViewPrefab.gameObject.transform.lossyScale.z * 10;

            _roadViewPool = new(_roadViewPrefab, _roadwayViewInitCount, _roadViewPoolContainer)
            {
                AutoExpand = true
            };

            _bariersPool = new(_bariersViewPrefab[0], 8, _bariersViewPoolContainer)
            {
                AutoExpand = true
            };

            Init();
        }

        private void Init()
        {
            InitRoadway();
            //InitBariers();
            
            foreach (var item in _roadViewPool)
            {
                item.PlayerOnCollision += RoadwayMoving;
            }
        }

        private void InitRoadway()
        {
            Vector3 tempTransform = new Vector3(0, 0, 0);

            foreach (var item in _roadViewPool)
            {
                item.gameObject.transform.position = tempTransform;
                item.gameObject.SetActive(true);
                tempTransform += new Vector3(0, 0, _roadwayLenght);

                item.Bariers = RandomizeBarier(item);
            }
        }

        public void Dispose()
        {
            foreach (var item in _roadViewPool)
            {
                item.PlayerOnCollision -= RoadwayMoving;
            }
        }

        private void RoadwayMoving(RoadwayView roadwayView)
        {
            if (_previousRoadway != null)
            {
                _roadViewPool.GetFreeElement();
                _bariersPool.GetFreeElements();
            }


            if (_currentRoadway != null)
            {
                _previousRoadway = _currentRoadway;

                _roadViewPool.ReturnToPool(_previousRoadway);
            
                _previousRoadway.transform.position = new Vector3(0,0, _previousRoadway.transform.position.z + _roadwayViewInitCount * _roadwayLenght);

                RandomizeBarier(_previousRoadway);
                foreach (BariersView barier in _previousRoadway.Bariers)
                {
                    _bariersPool.ReturnToPool(barier);
                }
            }

            _currentRoadway = roadwayView;
        }

        private void BariersMoving()
        {

        }

        private List<BariersView> RandomizeBarier(RoadwayView roadwayView)
        {
            List<BariersView> bariersViews = new();

            foreach (var item in _roadViewPool)
            {
                int randomLineCount = RandomizeLine();

                if(randomLineCount > 0)
                {
                    int lineIndex = RandomizeLine();

                    for (int i = 0; i < randomLineCount; i++)
                    {
                        BariersView barier = _bariersPool.GetFreeElement();
                        barier.transform.position = new Vector3(roadwayView.BariersLine[lineIndex].transform.position.x,
                            barier.transform.position.y,
                            roadwayView.BariersLine[lineIndex].transform.position.z + RandomizePosition());
                        
                        int randomLineIndex;

                        do
                        {    
                            randomLineIndex = RandomizeLine();
                        }
                        while (randomLineIndex == lineIndex);

                        lineIndex = randomLineIndex;
                        bariersViews.Add(barier);
                    }
                }
            }
            return bariersViews;
        }

        private float RandomizePosition()
        {
            return Random.Range(0f, _roadwayLenght);
        }

        private int RandomizeLine()
        {
            return Random.Range(0, _roadViewPrefab.BariersLine.Length);
        }
    }
}