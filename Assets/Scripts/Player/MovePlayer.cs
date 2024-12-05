using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class MovePlayer : MonoBehaviour
{
    [SerializeField] Vector3 gravity;
    [SerializeField] float movX;
    [SerializeField]private Vector3 movement;
    public float speed;
    [Range(1, 5)]
    public GameObject timerRef;
    public int jumpForce;
    private CharacterController controller;
    private float gravityScale = -9.8f;
    public bool end = false;
    // private Animator playerAnim;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        // playerAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        CallInputs();


        MovementPlayer();
        if (Input.GetButtonDown("Jump") && OnFloor())
        {
            JumpPlayer();
        }
        // if (movX!=0)
        // {
        //     playerAnim.SetBool("isWalking",true);
        // }
        // else{
        //     playerAnim.SetBool("isWalking", false);
        // }

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

        movement = transform.right * movX;
        controller.SimpleMove(movement * speed);
    }

    private void CallInputs()
    {
        movX = Input.GetAxis("Horizontal");
    }

    public bool OnFloor()
    {
        return controller.isGrounded;
    }
}
