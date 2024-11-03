using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    // Start is called before the first frame update

    public float runSpeed = 7f;
    public float rotationSpeed = 250f;
    public Animator animator;
    private float x, y;

    public float jumpForce = 7f;
    private Rigidbody rb;
    private bool isGrounded = true;
    private float groundCheckDistance = 0.1f;


    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        rb = GetComponent<Rigidbody>();
    }
   

    // Update is called once per frame
    void Update()
    {
        move();
        jump();
    }

    private void FixedUpdate()
    {
        transform.Translate(x * Time.deltaTime * runSpeed, 0, 0);
        transform.Translate(0, 0, y * Time.deltaTime * runSpeed);
        transform.Rotate(0, x * Time.deltaTime * rotationSpeed, 0);
    }
    private void move()
    {
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");
        animator.SetFloat("VelX", x);
        animator.SetFloat("VelY", y);
    }

    private void jump()
    {
        checkGrounded();
        animator.SetBool("onGround", isGrounded);
        animator.SetBool("onAir", !isGrounded);
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
            animator.SetBool("onGround", isGrounded);
            animator.SetBool("onAir", !isGrounded);
        }
    }

    void checkGrounded()
    {
        isGrounded = Physics.Raycast(transform.position, Vector3.down, groundCheckDistance);
    }

    //void OnCollisionEnter(Collision collision)
    //{
        
    //    if (collision.gameObject.CompareTag("Ground") && isGrounded == false) // Asegúrate de que el suelo tenga la etiqueta "Ground"
    //    {
    //        isGrounded = true;
    //    }
    //}




}
