using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
        Rigidbody playerRigidbody;
        
        [Header("Control Parameters")]
        public float speedMultiplier = 5f;
        private float horizontalMovement;
        private float verticalMovement;
        public float radius=2f;
        
        [Header("Object References")]
        public GameObject PlayerPivot;
        
        public FloatingJoystick _floatingJoystick;
    
    
        void Start()
        {
            //Fetch the Rigidbody from the GameObject with this script attached
            playerRigidbody = GetComponent<Rigidbody>();
        }

        private void Update()
        {
            horizontalMovement = _floatingJoystick.Horizontal;
            verticalMovement = _floatingJoystick.Vertical;
            
            Vector3 movement = new Vector3(horizontalMovement, verticalMovement, 0);
            playerRigidbody.MovePosition(transform.position + movement * (Time.deltaTime * speedMultiplier));

            float distanceFromPivot = Vector3.Distance(transform.position, PlayerPivot.transform.position);
         
            if (distanceFromPivot > radius)
            {
                Vector3 differenceFromPivot = transform.position - PlayerPivot.transform.position;
                // fromOrigintoObject *= radius / dist;
                differenceFromPivot.Normalize();
                transform.position = PlayerPivot.transform.position + differenceFromPivot*(radius-0.07f);
            }

        }

        void FixedUpdate()
        {
            
            
        }
}
