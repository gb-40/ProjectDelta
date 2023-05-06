using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallSpawner : MonoBehaviour
{
public GameObject[] wallPrefabs; 
public int NumOfWalls  = 10; 
private float range = 45f; 

private List<GameObject> walls = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        GenerateWalls();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
   void GenerateWalls()
{
    // Determine the number of rows and columns in the grid
    int numRows = Mathf.CeilToInt(range * 2 / 20);
    int numCols = Mathf.CeilToInt(range * 2 / 50);

    // Determine the size of each grid cell
    float cellSizeX = range * 2 / numCols;
    float cellSizeY = range * 2 / numRows;

    // Loop over each grid cell and spawn a wall in a random location within the cell
    for (int row = 0; row < numRows; row++)
    {
        for (int col = 0; col < numCols; col++)
        {
            // Determine the center point of the grid cell
            float centerX = (col + 0.5f) * cellSizeX - range;
            float centerY = (row + 0.5f) * cellSizeY - range;

            // Spawn a wall at a random point within the cell
            Vector2 pos = new Vector2(
                Random.Range(centerX - cellSizeX / 2, centerX + cellSizeX / 2),
                Random.Range(centerY - cellSizeY / 2, centerY + cellSizeY / 2)
            );

            // Pick a random wall prefab and spawn it at the chosen location
            int randomIndex = UnityEngine.Random.Range(0, wallPrefabs.Length);
            GameObject wallPrefab = wallPrefabs[randomIndex];
            GameObject wall = Instantiate(wallPrefab, pos, Quaternion.identity);

            // Check for overlap with existing walls and reposition the new wall if necessary
           // while (CheckOverlap(walls, wall))
            {
                pos = new Vector2(
                    Random.Range(centerX - cellSizeX / 2, centerX + cellSizeX / 2),
                    Random.Range(centerY - cellSizeY / 2, centerY + cellSizeY / 2)
                );
                wall.transform.position = pos;
            }

            // Add the new wall to the list of walls
            walls.Add(wall);
        }
    }
}
}

    
