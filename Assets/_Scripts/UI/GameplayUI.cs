using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameplayUI : MonoBehaviour
{
    
    
    private int voxelCubeCount;
    private int triggeredCubeCount;
    [SerializeField] private Image progressBar;
    
    
    [SerializeField] private TextMeshProUGUI moneyText;
    private float money;

    public GameObject warning;
    
    public Image gasBar;
    private float toalGas=10;   //Should Retrieve from Scriptable Objects
    private float usedGas;
    
    
    
    
    
    public static event Action triggerGameOver; 

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
    

    private void UpdateScore(float amount)
    {
        money += amount;
        moneyText.text = money.ToString("00")+"$";
        // print(money);
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
}
