using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointTrigger : MonoBehaviour, ITriggerAble
{
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("VoxelCubes"))
        {
            
        }
    }

    public void Trigger()
    {
        throw new System.NotImplementedException();
    }
}
