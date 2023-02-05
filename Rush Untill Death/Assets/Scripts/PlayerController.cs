using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    CharacterController characterController;
    private Vector3 direction;
    public  float speed;
    public float jumpForce = 10;
    private float gravity = -20;
    public Transform groundCheck;
    public LayerMask groundLayer;
    private AudioSource a;


    public Camera playerCamera;
    public float lookSpeed = 2.0f;
    float rotationX = 0;

    [HideInInspector]
    public bool canMove = true;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        a = GetComponent<AudioSource>();

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
            speed = 7f;
          
        }
        else
        {
            speed = 5f;
        }


        if (isGrounded)
        {
            if (Input.GetButtonDown("Jump"))
            {
                direction.y = jumpForce;
                a.Play();
            }
            else
            {
                a.Stop();
            }
           
        }
      


        characterController.Move(direction * Time.deltaTime);

        // Player and Camera rotation
        if (canMove)
        {
            rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
            rotationX = Mathf.Clamp(rotationX, -10, 30);
            playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
            transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);
        }

    }
}
