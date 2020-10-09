using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{

    //parameters
    [SerializeField] int BreakableBlocks;  // Serialized for debugging purposes

    // cached reference
    SceneLoader sceneloader;

    private void Start()
    {
        sceneloader = FindObjectOfType<SceneLoader>();
    }

    public void CountBlocks()
    {
        BreakableBlocks++;
    }

    public void BlockDestroyed()
    {
        BreakableBlocks--;
        if (BreakableBlocks <= 0)
        {
            sceneloader.LoadNextScene();
        }
    }
}
