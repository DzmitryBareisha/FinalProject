using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickMove : MonoBehaviour
{
    [SerializeField] private FixedJoystick myjoystick;
    [SerializeField] private FixedJoystick jumpstick;
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
                if (myjoystick.Horizontal != 0)
                {
                    MoveSide();
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
    void MoveSide()
    {        
        Vector3 dir = new Vector3(leftRightSpeed * myjoystick.Horizontal * Time.deltaTime, 0, moveSpeed * Time.deltaTime);
        cc.Move(dir);       
    }

    public void Jump()
    {
        if (cc.isGrounded)
        {
            animModel.GetComponent<Animator>().SetTrigger("Jump");
            jumpSpeed = jumpForce;
            Vector3 dir = new Vector3(0, jumpSpeed * Time.deltaTime, 0);
            cc.Move(dir);
        }            
    }
}
