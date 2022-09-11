using System;
using System.Collections;
using System.Collections.Generic;
using _Scripts.ScriptableSingletonSystem;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : GameplaySystems
{
    [Header("Settings Reference")] public GameObject onSprite;

    public GameObject offSprite;

    private bool isSoundOn;

    [Header("Play And Control Box Reference")]
    public Animator playAnimation;

    [Header("Capability Modifiers")] public Text manipulatorPrice;
    public Text fuelPrice;
    public Text powerPrice;
    public Text sizePrice;
    private VariablesSingleton _vSingleton;
    

    //Action Events
    public static event Action<bool> ToggleSound;
    public static event Action<bool> TriggerPlaying;
    public static event Action<float> IncreaseFuel;
    public static event Action<float> TriggerCash;

    public static event Action<int> IncreaseSize;
    public static event Action<int> IncreasePower; 


    // Start is called before the first frame update
    void Start()
    {
        isSoundOn = true;
        _vSingleton = GameControlManager.VariablesSingleton;
        // setManipulatorPrice();
        setFuelPrice();
        setPowerPrice();
        setSizePrice();

        if (PlayerPrefs.GetInt("SizeLevel") >= _vSingleton.sizePrices.Length - 1)
        {
            sizePrice.text = "MAX";
            sizePrice.GetComponentInParent<Button>().interactable = false;
        }
            
        if (PlayerPrefs.GetInt("PowerLevel") >= _vSingleton.powerPrices.Length - 1)
        {
            powerPrice.text = "MAX";
            powerPrice.GetComponentInParent<Button>().interactable = false;
        }
        
        if (PlayerPrefs.GetInt("FuelLevel") >= _vSingleton.fuelPrices.Length - 1)
        {
            fuelPrice.text = "MAX";
            fuelPrice.GetComponentInParent<Button>().interactable = false;
        }
        

        
        IncreaseFuel?.Invoke(_vSingleton.fuelLevel*5);
        IncreasePower?.Invoke(_vSingleton.powerLevel);
        
    }
    

    public void toggleSoundSwitch()
    {
        if (isSoundOn)
        {
            isSoundOn = false;
            onSprite.SetActive(isSoundOn);
            offSprite.SetActive(!isSoundOn);
            
        }
        else
        {
            isSoundOn = true;
            onSprite.SetActive(isSoundOn);
            offSprite.SetActive(!isSoundOn);
            
        }
        ToggleSound?.Invoke(isSoundOn);
    }

    public void Play()
    {
        playAnimation.SetTrigger("isPlaying");
        TriggerPlaying?.Invoke(true);
    }

    public void increaseFuel()
    {
        if (!(_vSingleton.availableMoney > _vSingleton.fuelPrices[_vSingleton.fuelLevel]))
            return;
        
        invokeTriggerCash(_vSingleton.fuelPrices[_vSingleton.fuelLevel]);
        IncreaseFuel?.Invoke(5);
        _vSingleton.fuelLevel += 1;
        setFuelPrice();
        
    }

    public void increasePower()
    {
        if (!(_vSingleton.availableMoney > _vSingleton.powerPrices[_vSingleton.powerLevel]))
            return;
        
        invokeTriggerCash(_vSingleton.powerPrices[_vSingleton.powerLevel]);
        IncreasePower?.Invoke(_vSingleton.powerLevel);
        _vSingleton.powerLevel += 1;
        setPowerPrice();
        
    }

    public void increaseSize()
    {
        if (!(_vSingleton.availableMoney > _vSingleton.sizePrices[_vSingleton.sizeLevel]))
            return;

        invokeTriggerCash(_vSingleton.sizePrices[_vSingleton.sizeLevel]);
        _vSingleton.sizeLevel += 1;
        setSizePrice();
        
        
    }

    private void setManipulatorPrice()
    {
        manipulatorPrice.text = _vSingleton.manipulatorPrices[_vSingleton.manipulatorLevel]+" $";
        
    }
    private void setFuelPrice()
    {
        if (_vSingleton.fuelLevel >= _vSingleton.fuelPrices.Length)
        {
            fuelPrice.text = "MAX";
            fuelPrice.GetComponentInParent<Button>().interactable = false;
        }
        else
        {
            float temp = _vSingleton.fuelPrices[_vSingleton.fuelLevel];
            fuelPrice.text = temp+" $";
            PlayerPrefs.SetInt("FuelLevel", _vSingleton.fuelLevel);
        }
        
        
    }
    private void setPowerPrice()
    {
        if (_vSingleton.powerLevel >= _vSingleton.powerPrices.Length)
        {
            powerPrice.text = "MAX";
            powerPrice.GetComponentInParent<Button>().interactable = false;
        }
        else
        {
            float temp = _vSingleton.powerPrices[_vSingleton.powerLevel];
            powerPrice.text = temp+" $";
            
            PlayerPrefs.SetInt("PowerLevel", _vSingleton.powerLevel);
        }
        
    }
    
    private void setSizePrice()
    {
        if (_vSingleton.sizeLevel >= _vSingleton.sizePrices.Length)
        {
            sizePrice.text = "MAX";
            sizePrice.GetComponentInParent<Button>().interactable = false;
        }
        else
        {
            float temp = _vSingleton.sizePrices[_vSingleton.sizeLevel];
            sizePrice.text = temp+" $";
            IncreaseSize?.Invoke(_vSingleton.sizeLevel);
            PlayerPrefs.SetInt("SizeLevel", _vSingleton.sizeLevel);
        }
        
        
        
        
    }

    private void invokeTriggerCash(float _value)
    {
        TriggerCash?.Invoke(-_value);
    }
    
    

   
}
