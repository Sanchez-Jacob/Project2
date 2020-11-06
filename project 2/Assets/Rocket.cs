using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour{
    Rigidbody rigidBody;
    // Start is called before the first frame update
    void Start(){
        rigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update(){
        ProcessInput();
        
    }

    private void ProcessInput(){
        //GetKey applies all the same time and will report the status of the named key
        if (Input.GetKey(KeyCode.Space)){
            print("space pressed");
            rigidBody.AddRelativeForce(Vector3.up);
        }
        //rotates to the left
        if(Input.GetKey(KeyCode.A)){
            print("turning left");
            rigidBody.AddRelativeForce(Vector3.left);
            
        }
        //rotates to the right
        else if(Input.GetKey(KeyCode.D)){
            print("turning right");
            rigidBody.AddRelativeForce(Vector3.right);
        }
        
            
             

    }
}
