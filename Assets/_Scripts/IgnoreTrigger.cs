using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgnoreTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("VoxelCubes"))
        {
            Destroy(collider.gameObject, 2.0f);
        }
    }

}
