using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float horizontalInput;  //gets the input from the players left and right keys
    private float verticalInput;    //gets the input from the players forward and back keys
    private Rigidbody playerRb;     //sets the rigidbody of the player
    private float speed = 500f;
    private float _movementLimit = 9f; 
    public float MovementLimit
    {
        get { return _movementLimit; }
    }

    
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();   //sets the rigidbody of the object to playerRb
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");  //detects when player presses left or right key and sets float between -1 and 1 
        verticalInput = Input.GetAxis("Vertical");      //detects when player presses forward or backward key and sets float between -1 and 1 
    }

    private void FixedUpdate()
    {
        Movement();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
            DataManager.Instance.GameOver();
        }
    }

    void Movement() //ABSTRACTION //controls player movement input and constraints
    {
      
        playerRb.AddRelativeForce(Vector3.forward * speed * verticalInput, ForceMode.Force); //applies a force to move the player forward and backward
        playerRb.AddRelativeForce(Vector3.right * speed * horizontalInput, ForceMode.Force);  //applied a force to move the player left and right

        if (playerRb.transform.position.x > MovementLimit)  //right movement constraint. If player hits the movementLimit, set x position to limit and kill horizonal velocity
        {
            playerRb.position = new Vector3(MovementLimit, playerRb.transform.position.y, playerRb.transform.position.z);
            playerRb.velocity = new Vector3(0, playerRb.velocity.y, playerRb.velocity.z);
        }
        if (playerRb.transform.position.x < -MovementLimit) //left movement constraint. If player hits the movementLimit, set x position to limit and kill horizonal velocity
        {
            playerRb.position = new Vector3(-MovementLimit, playerRb.transform.position.y, playerRb.transform.position.z);
            playerRb.velocity = new Vector3(0, playerRb.velocity.y, playerRb.velocity.z);
        }
        if (playerRb.transform.position.z > MovementLimit)  //forward movement constraint. If player hits the movementLimit, set z position to limit and kill vertical velocity
        {
            playerRb.position = new Vector3(playerRb.transform.position.x, playerRb.transform.position.y, MovementLimit);
            playerRb.velocity = new Vector3(playerRb.velocity.x, playerRb.velocity.y, 0);
        }
        if (playerRb.transform.position.z < -MovementLimit)  //backward movement constraint. If player hits the movementLimit, set z position to limit and kill vertical velocity
        {
            playerRb.position = new Vector3(playerRb.transform.position.x, playerRb.transform.position.y, -MovementLimit);
            playerRb.velocity = new Vector3(playerRb.velocity.x, playerRb.velocity.y, 0);
        }
    }




}
