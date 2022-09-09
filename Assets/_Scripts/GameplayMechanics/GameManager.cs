using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : GameplaySystems
{
    public static GameManager instance;
    // Start is called before the first frame update

    public bool gameOver;
    public GameObject GameOverCanvas;
    public ScriptableObject ScriptableObjectReference;

    private void OnEnable()
    {
        GameplayUI.triggerGameOver += GameOverEvent;
    }

    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void GameOverEvent()
    {
        gameOver = true;
        GameOverCanvas.SetActive(true);
    }

    
}
