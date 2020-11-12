using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour{
    [SerializeField]float rcsThrust = 100f;
    [SerializeField]float mainThrust = 100f;
    Rigidbody rigidBody;
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start(){
        rigidBody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update(){
        Rotate();

        //GetKey applies all the same time and will report the status of the named key
        if (Input.GetKey(KeyCode.Space)){
            Thrust();
        //adding forcein the direction the ship is facing
        }
        else{
            audioSource.Stop();
        }
        
    }

    private void Rotate(){
        float rotationThisFrame = rcsThrust * Time.deltaTime;

        //freeze rotation before we take maual control of rotation
        rigidBody.freezeRotation = true;
         //rotates to the left
        if(Input.GetKey(KeyCode.A)){
            //rotating left about the z-axis
            transform.Rotate(Vector3.forward * rotationThisFrame);
            rigidBody.AddRelativeForce(Vector3.left);
            
        }
        //rotates to the right
        else if(Input.GetKey(KeyCode.D)){
            //rotate right about the z axis
            transform.Rotate(-Vector3.forward * rotationThisFrame);
            rigidBody.AddRelativeForce(Vector3.right);
        }
        //resume physics control
        rigidBody.freezeRotation = false;
    }

    private void Thrust(){
        rigidBody.AddRelativeForce(Vector3.up * mainThrust *Time.deltaTime);
        //so audio doesnt layer
        if(!audioSource.isPlaying){
            audioSource.Play();
        }
    }
}
