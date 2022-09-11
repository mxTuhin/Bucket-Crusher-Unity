using System;
using System.Collections;
using System.Collections.Generic;
using _Scripts.ScriptableSingletonSystem;
using TMPro;
using UnityEngine;
using UnityEngine.Pool;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class GameManager : GameplaySystems
{
    public static GameManager instance;
    // Start is called before the first frame update

    
    public bool gameOver;
    public bool isPlaying;
    
    [Header("Object References")]
    public GameObject GameOverCanvas;
    public ScriptableObject ScriptableObjectReference;
    public GameObject Player;
    [Header("Object Reference")] public Material[] _Materials;
    
    [Header("Coin Instantiation System")]
    public GameObject coinInstantiator;
    public GameObject coinPrefab;
    public GameObject coinParent;
    public int coinPoolLimit;

    //Coin Pooling Mechanics
    public static ObjectPool<GameObject> SharedInstance;
    public List<GameObject> pooledObjects;


    // Gameobjects Events
    public static event Action<GameObject> PlayerObject;
    public static event Action<bool, bool> BroadcastGameOverStatus;


    private void OnEnable()
    {
        
        if (Player != null)
        {
            PlayerObject?.Invoke(Player);
        }
        
        GameplayUI.triggerGameOver += GameOverEvent;
        GameplayUI.InstantiateCoinAction += DropCoin;
        MainMenu.TriggerPlaying += setPlayingStatus;
    }

    void Start()
    {
        instance = this;
        CallInitiateCoinPool();
        isPlaying = false;

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void GameOverEvent()
    {
        gameOver = true;
        isPlaying = false;
        BroadcastGameOverStatus?.Invoke(gameOver, isPlaying);
        GameOverCanvas.SetActive(gameOver);
    }

    public void setPlayingStatus(bool _status)
    {
        isPlaying = _status;
        BroadcastGameOverStatus?.Invoke(false, true);
    }
    
    #region Reference Methods
    
    
    
    public GameObject GetPooledObject()
    {
        for(int i = 0; i < coinPoolLimit; i++)
        {
            if(!pooledObjects[i].activeInHierarchy)
            {
                return pooledObjects[i];
            }
        }
        return null;
    }
    
    private void CallInitiateCoinPool()
    {
        StartCoroutine(InstantiateCoinPool());
    }
    
    private void DropCoin()
    {
        GameObject bullet = GetPooledObject(); 
        if (bullet != null) {
            bullet.transform.position = coinInstantiator.transform.position;
            bullet.transform.rotation = Quaternion.identity;
            bullet.SetActive(true);
        }
    }

    #endregion
    
    #region Enumerations

    IEnumerator InstantiateCoinPool()
    {
        // GameObject temp = Instantiate(coinPrefab, coinInstantiator.transform.position, Quaternion.identity);
        pooledObjects = new List<GameObject>();
        GameObject temp;
        for (int i = 0; i < coinPoolLimit; ++i)
        {
            temp = Instantiate(coinPrefab);
            temp.GetComponent<Renderer>().material = _Materials[Random.Range(0, _Materials.Length)];
            temp.transform.GetChild(0).gameObject.GetComponent<TextMeshPro>().text = GameControlManager.VariablesSingleton.returnMoneyListElement().ToString();
            temp.transform.parent = coinParent.transform;
            temp.SetActive(false);
            pooledObjects.Add(temp);
        }
        
        yield break;
    }
    
    
        
    #endregion
    
    

    
}
