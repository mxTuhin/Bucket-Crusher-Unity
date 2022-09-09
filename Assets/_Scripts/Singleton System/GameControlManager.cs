using UnityEngine;

namespace _Scripts.Singleton_System
{
    [CreateAssetMenu(menuName = "Custom/GameControlManager")]
    public class GameControlManager : SingletonScriptableObject<GameControlManager>
    {
        [SerializeField] private VariablesSingleton _variablesSingleton;

        public static VariablesSingleton VariablesSingleton
        {
            get
            {
                return Instance._variablesSingleton;
            }
        }
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        private static void FirstInitialize()
        {
            Debug.Log("Serialized Object Init");
        }
    }
}
