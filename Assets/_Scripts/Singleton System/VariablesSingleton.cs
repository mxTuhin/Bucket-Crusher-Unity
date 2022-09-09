using UnityEngine;

namespace _Scripts.Singleton_System
{
    [CreateAssetMenu(menuName = "Custom/VariablesSingleton")]
    public class VariablesSingleton : ScriptableObject
    {
        public float[] moneyList = {0.5f, 1.0f};
        public float moneyMultiplier=1.0f;
    }
}
