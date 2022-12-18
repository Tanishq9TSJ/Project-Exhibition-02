using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    CharacterController characterController;
    private Vector3 direction;
    private float speed;
    public float jumpForce = 5;
    private float gravity = -20;
    public Transform groundCheck;
    public LayerMask groundLayer;
    public Camera playerCamera;
    public float lookSpeed = 2.0f;
    float rotationX = 0;
    float rotationY = 0;
    


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


       
        direction.x = hInput * speed;
        direction.z = vInput * speed;
        direction.y += gravity * Time.deltaTime;
        direction = transform.TransformDirection(direction);
       

        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = 6f;
           
        }
        else
        {
            speed = 3f;
         
        }


        if (isGrounded)
        {
            if (Input.GetButtonDown("Jump"))
            {
                direction.y = jumpForce;
               
            }
        }


        characterController.Move(direction * Time.deltaTime);

        // Player and Camera rotation
        if (canMove)
        {
            rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
      
      
            rotationX = Mathf.Clamp(rotationX, -15, 15);


            playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
           
       
            transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);

            
        }
    }
}
