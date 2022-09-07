using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Destructor : MonoBehaviour
{
    public static event Action AddProgress;
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("VoxelCubes"))
        {
            if (collider.GetComponent<Rigidbody>() == null)
            {
                Rigidbody rb = collider.AddComponent<Rigidbody>();
                var tempContraints = RigidbodyConstraints.FreezePositionZ;
                rb.constraints = tempContraints;
                rb.mass = 100;
                // rb.drag = 10;
                // rb.angularDrag = 5;
                AddProgress?.Invoke();
            }
        }
    }
}
