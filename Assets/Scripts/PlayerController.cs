using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float horizontalInput;  //gets the input from the players left and right keys
    private float verticalInput;    //gets the input from the players forward and back keys
    private Rigidbody playerRb;     //sets the rigidbody of the player
    private float speed = 0.75f;
    private float movementLimit = 9f;
    
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();   //sets the rigidbody of the object to playerRb
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    void Movement() //ABSTRACTION //controls player movement input and constraints
    {
        horizontalInput = Input.GetAxis("Horizontal");  //detects when player presses left or right key and sets float between -1 and 1 
        verticalInput = Input.GetAxis("Vertical");      //detects when player presses forward or backward key and sets float between -1 and 1 

        playerRb.AddRelativeForce(Vector3.forward * speed * verticalInput, ForceMode.Force); //applies a force to move the player forward and backward
        playerRb.AddRelativeForce(Vector3.right * speed * horizontalInput, ForceMode.Force);  //applied a force to move the player left and right

        if (playerRb.transform.position.x > movementLimit)  //right movement constraint. If player hits the movementLimit, set x position to limit and kill horizonal velocity
        {
            playerRb.position = new Vector3(movementLimit, playerRb.transform.position.y, playerRb.transform.position.z);
            playerRb.velocity = new Vector3(0, playerRb.velocity.y, playerRb.velocity.z);
        }
        if (playerRb.transform.position.x < -movementLimit) //left movement constraint. If player hits the movementLimit, set x position to limit and kill horizonal velocity
        {
            playerRb.position = new Vector3(-movementLimit, playerRb.transform.position.y, playerRb.transform.position.z);
            playerRb.velocity = new Vector3(0, playerRb.velocity.y, playerRb.velocity.z);
        }
        if (playerRb.transform.position.z > movementLimit)  //forward movement constraint. If player hits the movementLimit, set z position to limit and kill vertical velocity
        {
            playerRb.position = new Vector3(playerRb.transform.position.x, playerRb.transform.position.y, movementLimit);
            playerRb.velocity = new Vector3(playerRb.velocity.x, playerRb.velocity.y, 0);
        }
        if (playerRb.transform.position.z < -movementLimit)  //backward movement constraint. If player hits the movementLimit, set z position to limit and kill vertical velocity
        {
            playerRb.position = new Vector3(playerRb.transform.position.x, playerRb.transform.position.y, -movementLimit);
            playerRb.velocity = new Vector3(playerRb.velocity.x, playerRb.velocity.y, 0);
        }
    }
}
