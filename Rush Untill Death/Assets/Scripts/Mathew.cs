using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(CharacterController))]

public class Mathew : MonoBehaviour
{
    CharacterController characterController;
    private Vector3 direction;
    private float speed;
    public float jumpForce = 5;
    private float gravity = -20;
    public Transform groundCheck;
    public LayerMask groundLayer;
    public Animator anim;
 


    public Camera playerCamera;
    public float lookSpeed = 2.0f;
    float rotationX = 0;

    [HideInInspector]
    public bool canMove = true;

    void Start()
    {
        characterController = GetComponent<CharacterController>();

        // Lock cursor
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        bool isGrounded = Physics.CheckSphere(groundCheck.position, 0.15f, groundLayer);
        float hInput = Input.GetAxis("Horizontal");
        float vInput = Input.GetAxis("Vertical");


        anim.SetFloat("hSpeed", Mathf.Abs(hInput));

        anim.SetFloat("Speed", Mathf.Abs(vInput));
       
        anim.SetBool("isGrounded", isGrounded);
        direction.x = hInput * speed;
        direction.z = vInput * speed;
        direction.y += gravity * Time.deltaTime;
        direction = transform.TransformDirection(direction);
        if (Input.GetKey(KeyCode.D))
        {
            anim.SetBool("RWalk", true);
        }
        else
        {
            anim.SetBool("RWalk", false);
        }
        
        if(Input.GetKey(KeyCode.S))
        {
            anim.SetBool("BackRun", true);
        }
        else
        {
            anim.SetBool("BackRun", false);
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = 6f;
            anim.SetBool("Run", true);
        }
        else
        {
            speed = 3f;
            anim.SetBool("Run", false);
           
        }


        if (isGrounded)
        {
            if (Input.GetButtonDown("Jump"))
            {
                direction.y = jumpForce;
                anim.SetBool("Run", false);
            }
        }

        characterController.Move(direction * Time.deltaTime);

        // Player and Camera rotation
        if (canMove)
        {
            rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
            rotationX = Mathf.Clamp(rotationX, -60, 30);
            playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
            transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);
        }
    }
}