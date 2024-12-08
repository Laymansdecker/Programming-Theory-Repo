using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyZigZag : EnemyController
{
    //private float horizontalSpeed = 10f;
    [SerializeField] private float xSpawn;
    [SerializeField] private float xPosition;
    [SerializeField] private float xtargetPosition;
    private float zigZagLimit = 2f;
    static float t = 0f;

    private void Awake()
    {
        xSpawn = transform.position.x;                           //sets the original spawn x position
        xtargetPosition = xSpawn - zigZagLimit;
    }
    public override void MoveDown()
    {
        xPosition = transform.position.x;
        speed = 10;                                                 //updates the speed of the object
        transform.Translate(Vector3.back * Time.deltaTime * speed); //moves the enemy down the screen
        if(xPosition > xtargetPosition)
        {
            transform.position = new Vector3(Mathf.Lerp(xSpawn, xtargetPosition, t), transform.position.y, transform.position.z);
            //transform.Translate(Vector3.left * Time.deltaTime * horizontalSpeed);
            t = 0.1f * Time.deltaTime;
        }

    }


}
