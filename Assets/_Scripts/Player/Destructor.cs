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
                // StartCoroutine(AddSphereCollider(collider));
                // rb.drag = 10;
                // rb.angularDrag = 5;
                AddProgress?.Invoke();
            }
        }
    }

    IEnumerator AddSphereCollider(Collider collider)
    {
        yield return new WaitForSeconds(1.5f);
        try
        {
            SphereCollider sc = collider.AddComponent<SphereCollider>();
            sc.radius = 0.6f;
        }
        catch (Exception e)
        {
            
        }
        yield break;

    }
}
