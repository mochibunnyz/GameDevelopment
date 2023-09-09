using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stepPuzzle : MonoBehaviour
{
    
    
    
    public static int whiteStepNum;
    public static bool hasBlackStep;
    public GameObject puzzlePanel;
    private float time = 5f;
    // Store the initial positions of the character and tiles
    
    private Dictionary<Transform, Material> initialTileMaterials;



    // Start is called before the first frame update
    void Start()
    {
        
        //initial for start of puzzle
        whiteStepNum = 0;
        hasBlackStep = false;
        puzzlePanel.SetActive(false);

        // Store the initial materials of all child tiles
        initialTileMaterials = new Dictionary<Transform, Material>();
        foreach (Transform child in transform)
        {
            Renderer tileRenderer = child.GetComponent<Renderer>();
            LightUpStep tileScript = child.GetComponent<LightUpStep>();
            if (tileRenderer != null && tileScript != null)
            {
                initialTileMaterials[child] = tileRenderer.material;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        //if puzzle has black stpe, reset puzzle
        if (hasBlackStep == true)
        {
            
            Debug.Log("Player has failed the Step Puzzle");
            ResetPuzzle();

        }

        //if puzzle has been solved, destroy the gameobject
        if (whiteStepNum == 10)
        {
            
            Debug.Log("Player has solved the Step Puzzle");
            Destroy(gameObject);
            


        }
    }

    void ResetPuzzle()
    {
        // Reset whiteStepNum and hasBlackStep
        whiteStepNum = 0;
        hasBlackStep = false;
        //show panel message
        puzzlePanel.SetActive(true);

        // Reset the materials of all child tiles and reset individual tiles
        foreach (Transform child in transform)
        {
            Renderer tileRenderer = child.GetComponent<Renderer>();
            LightUpStep tileScript = child.GetComponent<LightUpStep>();

            if (tileRenderer != null && tileScript != null)
            {
                tileScript.ResetTile();

                if (initialTileMaterials.ContainsKey(child))
                {
                    tileRenderer.material = initialTileMaterials[child];
                }
            }
        }

        //call function after 5s.
        Invoke("DeactivatePanel", time);


    }

    //hide panel message
    private void DeactivatePanel()
    {
        puzzlePanel.SetActive(false);
    }

}
