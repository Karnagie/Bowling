using UnityEngine;

namespace ChooserEssence
{
    [CreateAssetMenu(fileName = "MathOperation", menuName = "Math Operation", order = 0)]
    public class Operation : ScriptableObject
    {
        [SerializeField] private OperationType _type;
        [SerializeField] private float _value1;
        [SerializeField] private float _value2;

        public OperationType Type => _type;

        public float Value1 => _value1;

        public float Value2 => _value2;
    }
}