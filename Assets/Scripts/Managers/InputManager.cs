using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{

//Dis is teh singleton, its very cool, like Chris Pratt
//hes so cool
//all a lamda does is pass a method as an argument that doesn't have a name
    public static InputManager instance;

    private Controls controls;

    public Vector2 move;
    public float moveAmount;

    public Vector2 look;


    void Awake(){
        if(instance != null){
            Destroy(this);
        } else{
            instance = this;
        }


        controls = new Controls();
        controls.Enable();
    }

    void OnDisable()
    {
        controls.Disable();
    }

    
    
    // Start is called before the first frame update
    void Start()
    {
        controls.Locomotion.Move.performed += /* arguments */ controls =>
        {
            move = controls.ReadValue<Vector2>();/*  statment if code is one line, else,  */
            moveAmount = Mathf.Clamp01(Mathf.Abs(move.x)) + (Mathf.Abs(move.y));

        };

        controls.Locomotion.Look.performed += controls => look = controls.ReadValue<Vector2>();

        
        // args(or underscore) => 
    }

    /* Update is called once per frame
    void Update()
    {
        
    }
    */

}
