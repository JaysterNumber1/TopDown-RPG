﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLocomotion : MonoBehaviour
{
    // A reference to the singleton
    private InputManager input;

    // A reference to the CharacterController to move the player
    private CharacterController controller;

    // A reference to AnimatorHandler to animate player
    private AnimatorHandler animatorHandler;

    private RandomEncounters randomEncounters;

    // References to the camera rig
    public Transform camParent;
    public Transform cam;
    //public Transform camPivot;
    public Transform player;
    public Transform groundChecker;
    //public bool Raycast() groundChecker;
    public LayerMask ground;
    public LayerMask randoEnc;

    public float movementModifier = 10f;
    public float rotationSpeed = 10f;

    private Vector3 lastPos;

    [SerializeField]
    private Vector3 playerSpeed;
    public float stepCounter;
    public bool isMoving;
    [SerializeField]
    private float gravity = -9.8f;
    [SerializeField]
    private float groundOffset = .1f;
    [SerializeField]
    private float randoOffset = 1f;





    // Start is called before the first frame update
    void Start()
    {
        
        input = InputManager.instance;

        controller = GetComponent<CharacterController>();

        animatorHandler = GetComponent<AnimatorHandler>();

        animatorHandler.Initialize();



        randomEncounters = GetComponent<RandomEncounters>();

        


    }

    // Update is called once per frame
    void Update()
    {
        
        HandleMovement(Time.deltaTime);

        if (animatorHandler.canRotate)
        {
            HandleRotation(Time.deltaTime);
        }

        animatorHandler.UpdateAnimatorValues(input.moveAmount, 0);


    }
    /// <summary>
    /// Make the player move relative to the cam direction.
    /// </summary>
    /// <param name="delta"></param>
    private void HandleMovement(float delta)
    {

        lastPos = player.position;

        Vector3 movement = (input.move.x * camParent.right) + (input.move.y * camParent.forward);

        RaycastHit hit;

        if ((Physics.Raycast(groundChecker.position, transform.TransformDirection(Vector3.down), out hit, Mathf.Abs(randoOffset), randoEnc)))
        /*Physics.Raycast(groundChecker.position, transform.TransformDirection(Vector3.down), out hit, Mathf.Abs(groundOffset), randoEnc))*/
        {
            if (randomEncounters.HandleEncounters(delta))
            {
                
                Debug.Log("Encounter Occurs");
            }
            
        }


        if (
            !(Physics.Raycast(groundChecker.position, transform.TransformDirection(Vector3.down), out hit, Mathf.Abs(groundOffset), ground)))

        {

            /*if (lastPos.y+(gravity*delta) != player.position.y)
            {
                movement = new Vector3(movement.x, gravity, movement.y);
            }
            else
            {
            movement = new Vector3(movement.x, 0, movement.z);
            }

            */
            movement = new Vector3(movement.x, gravity, movement.z);
        
        }

    
       
            
      


        Vector3 move =( movement * movementModifier * delta);


        controller.Move(move);


        playerSpeed = move/delta;

        if ((move.x>0||move.x<0)||(move.z>0||move.z<0) &&lastPos!=player.position)
        {
            stepCounter+= movementModifier*delta;
            isMoving = true;
        }
        else
        {
            isMoving = false;
        }

    }

    private void HandleRotation(float delta)
    {

        // the direction we want to turn towards
        Vector3 targetDir;

        // make the direction relative to camera
        targetDir = cam.forward * input.move.y;

        targetDir += cam.right * input.move.x;

        // normalize the vector so no over-rotation
        targetDir.Normalize();

        // no y rotation, up bad.
        targetDir.y = 0;

        // no camera movement, use default
        if(targetDir == Vector3.zero)
        {
            targetDir = transform.forward;
        }

        // calculate the quaternion 
        Quaternion targetRot = Quaternion.LookRotation(targetDir);


        transform.rotation = Quaternion.Slerp(transform.rotation, targetRot, rotationSpeed);

    }


}
