using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Rigidbody enemyRb;               //sets the rigidbody of the enemy
    public float speed = 5f;               //speed the enemy moves down the screen
    private float bottomBoundary = -12f;    //the bottom boundary for where objects get destroyed

    // Start is called before the first frame update
    void Awake()
    {
        enemyRb = GetComponent<Rigidbody>();    //sets the rigidbody of the object to enemyRb
    }

    private void Update()
    {
        //checks to see if the object has moved far enough left AND is an obstacle
        if (transform.position.z < bottomBoundary && gameObject.CompareTag("Enemy"))
        {
            //if the if statement conditions are met, destroy the obstacle
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        MoveDown();
    }

    public virtual void MoveDown()
    {
        transform.Translate(Vector3.back * Time.deltaTime * speed); //moves the enemy down the screen
    }
}
