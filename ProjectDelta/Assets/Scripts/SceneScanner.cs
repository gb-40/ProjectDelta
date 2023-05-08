using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneScanner : MonoBehaviour
{
    private AstarPath astar;

    private void Start()
    {
        // Get a reference to the AstarPath component
        astar = FindObjectOfType<AstarPath>();

        if (astar != null)
        {
            // Call ScanScene after a delay of 1 second
            Invoke("ScanScene", 1f);
        }
        else
        {
            Debug.LogError("AstarPath component not found in the scene!");
        }
    }

    private void OnDestroy()
    {
        // Cancel any pending invoke calls if the script component is destroyed
        CancelInvoke();
    }

    private void ScanScene()
    {
        // Scan the graph of the AstarPath component
        astar.Scan();
    }
}