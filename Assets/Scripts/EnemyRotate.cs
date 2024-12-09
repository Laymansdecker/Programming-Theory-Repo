using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRotate : EnemyController  //INHERITANCE
{
    private float radius = 0.1f;              //the radius of the circle which the enemy moves
    private float angle = 0f;               //the current angle of the object
    private float rotationSpeed = 1f;       //the speed the enemy rotates at
    private float x;                        //the enemy's x coordinate
    private float y;                        //the enemy's y coordinate
    private float z;                        //the enemy's z coordinate

    private void Awake()
    {
        speed = 2f; //updates the movement speed so it can rotate at least once in the play area
    }

    public override void MoveDown() //POLYMORPHISM //move the enemy downward while rotating
    {
        x = transform.position.x + Mathf.Cos(angle) * radius;                           //rotates the object along the x-axis
        y = transform.position.y;                                                       //keeps the y position constant
        z = transform.position.z + Mathf.Sin(angle) * radius - speed * Time.deltaTime;  //rotates the object along the z-axis while moving it down the screen
        transform.position = new Vector3(x, y, z);                                      //updates the enemy's position
        angle += rotationSpeed * Time.deltaTime;                                        //updates the angle so the object rotates
    }

}
