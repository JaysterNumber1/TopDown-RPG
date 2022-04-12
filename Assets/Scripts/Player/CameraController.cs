using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // A reference to the InputManager singleton
    private InputManager input;

    public Transform targetTransform; // where the camera will eventually move to
    public Transform camTransform; // actual location of the camera
   // public Transform pivotTransform; // location of the camera pivot

    private Vector3 camPos; // the position data of the camera transform. Only matters for z position. 
    public LayerMask ignoreLayers; // layers to not collide with

    private Vector3 cameraFollowVelocity = Vector3.zero;

    // sensitivity and smoothness
    //public float lookSpeed = .03f;
    public float followSpeed = .1f;
   // public float pivotSpeed = .03f;

    // used for positional calculation
    public float targetPos;
    private float defaultPos;
   // private float lookAngle;
   // private float pivotAngle;

    // limit vertical tilting
    //public float minPivot = -35;
    //public float maxPivot = 35;

    // collision detection
    //public float cameraSphereRadius = .2f;
    //public float cameraCollisionOffset = .2f;
    //public float minCollisionOffset = .2f;

    private void Awake()
    {
        defaultPos = camTransform.localPosition.z;
    }

    // Start is called before the first frame update
    void Start()
    {
        input = InputManager.instance;
    }

    // Update is called once per frame
    void Update()
    {
        FollowTarget(Time.deltaTime);
       // HandleCameraRotation(Time.deltaTime);
    }

    private void FollowTarget(float delta)
    {
        // create a position somewhere between the current position and target position.
        //Vector3 targetPosition = Vector3.SmoothDamp(transform.position, targetTransform.position, ref cameraFollowVelocity, delta/ followSpeed);
        Vector3 targetPosition = targetTransform.position;

        // move the camera parent to the targetPosition
        transform.position = targetPosition;

       // HandleCameraCollision(delta);
    }
    /*
    private void HandleCameraRotation(float delta)
    {
        // Get the mouse movement stored into floats
        float mouseX = input.look.x;
        float mouseY = input.look.y;

        // calculate 'looking' AKA Y axis rotation (side to side) 
        lookAngle += (mouseX * lookSpeed) / delta;

        // calculate 'pivoting' AKA X axis rotation (up/down)
        pivotAngle -= (mouseY * pivotSpeed) / delta;

        // clamp the pivot so we can't tilt too far
        pivotAngle = Mathf.Clamp(pivotAngle, minPivot, maxPivot);


        // ******** THE FOLLOWING SECTION APPLIES TO SIDE BY SIDE ROTATION *********

        // create a vector3 to store a new rotation, and initialize it to zero
        Vector3 rotation = Vector3.zero;

        // Set the y value of our rotation vector to our lookAngle
        rotation.y = lookAngle;

        // make a Quaternion out of the euler angle of our Vector3
        Quaternion targetRotation = Quaternion.Euler(rotation);

        // apply the quaternion to the rotation of the camera parent
        transform.rotation = targetRotation;


        // ********* THE FOLLOWING SECTION APPLIES TO UP/DOWN ROTATION *********

        // set the rotation Vector3 back to zero
        rotation = Vector3.zero;

        // Set the x value of our rotation vector to our pivotAngle
        rotation.x = pivotAngle;

        // make a quaternion out of the euler angle of the Vector3
        targetRotation = Quaternion.Euler(rotation);

        // Apply the quaternion to the rotation of the camera pivot
        pivotTransform.localRotation = targetRotation;



    }
    */
   /* private void HandleCameraCollision(float delta)
    {
        // Set up a targetPos that we want the camera to move to. 
        // by default, the target z will be set to the camera's original position. 
        targetPos = defaultPos;

        // create a RaycastHit object to store collision information
        RaycastHit hit;

        // Calculate the direction we want to cast in (from the camera position to the pivot)
        Vector3 direction = camTransform.position - pivotTransform.position;
        direction.Normalize();

        // Cast a sphere from the pivot in the direction we calculated
        // the furthest we need to cast is the absolute value of the farthest position the camera could be in
        if (Physics.SphereCast(pivotTransform.position, cameraSphereRadius, direction, out hit, Mathf.Abs(targetPos), ignoreLayers))
        {

            // if we hit something, find out how far it was from the pivot to that point
            float distance = Vector3.Distance(pivotTransform.position, hit.point);

            // update the target position variable with this distance - made negative
            targetPos = -(distance - cameraCollisionOffset);

            // if our new target position is less than our minimum offset, update to the minimum collision offset. 
            // this will keep the camera from going inside the player. 
            if (Mathf.Abs(targetPos) < minCollisionOffset)
            {
                targetPos = -minCollisionOffset;
            }

        }

    
        // calculate a new position between the camera's current position and the target position
        camPos.z = Mathf.Lerp(camTransform.localPosition.z, targetPos, delta / .2f);

        // actually move the camera. 
        camTransform.localPosition = camPos;
    }
   */
}