using System;
using System.Collections;
using System.Collections.Generic;
using _Scripts.ScriptableSingletonSystem;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class GameplayUI : MonoBehaviour
{

    
    
    [Header("Gas Can")]
    public Image gasBar;
    private float totalGas=20;   //Should Retrieve from Scriptable Objects
    private float usedGas;
    public GameObject warningSprite;
    
    [Header("Progress System")]
    private int voxelCubeCount;
    private int triggeredCubeCount;
    public Image progressBar;
    
    [Header("Score System")]
    public TextMeshProUGUI moneyText;
    private float money;

    public GameObject GameCompleted;
    

    
    
    
    
    
    // UI Actions
    public static event Action triggerGameOver; 
    public static event Action InstantiateCoinAction; 

    private void OnEnable()
    {
        PointTrigger.voxelCollided += UpdateScore;
        VoxelBoxGenerator.voxelCounter += UpdateVoxelCubeCount;
        Destructor.AddProgress += ModifyLevelProgressBar;
        PlayerMovement.ReduceGas += ModifyGasLevel;
        MainMenu.IncreaseFuel += UpdateGasValue;
        MainMenu.TriggerCash += UpdateScore;
    }

    // Start is called before the first frame update
    void Start()
    {
        fillGasBarToPercent();
        money = GameControlManager.VariablesSingleton.availableMoney;
        moneyText.text = money.ToString("00")+"$";
    }
    
    #region Event Methods
    private void UpdateScore(float amount)
    {
        
        money += amount;
        moneyText.text = money.ToString("00")+"$";
        GameControlManager.VariablesSingleton.availableMoney = (int)money;
        // print(money);
        InstantiateCoinAction?.Invoke();
    }
    
    private void UpdateGasValue(float _value)
    {
        totalGas += _value;
        fillGasBarToPercent();
    }

    private void UpdateVoxelCubeCount(int _value)
    {
        voxelCubeCount = _value;
    }

    private void ModifyLevelProgressBar()
    {
        triggeredCubeCount += 1;
        progressBar.fillAmount = (voxelCubeCount - triggeredCubeCount)/(float)voxelCubeCount;
        if (progressBar.fillAmount <= 0)
        {
            GameCompleted.SetActive(true);
        }
    }

    private void ModifyGasLevel(float _value)
    {
        usedGas += _value;
        fillGasBarToPercent();
    }
    
    
    #endregion
    
    #region Reference Methods
    private void fillGasBarToPercent()
    {
        float fillerAmount = ((totalGas - usedGas) * 2 / 100.0f);
        gasBar.fillAmount = fillerAmount;
        if (fillerAmount < 0.15)
        {
            warningSprite.SetActive(true);
        }

        if (fillerAmount <= 0)
        {
            triggerGameOver?.Invoke();
        }
    }

    
    #endregion

    private void OnDisable()
    {
        PointTrigger.voxelCollided -= UpdateScore;
        VoxelBoxGenerator.voxelCounter -= UpdateVoxelCubeCount;
        Destructor.AddProgress -= ModifyLevelProgressBar;
        PlayerMovement.ReduceGas -= ModifyGasLevel;
        MainMenu.IncreaseFuel -= UpdateGasValue;
        MainMenu.TriggerCash -= UpdateScore;
    }
}
