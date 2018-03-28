﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

namespace Asteroids
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance = null;

        public Text scoreText;

        private int score = 0;

        // Use this for initialization
        void Start()
        {
            // If an instance of GameManager hasn't been created
            if (Instance == null)
            {
                // Set to first instance of GameManager
                Instance = this;
            }
            else
            {
                // Destroy any other instances of GameManager
                Destroy(gameObject);
            }
        }


        // Update is called once per frame
        void Update()
        {
            scoreText.text = "Score: " + score.ToString();
        }

        public void Addscore(int scoreToAdd)
        {
            score += scoreToAdd;
        }
    }
}
