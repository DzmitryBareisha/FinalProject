using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private CharacterController cc;
    public GameObject animModel;
    public float moveSpeed = 5;
    public float leftRightSpeed = 4;
    public static bool canMove = false;
    public float jumpSpeed;
    public float jumpForce;
    public float gravity;
        
    void Start()
    {
        cc = GetComponent<CharacterController>();        
    }
    void Update()
    {
        if (cc.isGrounded)
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
                    animModel.GetComponent<Animator>().SetTrigger("Jump");
                    Jump();                    
                }
                else
                {
                    animModel.GetComponent<Animator>().SetTrigger("Run");
                }
            }            
        }
        else
        {
            jumpSpeed += gravity * Time.deltaTime * 3f;
            Vector3 dir = new Vector3(0, jumpSpeed * Time.deltaTime, moveSpeed * Time.deltaTime);
            cc.Move(dir);
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
            transform.Translate(Vector3.right * leftRightSpeed * Time.deltaTime);
        }
    }
    void Jump()
    {        
        jumpSpeed = jumpForce;
        Vector3 dir = new Vector3(0, jumpSpeed * Time.deltaTime, 0);
        cc.Move(dir);
    }    
}
