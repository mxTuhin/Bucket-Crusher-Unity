using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class PointTrigger : MonoBehaviour, ITriggerAble
{
    public static event Action<float> voxelCollided;
    // public Transform coinInstantiator;
    // public GameObject coin;
    // public TextMeshPro coinText;
    
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("VoxelCubes"))
        {
            // print("Voxel Cubes Colliding");
            Trigger();
            Destroy(collider.gameObject);
        }
    }

    public void Trigger()
    {
        float amount = GameManager.instance.moneyList[Random.Range(1, 2)];
        voxelCollided?.Invoke(amount*GameManager.instance.moneyMultiplier);
    }
}
