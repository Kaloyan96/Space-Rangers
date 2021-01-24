using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour

{
    public float panSpeed = 20f;
    public float movementKeySpeed = 10f;
    public float verticalSpeed = 5f;
    public float rotSpeed = 10f;
    public float zoomSpeed = 50f;
    public float borderWidth = 10f;
    public bool edgeScrolling = true;
    public Camera cam;

    public float minHeight = 1f;
    public float maxHeight = 10f;

    private float mouseX, mouseY;
    private Vector3 forwardDirection, rightDirection, upDirection;
    private Vector3 position;
    private RaycastHit ground;
    private Vector3 groundPosition;
    private float distanceToGround;

    void Start()
    {
        cam = Camera.main;
    }


    void FixedUpdate()
    {
        Movement();
        Rotation();
        //Zoom();
    }

    void Movement()
    {
        if (isMovementInputActive())
        {
            position = transform.position;

            updateDirectionVectors();

            if (Input.GetKey("w") || edgeScrolling == true && Input.mousePosition.y >= Screen.height - borderWidth)
            {
                position += forwardDirection * movementKeySpeed * Time.deltaTime;
            }

            if (Input.GetKey("s") || edgeScrolling == true && Input.mousePosition.y <= borderWidth)
            {
                position -= forwardDirection * movementKeySpeed * Time.deltaTime;
            }

            if (Input.GetKey("d") || edgeScrolling == true && Input.mousePosition.x >= Screen.width - borderWidth)
            {
                position += rightDirection * movementKeySpeed * Time.deltaTime;
            }

            if (Input.GetKey("a") || edgeScrolling == true && Input.mousePosition.x <= borderWidth)
            {
                position -= rightDirection * movementKeySpeed * Time.deltaTime;
            }

            transform.position = position;

            calcDistanceToGround();

            if (Input.GetKey("z") && distanceToGround > minHeight + 0.01f)
            {
                position -= upDirection * verticalSpeed * Time.deltaTime;
            }
            if (Input.GetKey("x"))
            {
                position += upDirection * verticalSpeed * Time.deltaTime;
            }


            position.y = Mathf.Clamp(position.y, ground.point.y + minHeight, ground.point.y + maxHeight);

            transform.position = position;
        }
    }

    private bool isMovementInputActive()
    {
        return Input.GetKey("w") || Input.GetKey("s") || Input.GetKey("d") || Input.GetKey("a") || Input.GetKey("z") || Input.GetKey("x") ||
                (edgeScrolling == true && (Input.mousePosition.y >= Screen.height - borderWidth
                                        || Input.mousePosition.y <= borderWidth
                                        || Input.mousePosition.x >= Screen.width - borderWidth
                                        || Input.mousePosition.x <= borderWidth));
    }

    private void updateDirectionVectors()
    {
        forwardDirection = transform.forward;
        forwardDirection.y = 0;
        forwardDirection.Normalize();

        rightDirection = transform.right;
        rightDirection.y = 0;
        rightDirection.Normalize();

        upDirection = transform.up;
        upDirection.x = 0;
        upDirection.z = 0;
        upDirection.Normalize();
    }

    private void calcDistanceToGround()
    {
        Ray downRay = new Ray(transform.position, -Vector3.up);
        if (Physics.Raycast(downRay, out ground))
        {
            groundPosition = ground.point;
            distanceToGround = ground.distance;
        }
        else
        {
            groundPosition = transform.position;
            groundPosition.y = float.MinValue;
            distanceToGround = float.MaxValue;
        }
    }

    void Rotation()
    {
            //Debug.Log("123");
        if (Input.GetButton("Fire3"))
        {
            Debug.Log("123");
            // Our mouseX variable gets set to the X position of the mouse multiplied by the rotation speed added to it.

            mouseX += Input.GetAxis("Mouse X") * rotSpeed;

            // Our mouseY variable gets set to the Y position of the mouse multiplied by the rotation speed added to it.

            mouseY -= Input.GetAxis("Mouse Y") * rotSpeed;

            // Clamp the minimum and maximum angle of how far the camera can look up and down.

            mouseY = Mathf.Clamp(mouseY, 5, 90);

            // Set the rotation of the camera target along the X axis (pitch) to mouseY (up & down) & Y axis (yaw) to mouseX (left & right), the Z axis (roll) is always set to 0 as we do not want the camera to roll.

            transform.rotation = Quaternion.Euler(mouseY, mouseX, 0);

        }

    }


    // void Zoom()

    // {

    //     // Local variable to temporarily store our camera's position

    //     Vector3 camPos = cam.transform.position;

    //     // Local variable to store the distance of the camera from the camera_target

    //     float distance = Vector3.Distance(transform.position, cam.transform.position);


    //     // When we scroll our mouse wheel up, zoom in if the camera is not within the minimum distance (set by our zoomMin variable)

    //     if (Input.GetAxis("Mouse ScrollWheel") > 0f && distance > zoomMin)

    //     {

    //         camPos += cam.transform.forward * zoomSpeed * Time.deltaTime;

    //     }


    //     // When we scroll our mouse wheel down, zoom out if the camera is not outside of the maximum distance (set by our zoomMax variable)

    //     if (Input.GetAxis("Mouse ScrollWheel") < 0f && distance < zoomMax)

    //     {

    //         camPos -= cam.transform.forward * zoomSpeed * Time.deltaTime;

    //     }


    //     // Set the camera's position to the position of the temporary variable

    //     cam.transform.position = camPos;

    // }
}