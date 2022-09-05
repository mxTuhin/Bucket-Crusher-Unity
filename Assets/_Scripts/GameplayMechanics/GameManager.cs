using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : GameplaySystems
{
    public static GameManager instance;
    // Start is called before the first frame update

    [Header("Gameplay UI")] [SerializeField]
    private Text score;
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
