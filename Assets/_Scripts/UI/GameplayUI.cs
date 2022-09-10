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
    private float toalGas=50;   //Should Retrieve from Scriptable Objects
    private float usedGas;
    public GameObject warning;
    
    [Header("Progress System")]
    private int voxelCubeCount;
    private int triggeredCubeCount;
    public Image progressBar;
    
    [Header("Score System")]
    public TextMeshProUGUI moneyText;
    private float money;
    

    
    
    
    
    
    // UI Actions
    public static event Action triggerGameOver; 
    public static event Action InstantiateCoinAction; 

    private void OnEnable()
    {
        PointTrigger.voxelCollided += UpdateScore;
        VoxelBoxGenerator.voxelCounter += UpdateVoxelCubeCount;
        Destructor.AddProgress += ModifyLevelProgressBar;
        PlayerMovement.ReduceGas += ModifyGasLevel;
    }

    // Start is called before the first frame update
    void Start()
    {
        fillGasBarToPercent();
    }
    
    #region Event Methods
    private void UpdateScore(float amount)
    {
        money += amount;
        moneyText.text = money.ToString("00")+"$";
        // print(money);
        InstantiateCoinAction?.Invoke();
    }

    private void UpdateVoxelCubeCount(int _value)
    {
        voxelCubeCount = _value;
    }

    private void ModifyLevelProgressBar()
    {
        triggeredCubeCount += 1;
        progressBar.fillAmount = (voxelCubeCount - triggeredCubeCount)/(float)voxelCubeCount;
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
        float fillerAmount = ((toalGas - usedGas) * 2 / 100.0f);
        gasBar.fillAmount = fillerAmount;
        if (fillerAmount < 0.15 && !warning.activeSelf)
        {
            warning.gameObject.SetActive(true);
        }

        if (fillerAmount <= 0)
        {
            triggerGameOver?.Invoke();
        }
    }

    
    #endregion
    
    
}
