using UnityEngine;
using System.Collections;

public class CameraRig : MonoBehaviour
{
    public float cameraSpeed = 0.025f;
    public float zoomOutDistance = 6.0f;
    public float zoomInDistance = 2.0f;

    // Camera bounds
    public float LeftBound;
    public float RightBound;

    public float UpBound;
    public float DownBound;

    private void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved) {
            Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;
            transform.Translate(-touchDeltaPosition.x * cameraSpeed, -touchDeltaPosition.y * cameraSpeed, 0);
        }
    }
}