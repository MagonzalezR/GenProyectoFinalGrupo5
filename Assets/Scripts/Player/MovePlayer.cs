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
    private Vector3 movement;
    private float gravityScale = -9.8f;

    [Header("Camera Variables")]
    [SerializeField]public float rotationSpeed, cameraRotationX, cameraRotationY;
   [SerializeField] public float xRotation, yRotation;

    public bool end = false;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        CallInputs();
        RotatePlayer();

        MovementPlayer();
        if (Input.GetButtonDown("Jump") && OnFloor())
        {
            JumpPlayer();
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

        movement = transform.right * movX + transform.forward * movZ;
        controller.SimpleMove(movement * speed);
    }

    private void CallInputs()
    {
        cameraRotationX = Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime;
        cameraRotationY = Input.GetAxis("Mouse Y") * rotationSpeed * Time.deltaTime;
        movX = Input.GetAxis("Horizontal");
        movZ = Input.GetAxis("Vertical");
        xRotation -= cameraRotationY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        yRotation += cameraRotationX;
    }

    void RotatePlayer()
    {
        // Aplicar la rotación al Player
        transform.localRotation = Quaternion.Euler(0, yRotation, 0f);

    }

    public bool OnFloor()
    {
        return controller.isGrounded;
    }
}
