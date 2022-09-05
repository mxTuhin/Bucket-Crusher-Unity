using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InverseKinematicsController
{
    public class IKSystem : MonoBehaviour
    {
        [Header("Joint References")]
        //Armature Root
        [SerializeField]
        private Joint root;
    
        //End Effector
        [SerializeField]
        private Joint end;
    
        //Target Object
        public GameObject target;
        
        [Header("Control Variables")]

        public float threshold = 0.05f;

        public float followRate;
        
        public int steps = 20;


        // Update is called once per frame
        void Update()
        {
            for (int i = 0; i < steps; ++i)
            {
                if (GetDistance(end.transform.position, target.transform.position) > threshold)
                {
                    Joint current = root;
                    while (current != null)
                    {
                        float slope = CalculateSlope(current);
                        current.Rotate(-slope*followRate);
                        current = current.GetChild();
                    }
                
                }
            }
        }
    
        private float CalculateSlope(Joint _joint)
        {
            float deltaTheta = 0.01f;
            
            float distance1 = GetDistance(end.transform.position, target.transform.position);
            _joint.Rotate(deltaTheta);
            
            float distance2 = GetDistance(end.transform.position, target.transform.position);
            _joint.Rotate(-deltaTheta);

            return (distance2 - distance1) / deltaTheta;
        }

        private float GetDistance(Vector3 _point1, Vector3 _point2)
        {
            return Vector3.Distance(_point1, _point2);
        }
    }

}
