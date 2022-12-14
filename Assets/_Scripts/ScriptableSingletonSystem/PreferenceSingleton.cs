using UnityEngine;

namespace _Scripts.ScriptableSingletonSystem
{
    [CreateAssetMenu(menuName = "Custom/PreferenceSingleton")]
    public class PreferenceSingleton : ScriptableObject
    {
        public float manipulatorStage;
        public float[] manipulatorRange;
        public float strengthStage;
        public float gasStage;
        public float spikeStage;
        
        [Header("Extra Features")]
        public float moneyMultiplier=1.0f;

        public void setValues(float _manipulatorStage, float _strengthStage, float _gasStage, float _spikeStage)
        {
            manipulatorStage = _manipulatorStage;
            strengthStage = _strengthStage;
            gasStage = _gasStage;
            spikeStage = _spikeStage;
            
            PlayerPrefs.SetFloat("manipulatorStage", _manipulatorStage);
            PlayerPrefs.SetFloat("strengthStage", _strengthStage);
            PlayerPrefs.SetFloat("gasStage", _gasStage);
            PlayerPrefs.SetFloat("spikeStage", _spikeStage);
        }
    }
    
}
