using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoxelBoxGenerator : MonoBehaviour
{
    public GameObject[] voxelCubes;

    [SerializeField]private float zDepthModifier;

    [SerializeField] private GameObject voxelParent;
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
        for (float y = 0; y < 3; y += 0.1f)
        {
            for (float x = 0; x < 5; x += 0.1f)
            {
                GameObject tmp = Instantiate(voxelCubes[Random.Range(0, voxelCubes.Length)], new Vector3(x, y, zDepthModifier),
                    Quaternion.identity);
                tmp.transform.parent = voxelParent.transform;
            }
        }
        yield break;
    }
}
