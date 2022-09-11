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
        public float radius=2f;
        private bool gameOver;
        private bool isPlaying;

        public GameObject PlayerPivot;
        public float horizontalRangeMax, horizontalRangeMin;    
        public float verticalRangeMax, verticalRangeMin;    
        public FloatingJoystick _floatingJoystick;
        
        // UI Action
        public static event Action<float> ReduceGas;

        private void OnEnable()
        {
            GameManager.BroadcastGameOverStatus += GetGameOverStatus;
        }

        void Start()
        {
            //Fetch the Rigidbody from the GameObject with this script attached
            playerRigidbody = GetComponent<Rigidbody>();
        }

        private void Update()
        {
            if (!gameOver && isPlaying)
            {
                horizontalMovement = _floatingJoystick.Horizontal;
                verticalMovement = _floatingJoystick.Vertical;
            }
            else
            {
                horizontalMovement = 0;
                verticalMovement = 0;
            }

            Vector3 movement = new Vector3(horizontalMovement, verticalMovement, 0);
            // playerRigidbody.MovePosition(transform.position + movement * (Time.deltaTime * speedMultiplier));

            float distanceFromPivot = Vector3.Distance(transform.position, PlayerPivot.transform.position);
            
            
            float horizontalOffset = horizontalMovement * speedMultiplier * Time.deltaTime;
            float verticalOffset = verticalMovement * speedMultiplier * Time.deltaTime;

            float rawHorizontalPosition = transform.position.x + horizontalOffset;
            float clampedHorizontalPosition = Mathf.Clamp(rawHorizontalPosition, horizontalRangeMin, horizontalRangeMax);

            float rawVerticalPosition = transform.position.y + verticalOffset;
            float clampedVerticalPosition = Mathf.Clamp(rawVerticalPosition, verticalRangeMin, verticalRangeMax);

            transform.position = new Vector3(clampedHorizontalPosition, clampedVerticalPosition, 0);
         
            if (distanceFromPivot > radius)
            {
                var position = PlayerPivot.transform.position;
                Vector3 differenceFromPivot = transform.position - position;
                // fromOrigintoObject *= radius / dist;
                differenceFromPivot.Normalize();
                transform.position = position + differenceFromPivot*(radius);
            }

            if (movement.magnitude != 0)
            {
                ReduceGas?.Invoke(Time.deltaTime);
            }

        }

        void FixedUpdate()
        {
            
            
        }

        void GetGameOverStatus(bool _isGameOver, bool _isPlaying)
        {
            gameOver = _isGameOver;
            isPlaying = _isPlaying;
        }
}
