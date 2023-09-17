using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;
using Random = UnityEngine.Random;

public class RingPuzzleController : MonoBehaviour
{
    [SerializeField] private RawImage[] rings;
    [SerializeField] private RectTransform canvasRectTransform;
    [SerializeField] private GameObject chest;
    
    public bool PuzzleSolved { get { return puzzleSolved; } }
    public event Action OnPuzzleSolved;
    private bool puzzleSolved = false;
    public float rotationAngle = 30f;
    public float initialRotationRange = 90f;

    private Vector2 centerOfRingsLocalPosition = Vector2.zero;
    private Quaternion[] solvedRotations;
    private Dictionary<RawImage, float> initialRotations = new Dictionary<RawImage, float>();

    void Start()
    {

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
            int randomSegments = Random.Range(0, 12);
            float randomRotation = randomSegments * 30f;
            rings[i].rectTransform.Rotate(Vector3.forward * randomRotation);
        }
    }

    void Update()
    {
        if (!puzzleSolved)
        {
            if (Input.GetMouseButtonDown(0))
            {
                HandleRingRotation();
                CheckPuzzleCompletion();
            }
        }
    }

    void HandleRingRotation()
    {
        Vector2 mousePosition = Input.mousePosition;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(canvasRectTransform, mousePosition, null, out Vector2 localPoint);
        float clickDistanceFromCenter = Vector2.Distance(localPoint, centerOfRingsLocalPosition);

        for (int i = 0; i < rings.Length; i++)
        {
            float innerRadius = GetInnerRadius(i);
            float outerRadius = GetOuterRadius(i);
            if (clickDistanceFromCenter > innerRadius && clickDistanceFromCenter < outerRadius)
            {
                rings[i].rectTransform.Rotate(Vector3.forward * rotationAngle);
            }
        }
    }

    void CheckPuzzleCompletion()
    {
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
            puzzleSolved = true;
            OnPuzzleSolved?.Invoke();
            chest.SetActive(true);
        }
    }

    private float GetInnerRadius(int ringIndex)
    {
        float[] innerRadii = { 75f, 110f, 145f, 180f, 215f };
        return innerRadii[ringIndex];
    }

    private float GetOuterRadius(int ringIndex)
    {
        float[] outerRadii = { 110f, 145f, 180f, 215f, 250f };
        return outerRadii[ringIndex];
    }
}
