using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class VoxelBoxGenerator : MonoBehaviour
{
    [Header("Prefab & Object Referbece")]
    public GameObject[] voxelCubes;
    [SerializeField] private GameObject voxelParent;

    [Header("Modifiers")]
    [SerializeField]private float xDepthModifier;

    [SerializeField] private float yDepthModifier;
    [SerializeField]private float zDepthModifier;

    [Header("Values & Parameters")] 
    [SerializeField]
    private float xMax;
    [SerializeField] private float yMax;

    public float voxelPrefabSize;
    // Start is called before the first frame update

    public static event Action<int> voxelCounter; 
    void Start()
    {
        StartCoroutine(createVoxelMap());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator createVoxelMap()
    {
        var yRange = yMax + yDepthModifier;
        var xRange = xMax + xDepthModifier;
        for (float y = yDepthModifier; y < yRange; y += voxelPrefabSize)
        {
            for (float x = xDepthModifier; x < xRange; x += voxelPrefabSize)
            {
                GameObject tmp = Instantiate(voxelCubes[Random.Range(0, voxelCubes.Length)], new Vector3(x, y, zDepthModifier),
                    Quaternion.Euler(new Vector3(0, Random.Range(-20f, 20f),Random.Range(-20f, 20f))));
                tmp.transform.parent = voxelParent.transform;
            }
        }
        voxelCounter?.Invoke(voxelParent.transform.childCount);
        yield break;
    }
    
}
