using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureSpawner : MonoBehaviour
{
    public static bool hasSolved;
    public GameObject treasureToSpawn;
    // Start is called before the first frame update
    void Start()
    {
        hasSolved = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(hasSolved == true)
        {
            Instantiate(treasureToSpawn, transform.position, Quaternion.identity);
            enabled = false;
        }
    }
}
