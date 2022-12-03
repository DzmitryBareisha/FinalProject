using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float moveSpeed = 3;
    public float leftRightSpeed = 4;
    public static bool canMove = false;    
    public float jumpForce = 3;
    //public float gravity = -20f;       
    void Update()
    {
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime, Space.World);
        if (canMove == true)
        {
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                MoveLeft();
            }
            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                MoveRight();
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Jump();
            }
        }        
    }
    void MoveLeft()
    {
        if (gameObject.transform.position.x > LevelBoundary.leftSide)
        {
            transform.Translate(Vector3.left * leftRightSpeed * Time.deltaTime);
        }
    }
    void MoveRight()
    {
        if (gameObject.transform.position.x < LevelBoundary.rightSide)
        {
            transform.Translate(-Vector3.left * leftRightSpeed * Time.deltaTime);
        }
    }
    void Jump()
    {
        //Debug.Log("Jump");
        //transform.position += new Vector3(0, jumpForce, 0);
    }    
}
