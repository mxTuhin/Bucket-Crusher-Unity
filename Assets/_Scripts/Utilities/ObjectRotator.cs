using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectRotator : MonoBehaviour
{
    // the speed of the rotation
    public float speed = 100.0f;

    // setup the possible rotation states
    public enum whichWayToRotate { AroundX, AroundY, AroundZ }

    // set the direction of the rotation
    public whichWayToRotate way = whichWayToRotate.AroundX;

    // Update is called once per frame
    void Update()
    {
        // do the appropriate rotation based on the way state
        switch (way)
        {
            case whichWayToRotate.AroundX:
                transform.Rotate(Vector3.right * Time.deltaTime * speed);
                break;
            case whichWayToRotate.AroundY:
                transform.Rotate(Vector3.up * Time.deltaTime * speed);
                break;
            case whichWayToRotate.AroundZ:
                transform.Rotate(Vector3.forward * Time.deltaTime * speed);
                break;
        }
    }
}
