using System;
using System.Collections.Generic;
using UnityEngine;

namespace UI.Views.GameplayView
{
    public class RoadwayView : MonoBehaviour
    {
        [field: SerializeField] public Transform[] BariersLine {  get; private set; }
        public List<BariersView> Bariers;

        public event Action<RoadwayView> PlayerOnCollision;

        private void OnCollisionEnter(Collision collision)
        {
            PlayerOnCollision?.Invoke(this);
        }
    }
}