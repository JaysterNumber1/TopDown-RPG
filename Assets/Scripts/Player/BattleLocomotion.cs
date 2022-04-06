using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleLocomotion : MonoBehaviour
{

    private CharacterController controller;

    public Transform groundChecker;
    [SerializeField]
    private float gravity = -9.8f;
    [SerializeField]
    private float groundOffset = .1f;
    [SerializeField]
    private LayerMask ground;


    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();

    }

    // Update is called once per frame
    void Update()
    {

        HandleGravity(Time.deltaTime);
        
    }

    private void HandleGravity(float delta)
    {
        RaycastHit hit;

        if (
            !(Physics.Raycast(groundChecker.position, transform.TransformDirection(Vector3.down), out hit, Mathf.Abs(groundOffset), ground)))

        {

            Vector3 movement = new Vector3(0, gravity, 0);

            Vector3 move = (movement  * delta);


            controller.Move(move);

        }



    }
}
