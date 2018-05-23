using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Minesweeper
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class Tile : MonoBehaviour
    {
        public int x, y;
        public bool isMine = false; //Is the current tile a mine?
        public bool isRevealed = false; //Has the tile been revealed?
        [Header("References")]
        public Sprite[] emptySprites; //List of empty sprites
        public Sprite[] mineSprites; //The mine sprites

        private SpriteRenderer rend;

        void Awake()
        {
            //Grab reference to sprie renderer
            rend = GetComponent<SpriteRenderer>(); 
        }

        void Start()
        {
            //Each tile has a 5% chance of being a mine
            isMine = Random.value < .05f;
        }

        public void Reveal(int adjacentMines, int mineState = 0)
        {
            // Flags the tile as being revealed
            isRevealed = true;
            // Check if tile is a mine
            if(isMine)
            {
                // Sets sprite to mine sprite
                rend.sprite = mineSprites[mineState];
            }
            else
            {
                // Sets sprite to appropriate texture
                rend.sprite = emptySprites[adjacentMines];
            }
        }
    }
}