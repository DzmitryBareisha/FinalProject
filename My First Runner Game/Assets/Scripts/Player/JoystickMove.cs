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
    public bool turn = false;

    void Start()
    {
        cc = GetComponent<CharacterController>();
        StartCoroutine(AddingSpeed());
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
                    Debug.Log(myjoystick.Horizontal);
                    MoveSide();
                    
                    if (myjoystick.Horizontal < 0)
                    {
                        animModel.GetComponent<Animator>().SetBool("Left", true);
                        animModel.GetComponent<Animator>().SetBool("Right", false);
                        turn = true;
                    }
                    if (myjoystick.Horizontal > 0)
                    {                        
                        animModel.GetComponent<Animator>().SetBool("Right", true);
                        animModel.GetComponent<Animator>().SetBool("Left", false);
                        turn = true;
                    }    
                }                
                else
                {
                    turn = false;
                    animModel.GetComponent<Animator>().SetBool("Right", false);
                    animModel.GetComponent<Animator>().SetBool("Left", false);
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
        if (cc.isGrounded && !turn)
        {
            animModel.GetComponent<Animator>().SetTrigger("Jump");
            jumpSpeed = jumpForce;
            Vector3 dir = new Vector3(0, jumpSpeed * Time.deltaTime, 0);
            cc.Move(dir);
        }            
    }
    IEnumerator AddingSpeed()
    {
        yield return new WaitForSeconds(10);
        moveSpeed += 1;
        StartCoroutine(AddingSpeed());
    }
}
