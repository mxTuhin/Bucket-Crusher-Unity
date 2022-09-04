using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoxelBoxGenerator : MonoBehaviour
{
    public GameObject[] voxelCubes;

    [SerializeField]private float xDepthModifier, yDepthModifier, zDepthModifier;

    [SerializeField] private GameObject voxelParent;

    public float voxelPrefabSize;
    // Start is called before the first frame update
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
        var yRange = 8 + yDepthModifier;
        var xRange = 10 + xDepthModifier;
        for (float y = yDepthModifier; y < yRange; y += voxelPrefabSize)
        {
            for (float x = xDepthModifier; x < xRange; x += voxelPrefabSize)
            {
                GameObject tmp = Instantiate(voxelCubes[Random.Range(0, voxelCubes.Length)], new Vector3(x, y, zDepthModifier),
                    Quaternion.Euler(new Vector3(0, Random.Range(-20f, 20f),Random.Range(-20f, 20f))));
                tmp.transform.parent = voxelParent.transform;
            }
        }
        yield break;
    }
}
