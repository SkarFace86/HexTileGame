using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    public GameObject character;
    Rigidbody2D rb;
    public float moveSpeed = 3.0f;
    Touch touch;
    Vector3 touchPosition, whereToMove;
    bool isMoving = false;
    CameraRig cameraController;

    float previousDistanceToTouchPos, currentDistanceToTouchPos;

    private void Start()
    {
        cameraController = Camera.main.GetComponentInParent<CameraRig>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isMoving)
            currentDistanceToTouchPos = (touchPosition - transform.position).magnitude;

        // If only one touch input is being triggered
        if(Input.touchCount == 1)
        {
            // Get the touch input information
            touch = Input.GetTouch(0);

            // When the player has released their touch
            if(touch.phase == TouchPhase.Ended)
            {
                previousDistanceToTouchPos = 0;
                currentDistanceToTouchPos = 0;
                isMoving = true;
                touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
                touchPosition.z = 0f;
                whereToMove = (touchPosition - transform.position).normalized;
                rb.velocity = new Vector2(whereToMove.x * moveSpeed, whereToMove.y * moveSpeed);
            }
        }

        if(currentDistanceToTouchPos > previousDistanceToTouchPos)
        {
            isMoving = false;
            rb.velocity = Vector2.zero;
        }

        if (isMoving)
            previousDistanceToTouchPos = (touchPosition - transform.position).magnitude;
    }
}
