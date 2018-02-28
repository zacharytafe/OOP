using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public class Moving : MonoBehaviour
    {
        public float acceleration = 5f;
        public float rotationSpeed = 5f;
        public float maxVelocity = 3f;

        private Rigidbody2D rigid;

        // Use this for initialization
        void Start()
        {
            rigid = GetComponent<Rigidbody2D>();
        }

        // Update is called once per frame
        void Update()
        {
            LimitVelocity();
        }

        //Capping the velocity when it goes too high
        void LimitVelocity()
        {
            Vector3 vel = rigid.velocity;
            if(vel.magnitude > maxVelocity)
            {
                vel = vel.normalized * maxVelocity;
            }
            // Applies the copied varible to velocity
            rigid.velocity = vel;
        }

        public void Accelerate(Vector3 direction)
        {
            rigid.AddForce(direction * acceleration);
        }

        public void Rotate(float angleOffset)
        {
            rigid.rotation -= angleOffset * rotationSpeed * Time.deltaTime;
        }
    }
}