using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameplayUI : MonoBehaviour
{
    [Header("Gameplay UI")] [SerializeField]
    private TextMeshProUGUI moneyText;
    private float money;

    private void OnEnable()
    {
        PointTrigger.voxelCollided += UpdateScore;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void UpdateScore(float amount)
    {
        
        money += amount;
        moneyText.text = money.ToString("00")+"$";
        print(money);
    }
}
