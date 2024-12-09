using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyZigZag : EnemyController  //INHERITANCE
{
    [SerializeField] private float spawnPos;
    [SerializeField] private float targetPos;
    [SerializeField] private float leftPos;
    [SerializeField] private float rightPos;
    [SerializeField] private float moveLimit = 3.0f;



    private void Awake()
    {
        spawnPos = transform.position.x;    //sets the spawn z position
        leftPos = spawnPos - moveLimit;     //sets the movement to the left
        rightPos = spawnPos + moveLimit;    //sets the movement to the right
        targetPos = leftPos;                //sets the initial target for the enemy to move towards



    }
    public override void MoveDown() //POLYMORPHISM
    {
        // we begin to move the enemy towards the targetPos, which in this case is leftPos
        if (transform.position.x > targetPos && targetPos == leftPos)
        {
            transform.Translate(-speed * Time.deltaTime, 0, -speed * Time.deltaTime);
        }
        //once we hit the targetPost, we change the targetPos to the rightPos
        else if (transform.position.x <= targetPos && targetPos == leftPos)
        {
            targetPos = rightPos;
        }
        //and begin to move the enemy along the axis back towards the rightPost
        else if (transform.position.x < targetPos && targetPos == rightPos)
        {
            transform.Translate(speed * Time.deltaTime, 0, -speed * Time.deltaTime);
        }
        //Once we hit the rightPos, we reset the target position to the leftPos and repeat the loop
        else if (transform.position.x >= targetPos && targetPos == rightPos)
        {
            targetPos = leftPos;
        }
    }


}
