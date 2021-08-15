using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Animator playerAnimation;
    private CharacterController controller;
    private Vector3 direction;

    public Transform Camera;
    public Transform GroundChecker;

    public LayerMask GroundMask;

    public float rotationSmooth = 10;
    public float speed = 5;
    public float jumpForce = 100;

    float turnSmoothVelocity;
    float gravity = -9.8f;

    Vector3 velocity;

    public bool isGrounded = false;
    void Start()
    {
        playerAnimation = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();        
    }


    void Update()
    {
        Move();
        jump();
    }
    private void Move()
    {
        
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        direction = new Vector3(x, 0, z).normalized;
        playerAnimation.SetFloat("vertical", Mathf.Abs(z));
        if (direction.magnitude > 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + Camera.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, rotationSmooth);
            transform.rotation = Quaternion.Euler(0, angle, 0);
        }

        
        if (Input.GetButton("Fire3")&& Input.GetKey(KeyCode.W))
        {
            playerAnimation.SetBool("run", true);
        }
        else if(Input.GetButtonUp("Fire3") || z<=0.1f)
        {
            playerAnimation.SetBool("run", false);
        }
    }

    void jump()
    {
        isGrounded = Physics.CheckSphere(GroundChecker.position, 0.2f, GroundMask);

        if (isGrounded && velocity.y <0)
        {
            velocity.y = -2f;
        }


        if (Input.GetButtonDown("Jump") && playerAnimation.GetFloat("vertical") <= 0.1f)
        {
            playerAnimation.SetTrigger("jump");
            velocity.y = Mathf.Sqrt(jumpForce * -2 * gravity);
        }
        if (Input.GetButtonDown("Jump") && playerAnimation.GetFloat("vertical") >= 0.1f)
        {
            playerAnimation.SetTrigger("vault");
            velocity.y = Mathf.Sqrt(jumpForce * -2 * gravity);
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}
