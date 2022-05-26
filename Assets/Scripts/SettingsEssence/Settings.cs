using UnityEngine;

namespace SettingsEssence
{
    [CreateAssetMenu(fileName = "Settings", menuName = "Settings", order = 0)]
    public class Settings : ScriptableObject
    {
        [SerializeField] private float _sensitivity = 1;

        public float Sensitivity => _sensitivity;
    }
}