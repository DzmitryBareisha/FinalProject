using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float moveSpeed = 3;
    public float leftRightSpeed = 4;
    void Update()
    {
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime, Space.World);
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            if (gameObject.transform.position.x > LevelBoundary.leftSide)
            {
                transform.Translate(Vector3.left * leftRightSpeed * Time.deltaTime);
            }            
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            if (gameObject.transform.position.x < LevelBoundary.rightSide)
            {
                transform.Translate(-Vector3.left * leftRightSpeed * Time.deltaTime);
            }            
        }
    }
}
