﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public class Shooting : MonoBehaviour
    {
        public GameObject bulletPrefab;
        public Transform[] spawnPoint;
        public float bulletSpeed = 5f;

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        // Method in charge of firing a bullet
        public void Fire(Vector3 direction)
        {
            // Loop through all the spawn points
            for (int i = 0; i < spawnPoint.Length; i++)
            {
                // Spawn a bullet for each one
                Spawn(direction, spawnPoint[i].position);
            }
        }
        
        void Spawn(Vector3 direction, Vector3 point)
        {
            // Make a clone of bulletPrefab
            GameObject clone = Instantiate(bulletPrefab);
            // Set clone's position to spawnPoint position
            clone.transform.position = point;
            //Rotate the bullet clone
            float angle = Mathf.Atan2(direction.y, direction.x);
            float degrees = angle * Mathf.Rad2Deg;
            clone.transform.rotation = Quaternion.AngleAxis(degrees, Vector3.forward);
            // Tell its Rigidbody2D to fly in direction
            Rigidbody2D rigid = clone.GetComponent<Rigidbody2D>();
            rigid.AddForce(direction * bulletSpeed, ForceMode2D.Impulse);
        }
    }
}
