using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinTrigger : TriggerParent
{
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("VoxelCubes"))
        {
            StartCoroutine(HideAfterTwoSecond(collider));
        }
    }

    IEnumerator HideAfterTwoSecond(Collider collider)
    {
        yield return new WaitForSeconds(2.0f);
        collider.gameObject.SetActive(false);
        yield break;
    }
}
