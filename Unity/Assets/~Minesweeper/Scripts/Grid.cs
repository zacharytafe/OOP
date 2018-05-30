using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Minesweeper
{
    public class Grid : MonoBehaviour
    {
        public GameObject tilePrefab;
        public int width = 10, height = 10;
        public float spacing = .155f;

        private Tile[,] tiles;
        
        // Function for spawing tiles
        Tile SpawnTile(Vector3 pos)
        {
            //Clone the prefab
            GameObject clone = Instantiate(tilePrefab);
            //Edit it's properties
            clone.transform.position = pos;
            Tile currentTile = clone.GetComponent<Tile>();
            // Return it
            return currentTile;
        }

        //Spawns tiles in a grid like pattern
        void GenerateTiles()
        {
            //Create a new 2D array of size width x hieght
            tiles = new Tile[width, height];
            //Nested Loop through tyhe entire tile list
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    Vector2 halfSize = new Vector2(width * 0.5f, height * 0.5f);
                    Vector2 pos = new Vector2(x - halfSize.x, y - halfSize.y);
                    pos += new Vector2(.5f, .5f);

                    pos *= spacing;

                    Tile tile = SpawnTile(pos);
                    tile.transform.SetParent(transform);
                    tile.x = x;
                    tile.y = y;
                    tiles[x, y] = tile;
                }
            }
        }

        void Start()
        {
            GenerateTiles(); 
        }

        public int GetAdjacentMineCount(Tile tile)
        {
            int count = 0;
            for (int x = -1; x <= 1; x++)
            {
                for (int y = -1; y <= 1; y++)
                {
                    int desiredX = tile.x + x;
                    int desiredY = tile.y + y;

                    //Check if the desired x & y is within bounds
                    if(desiredX < 0 || desiredX >= width||
                       desiredY < 0 || desiredY >= height)
                    {
                        continue;
                    }

                    Tile currentTile = tiles[desiredX, desiredY];
                    if (currentTile.isMine)
                    {
                        // Increment by 1
                        count++;
                    }
                }
            }
            return count;
        }

        void SelectATile()
        {
            Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mouseRay.origin, mouseRay.direction);
            if (hit.collider != null)
            {
                Tile hitTile = hit.collider.GetComponent<Tile>();
                if (hitTile != null)
                {
                    int adjacentMines = GetAdjacentMineCount(hitTile);
                    hitTile.Reveal(adjacentMines);
                }
            }
        }
        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                SelectATile();
            }
        }
        
        void FFuncover(int x, int y, bool[,] visited)
        {
            // Is x and y within bounds of the grid?
            if(x >= 0 && y >= 0 &&
               x < width && y < height)
            {
                // Have these coordinates been visited?
                if (visited[x, y])
                    return;
                // reveal tile in that x and y coordinate
                Tile tile = tiles[x, y];
                int adjacentMines = GetAdjacentMineCount(tile);
                tile.Reveal(adjacentMines);

                // If there were no adjacent mines around that tile
                if (adjacentMines == 0)
                {
                    // This tile has been visited
                    visited[x, y] = true;
                    // visit all other tiles around this tile
                    FFuncover(x - 1, y, visited);
                    FFuncover(x + 1, y, visited);
                    FFuncover(x, y - 1, visited);
                    FFuncover(x, y + 1, visited);
                }
            }
        }
    }
}