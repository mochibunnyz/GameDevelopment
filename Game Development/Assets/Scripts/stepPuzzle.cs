using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stepPuzzle : MonoBehaviour
{
    public static int whiteStepNum;
    public static bool hasBlackStep;

    public GameObject tilePuzzlePanel;
    public float TPDuration = 5f;
    private bool isActivated = false;

    public Material steppedMaterial;

    public List<GameObject> tiles;

    private List<Material> originalMaterials;

    // Start is called before the first frame update
    void Start()
    {
        whiteStepNum = 0;
        hasBlackStep = false;
        tilePuzzlePanel.SetActive(false);

        originalMaterials = new List<Material>();

        // Store the original material of each tile
        foreach (var tile in tiles)
        {
            var renderer = tile.GetComponent<Renderer>();
            if (renderer != null)
            {
                originalMaterials.Add(renderer.material);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (hasBlackStep == true)
        {
            Debug.Log("Player has failed the Step Puzzle");
            ResetTilesToOriginalMaterial();
            whiteStepNum = 0;
            hasBlackStep = false;

            if (!isActivated)
            {
                isActivated = true;
                ActivateForDuration();
            }
        }

        if (whiteStepNum == 10)
        {
            Debug.Log("Player has solved the Step Puzzle");
            Destroy(gameObject);
        }
    }

    private void ActivateForDuration()
    {
        tilePuzzlePanel.SetActive(true);
        Invoke("DeactivateObject", TPDuration);
    }

    private void DeactivateObject()
    {
        tilePuzzlePanel.SetActive(false);
        isActivated = false;
    }

    public void TileSteppedOn(GameObject tile)
    {
        int index = tiles.IndexOf(tile);

        if (index != -1 && index < originalMaterials.Count)
        {
            var renderer = tile.GetComponent<Renderer>();
            if (renderer != null)
            {
                renderer.material = steppedMaterial;
            }
        }
    }

    private void ResetTilesToOriginalMaterial()
    {
        for (int i = 0; i < tiles.Count; i++)
        {
            var tile = tiles[i];
            var renderer = tile.GetComponent<Renderer>();
            var lightUpStep = tile.GetComponent<LightUpStep>();
            if (renderer != null)
            {
                Debug.Log("Resetting material for tile " + i);
                renderer.material = originalMaterials[i];
            }
            if (lightUpStep != null)
            {
                lightUpStep.hasSteppedOnce = false;
            }
        }
    }

}
