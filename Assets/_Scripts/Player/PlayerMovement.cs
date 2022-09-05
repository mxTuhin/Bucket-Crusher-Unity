using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
        Rigidbody playerRigidbody;
        public float speedMultiplier = 5f;
        private float horizontalMovement;
        private float verticalMovement;
    
        void Start()
        {
            //Fetch the Rigidbody from the GameObject with this script attached
            playerRigidbody = GetComponent<Rigidbody>();
        }

        private void Update()
        {
            horizontalMovement = Input.GetAxis("Horizontal");
            verticalMovement = Input.GetAxis("Vertical");
        }

        void FixedUpdate()
        {
            //Store user input as a movement vector
            Vector3 m_Input = new Vector3(horizontalMovement, verticalMovement, 0);
    
            //Apply the movement vector to the current position, which is
            //multiplied by deltaTime and speed for a smooth MovePosition
            playerRigidbody.MovePosition(transform.position + m_Input * (Time.deltaTime * speedMultiplier));
        }
}
