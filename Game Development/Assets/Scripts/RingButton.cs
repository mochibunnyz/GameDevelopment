using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(RectTransform))]
public class RingButton : Graphic
{
    public float innerRadius = 50f; // Set this to the inner radius of your donut ring

    protected override void Awake()
    {
        base.Awake();
    }

    public override bool Raycast(Vector2 sp, Camera eventCamera)
    {
        return IsRaycastLocationValid(sp, eventCamera);
    }

    protected bool IsRaycastLocationValid(Vector2 screenPoint, Camera eventCamera)
    {
        RectTransform rectTransform = GetComponent<RectTransform>();

        Vector2 localPoint;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(rectTransform, screenPoint, eventCamera, out localPoint);

        float distFromCenter = Vector2.Distance(Vector2.zero, localPoint);

        // Check if the click is within the ring and not in the center
        if (distFromCenter > innerRadius && rectTransform.rect.Contains(localPoint))
            return true;

        return false;
    }

    // We're not doing any custom drawing, so override this method without doing anything
    protected override void OnPopulateMesh(VertexHelper vh)
    {
        vh.Clear();
    }
}
