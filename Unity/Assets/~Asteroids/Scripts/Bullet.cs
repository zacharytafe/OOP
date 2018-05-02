using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public class Bullet : MonoBehaviour
    {
        void OnTriggerEnter2D(Collider2D col)
        {
            if(col.name.Contains("Asteroid"))
            {
                GameManager.Instance.Addscore(1);
                // Destroy the Asteroid
                Destroy(col.gameObject);
                // Destroy self
                Destroy(this.gameObject);
            }
        }

    }
}
