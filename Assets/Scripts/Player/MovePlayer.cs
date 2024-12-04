using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class MovePlayer : MonoBehaviour
{
    [SerializeField] Vector3 gravity;
    [SerializeField] float movX, movZ;
    public float speed;
    [Range(1, 5)]
    public GameObject timerRef;
    public int jumpForce;
    private CharacterController controller;
    [SerializeField]private Vector3 movement;
    private float gravityScale = -9.8f;
    private bool isMovingH, isMovingV;

    [Header("Camera Variables")]
    [SerializeField] public float rotationSpeed, cameraRotationX, cameraRotationY;
    [SerializeField] public float xRotation, yRotation;

    public bool end = false;

    private Animator playerAnim;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        playerAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        CallInputs();


        MovementPlayer();
        if (Input.GetButtonDown("Jump") && OnFloor())
        {
            playerAnim.SetBool("inAir",true);
            playerAnim.SetBool("inAir",false);
            JumpPlayer();
        }
        if (isMovingH || isMovingV)
        {
            playerAnim.SetBool("isWalking",true);
            RotatePlayer();
        }
        else{
            playerAnim.SetBool("isWalking", false);
        }

        if (!controller.isGrounded)
        {
            ApplyGravity();
        }
        else
        {
            gravity.y = -2;
        }
    }
    private void JumpPlayer()
    {
        gravity.y = Mathf.Sqrt(gravityScale * -2 * jumpForce);
        controller.Move(gravity * Time.deltaTime);
    }

    private void ApplyGravity()
    {
        gravity.y += gravityScale * Time.deltaTime;
        controller.Move(gravity * Time.deltaTime);

    }

    private void MovementPlayer()
    {

        movement = transform.forward * Mathf.Abs(movX) + transform.forward * Mathf.Abs(movZ);
        // movement = transform.right * movX + transform.forward * movZ;
        controller.SimpleMove(movement * speed);
    }

    private void CallInputs()
    {
        cameraRotationX = Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime;
        cameraRotationY = Input.GetAxis("Mouse Y") * rotationSpeed * Time.deltaTime;
        movX = Input.GetAxis("Horizontal");
        movZ = Input.GetAxis("Vertical");
        isMovingH = Input.GetButton("Horizontal");
        isMovingV = Input.GetButton("Vertical");
        xRotation -= cameraRotationY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        yRotation += cameraRotationX;
    }

    void RotatePlayer()
    {
        // Aplicar la rotación al Player
        transform.localRotation = Quaternion.FromToRotation(Vector3.forward +Vector3.right, Vector3.right*movX + (Vector3.forward*movZ));
        // transform.localRotation = Quaternion.Euler(0,transform.localRotation.y, 0);
    }

    public bool OnFloor()
    {
        return controller.isGrounded;
    }
}
