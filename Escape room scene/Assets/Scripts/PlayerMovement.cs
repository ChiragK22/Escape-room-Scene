using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f; 
    public float jumpForce = 10f; 
    public float gravity = -9.81f;

    public CharacterController controller;
    private Vector3 velocity; 
    private bool isGrounded; 
    public float rotateSpeed;
    private GrabableObject grabable;

    public Transform groundCheck;
    public float groundCheckDistance = 0.4f;
    public LayerMask groundMask;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);


        isGrounded = Physics.CheckSphere(groundCheck.position, groundCheckDistance, groundMask); 
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpForce * -2f * gravity);
        }

        Move();

        /*if (Input.GetKeyDown(KeyCode.G))
        {
            rotateObjects();
        }*/
    }
   /* public void rotateObjects() 
    {
        Debug.Log(grabable.objectRigidbody.tag);

    }*/
    public void Move()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 rotation = new Vector3(0f, horizontal, 0f);
        transform.Rotate(rotation * rotateSpeed * Time.deltaTime);

        Vector3 movement = transform.forward * vertical;

        controller.Move(movement * moveSpeed * Time.deltaTime);

        /*float mouse = Input.GetAxis("Mouse Y");
        float sensitivity = 0.5f;
        transform.Rotate(new Vector3(-mouse * sensitivity, 0, 0));*/

    }

}
