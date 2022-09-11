using System;
using System.Collections;
using System.Collections.Generic;
using _Scripts.ScriptableSingletonSystem;
using UnityEngine;

public class PlayerPrefManager : MonoBehaviour
{
    private void OnEnable()
    {
        var _vSingleton = GameControlManager.VariablesSingleton;
        _vSingleton.availableMoney = (int) PlayerPrefs.GetFloat("Money");
        _vSingleton.fuelLevel = PlayerPrefs.GetInt("FuelLevel");
        _vSingleton.powerLevel = PlayerPrefs.GetInt("PowerLevel");
        _vSingleton.sizeLevel = PlayerPrefs.GetInt("SizeLevel");
    }
}
