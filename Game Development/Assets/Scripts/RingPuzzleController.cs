using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;
using Random = UnityEngine.Random;

public class RingPuzzleController : MonoBehaviour
{
    [SerializeField] private RawImage[] rings;  // Array of the ring objects (UI Raw Images).
    [SerializeField] private RectTransform canvasRectTransform; // Assign in inspector
    [SerializeField] private GameObject chest;  // Reference to your chest game object. Assign this in the inspector.

    public bool PuzzleSolved { get { return puzzleSolved; } }
    public event Action OnPuzzleSolved;
    private bool puzzleSolved = false;  // Flag to check if puzzle is solved.
    public float rotationAngle = 30f;  // Angle to rotate the rings with each click.
    public float initialRotationRange = 90f;  // Range for initial random rotations.

    private Vector2 centerOfRingsLocalPosition = Vector2.zero; // Assuming center is at the center of the canvas
    private Quaternion[] solvedRotations;  // Store the solved rotations of the rings.
    private Dictionary<RawImage, float> initialRotations = new Dictionary<RawImage, float>();

    void Start()
    {
        // Store the solved rotations of the rings.
        solvedRotations = new Quaternion[rings.Length];
        for (int i = 0; i < rings.Length; i++)
        {
            solvedRotations[i] = rings[i].rectTransform.localRotation;
        }

        RandomlyRotateRings();
    }

    private void RandomlyRotateRings()
    {
        for (int i = 0; i < rings.Length; i++)
        {
            int randomSegments = Random.Range(0, 12); // Get a random number between 0 and 11
            float randomRotation = randomSegments * 30f; // Convert that to degrees
            rings[i].rectTransform.Rotate(Vector3.forward * randomRotation);
        }
    }

    void Update()
    {
        if (!puzzleSolved)  // Only check for interactions if the puzzle isn't solved yet.
        {
            // Check for player interaction to rotate the rings when clicked.
            if (Input.GetMouseButtonDown(0))  // Left mouse button click.
            {
                HandleRingRotation();
                CheckPuzzleCompletion();
            }
        }
    }

    void HandleRingRotation()
    {
        Vector2 mousePosition = Input.mousePosition;

        // Convert mouse screen position to local position within the canvas
        RectTransformUtility.ScreenPointToLocalPointInRectangle(canvasRectTransform, mousePosition, null, out Vector2 localPoint);

        // Calculate the distance of the click from the center of the ring puzzle
        float clickDistanceFromCenter = Vector2.Distance(localPoint, centerOfRingsLocalPosition);

        for (int i = 0; i < rings.Length; i++)
        {
            // Get inner and outer radii for the current ring
            float innerRadius = GetInnerRadius(i);
            float outerRadius = GetOuterRadius(i);

            // If the click distance is within the current ring's bounds, rotate it
            if (clickDistanceFromCenter > innerRadius && clickDistanceFromCenter < outerRadius)
            {
                rings[i].rectTransform.Rotate(Vector3.forward * rotationAngle);
            }
        }
    }

    void CheckPuzzleCompletion()
    {
        // Check if all rings are back to their solved rotations.
        bool allRingsAligned = true;
        for (int i = 0; i < rings.Length; i++)
        {
            if (Quaternion.Angle(rings[i].rectTransform.localRotation, solvedRotations[i]) > 1f)
            {
                allRingsAligned = false;
                break;
            }
        }
        
        if (allRingsAligned)
        {
            Debug.Log("Puzzle Solved!");
            puzzleSolved = true;  // Set the flag to true so interactions are no longer checked.
            OnPuzzleSolved?.Invoke();  // Trigger the event.
            chest.SetActive(true);  // Activate the chest game object.
        }
    }

    private float GetInnerRadius(int ringIndex)
    {
        // Inner radii for each ring, based on the widths you provided
        float[] innerRadii = { 75f, 110f, 145f, 180f, 215f };
        return innerRadii[ringIndex];
    }

    private float GetOuterRadius(int ringIndex)
    {
        // Outer radii for each ring, based on the widths you provided
        float[] outerRadii = { 110f, 145f, 180f, 215f, 250f };  // Adjusted to separate the outermost part
        return outerRadii[ringIndex];
    }

}