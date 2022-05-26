using System;
using BreakableObjects.BallEssence;
using Extensions;
using PathPartEssence;
using PlayerEssence;
using UnityEngine;
using Zenject;

namespace ChooserEssence
{
    public class Chooser : PathObstacle
    {
        [SerializeField] private Operation[] _operations;
        [SerializeField] private ChooserPanel _panel1;
        [SerializeField] private ChooserPanel _panel2;
        
        private BallSpawner _ballSpawner;
        private Operation _operation;

        public override void Init(PathPart part)
        {
            _ballSpawner = part.Spawner;
        }

        private void Awake()
        {
            _operation = _operations.Random();
                
            InitPanel(_panel1, _operation.Value1);
            InitPanel(_panel2, _operation.Value2);
        }

        private void InitPanel(ChooserPanel panel, float value)
        {
            panel.Init(OperationToString(_operation.Type, value), value);
            panel.OnPlayerEntered += OnPlayerEntered;
        }

        private void OnPlayerEntered(float value)
        {
            int defaultCount = _ballSpawner.Count;
            switch (_operation.Type)
            {
                case OperationType.Add:
                    _ballSpawner.Spawn((int)value);
                    break;
                case OperationType.Multiply:
                    _ballSpawner.Spawn((int)(defaultCount * value - defaultCount));
                    break;
            }
            Destroy(gameObject);
        }

        private string OperationToString(OperationType type, float value)
        {
            switch (type)
            {
                case OperationType.Add:
                    return $"+{value}";
                case OperationType.Multiply:
                    return $"*{value}";
            }
            throw new Exception($"Operation not found!");
        }
    }
}