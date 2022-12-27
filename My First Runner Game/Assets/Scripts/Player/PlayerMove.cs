using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

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
    public bool turn = false;
        
    void Start()
    {
        cc = GetComponent<CharacterController>();
        StartCoroutine(AddingSpeed());
    }
    void Update()    
    {            
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime, Space.World);
        if (canMove == true)
        {
            if (cc.isGrounded)
            {
                if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
                {
                    animModel.GetComponent<Animator>().SetBool("Left", true);
                    MoveLeft();
                    turn = true;
                }
                else
                {
                    animModel.GetComponent<Animator>().SetBool("Left", false);
                    turn = false;
                }
                if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
                {
                    animModel.GetComponent<Animator>().SetBool("Right", true);
                    MoveRight();
                    turn = true;
                }
                else
                {
                    animModel.GetComponent<Animator>().SetBool("Right", false);                    
                }
                if (Input.GetKeyDown(KeyCode.Space) && !turn)
                {
                    animModel.GetComponent<Animator>().SetTrigger("Jump");
                    Jump();
                }
                else
                {
                    animModel.GetComponent<Animator>().SetTrigger("Run");
                }
            }           
            else
            {
                jumpSpeed += gravity * Time.deltaTime * 3f;
                Vector3 dir = new Vector3(0, jumpSpeed * Time.deltaTime, moveSpeed * Time.deltaTime);
                cc.Move(dir);
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
            transform.Translate(Vector3.right * leftRightSpeed * Time.deltaTime);
        }
    }
    void Jump()
    {        
        jumpSpeed = jumpForce;
        Vector3 dir = new Vector3(0, jumpSpeed * Time.deltaTime, 0);
        cc.Move(dir);
    }
    IEnumerator AddingSpeed()
    {
        yield return new WaitForSeconds(10);
        moveSpeed += 1;
        StartCoroutine(AddingSpeed());
    }
}
