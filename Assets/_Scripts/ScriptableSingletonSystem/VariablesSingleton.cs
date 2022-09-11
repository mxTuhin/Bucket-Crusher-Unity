using UnityEngine;

namespace _Scripts.ScriptableSingletonSystem
{
    [CreateAssetMenu(menuName = "Custom/VariablesSingleton")]
    public class VariablesSingleton : ScriptableObject
    {
        public float[] moneyList = {0.5f, 1.0f};

        public int availableMoney;

        [Header("Capability Modifiers")] 
        
        public float[] manipulatorPrices;
        public int manipulatorLevel = 0;
        
        public float[] fuelPrices;
        public int fuelLevel = 0;
        
        public float[] powerPrices;
        public int powerLevel = 0;
        
        public float[] sizePrices;
        public int sizeLevel = 0;



        public float returnMoneyListElement()
        {
            return GameControlManager.PreferenceSingleton.moneyMultiplier*moneyList[Random.Range(0, moneyList.Length)];
        }
    }
}
