using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public Vector3 transformTowards = new Vector3(1,0,0);
    public Vector3 offset;

    public float smoothSpeed=5f;

    public Vector3 minValue, maxValue;

    public GameObject Player;
    private float playerOffsetModifier;

    private void OnEnable()
    {
        GameManager.PlayerObject += GetPlayer;
    }

    private void Start()
    {
        
    }


    private void Update()
    {
        
    }

    private void LateUpdate()
    {
        if (Player.transform.position.x < 5)
        {
            playerOffsetModifier = 0.1f;
        }
        else
        {
            playerOffsetModifier = 0.5f;
        }
        Vector3 desiredPos = new Vector3(target.position.x*transformTowards.x, target.position.y*transformTowards.y, target.position.z)*playerOffsetModifier + offset;

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

    private void GetPlayer(GameObject _player)
    {
        Player = _player;
    }

    private void OnDisable()
    {
        GameManager.PlayerObject -= GetPlayer;
    }
}
