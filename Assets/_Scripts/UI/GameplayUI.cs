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
    
    

    private void OnEnable()
    {
        PointTrigger.voxelCollided += UpdateScore;
        VoxelBoxGenerator.voxelCounter += UpdateVoxelCubeCount;
        Destructor.AddProgress += ModifyLevelProgressBar;
    }

    // Start is called before the first frame update
    void Start()
    {
        
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
}
