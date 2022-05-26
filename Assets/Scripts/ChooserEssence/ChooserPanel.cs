using System;
using PlayerEssence;
using TMPro;
using UnityEngine;

namespace ChooserEssence
{
    public class ChooserPanel : MonoBehaviour
    {
        [SerializeField] private TMP_Text _tmpText;
        
        private float _value;
        
        public Action<float> OnPlayerEntered;

        public void Init(string operationToString, float value)
        {
            _value = value;
            _tmpText.text = operationToString;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out Player player))
            {
                OnPlayerEntered?.Invoke(_value);
            }
        }
    }
}