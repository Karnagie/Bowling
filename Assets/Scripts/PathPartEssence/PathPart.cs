using System;
using BreakableObjects.BallEssence;
using ChooserEssence;
using Extensions;
using UnityEngine;
using Zenject;

namespace PathPartEssence
{
    public class PathPart : MonoBehaviour
    {
        [SerializeField] private PathObstacle[] _spawnObjects;
        [SerializeField] private Transform _place;
        
        [Inject] private BallSpawner _ballSpawner;

        public BallSpawner Spawner => _ballSpawner;

        private void Awake()
        {
            InitRandom();
        }

        private void InitRandom()
        {
            PathObstacle g = Instantiate(_spawnObjects.Random(), _place);
            g.Init(this);
        }
    }
}