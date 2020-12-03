using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Rocket : MonoBehaviour{
    [SerializeField]float rcsThrust = 100f;
    [SerializeField]float mainThrust = 100f;
    Rigidbody rigidBody;
    AudioSource audioSource;

    enum State {Alive, Dying, Transcending }
    State state = State.Alive;
    

    // Start is called before the first frame update
    void Start(){
        rigidBody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update(){
        Thrust();
        Rotate();
    }

    private void Rotate(){
        float rotationThisFrame = rcsThrust * Time.deltaTime;

        //freeze rotation before we take maual control of rotation
        rigidBody.freezeRotation = true;
         //rotates to the left
        if(Input.GetKey(KeyCode.A)){
            //rotating left about the z-axis
            transform.Rotate(Vector3.forward * rotationThisFrame);
            //rigidBody.AddRelativeForce(Vector3.left);
            
        }
        //rotates to the right
        else if(Input.GetKey(KeyCode.D)){
            //rotate right about the z axis
            transform.Rotate(-Vector3.forward * rotationThisFrame);
            //rigidBody.AddRelativeForce(Vector3.right);
        }
        //resume physics control
        rigidBody.freezeRotation = false;
    }

    void OnCollisionEnter(Collision collision){
        switch(collision.gameObject.tag){
            case "Friendly":
                print("Friendly");
                break;

            case "Finish":
                state = State.Transcending;
                Invoke("LoadNextScene", 1f);
                break;
                
            
            default:
                print("Deadly");
                SceneManager.LoadScene(0);
                break;
        }
    }

    private void Thrust(){
        //GetKey applies all the same time and will report the status of the named key
        if (Input.GetKey(KeyCode.Space)){
            //adding forcein the direction the ship is facing
            rigidBody.AddRelativeForce(Vector3.up * mainThrust *Time.deltaTime);
            //so audio doesnt layer
            if(!audioSource.isPlaying){
                audioSource.Play();
            }  
        }
        else {
            audioSource.Stop();    
       
        }
    }

    private void LoadNextScene(){
        //TODO : allow for more than 2 levels
        SceneManager.LoadScene(1);
    }
}

       