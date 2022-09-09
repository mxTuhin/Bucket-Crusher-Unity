using UnityEngine;

namespace _Scripts.ScriptableSingletonSystem
{
    [CreateAssetMenu(menuName = "Custom/GameControlManager")]
    public class GameControlManager : SingletonScriptableObject<GameControlManager>
    {
        [SerializeField] private VariablesSingleton _variablesSingleton;
        [SerializeField] private PreferenceSingleton _preferenceSingleton;

        public static VariablesSingleton VariablesSingleton
        {
            get
            {
                return Instance._variablesSingleton;
            }
        }

        public static PreferenceSingleton PreferenceSingleton
        {
            get
            {
                return Instance._preferenceSingleton;
            }
        }
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        private static void FirstInitialize()
        {
            Debug.Log("Serialized Object Init");
        }
    }
}
