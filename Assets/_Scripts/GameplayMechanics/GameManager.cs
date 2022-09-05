using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : GameplaySystems
{
    public static GameManager instance;
    // Start is called before the first frame update

    public float[] moneyList = {0.5f, 1.0f};
    public float moneyMultiplier=1.0f;
    
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
