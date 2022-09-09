using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public Vector3 transformTowards = new Vector3(1,0,0);
    public Vector3 offset;

    public float smoothSpeed=5f;

    public Vector3 minValue, maxValue;
    

    private void Update()
    {
        
    }

    private void LateUpdate()
    {
        Vector3 desiredPos = new Vector3(target.position.x*transformTowards.x, target.position.y*transformTowards.y, target.position.z) + offset;

        Vector3 clampPos = new Vector3(
            Mathf.Clamp(desiredPos.x, minValue.x, maxValue.x),
            Mathf.Clamp(desiredPos.y, minValue.y, maxValue.y),
            Mathf.Clamp(desiredPos.z, minValue.z, maxValue.z)
        );

        Vector3 smoothPos = Vector3.Lerp(
            transform.position,
            clampPos,
            smoothSpeed * Time.deltaTime
        );
        transform.position = smoothPos;
    }
}
