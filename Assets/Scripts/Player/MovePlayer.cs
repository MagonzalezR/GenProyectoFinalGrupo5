using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class MovePlayer : MonoBehaviour
{
    private CharacterController controller;
    [SerializeField] Vector3 gravity;
    [SerializeField] float movX;
    private Vector3 movement;
    public float speed, gravityScale = -9.8f;
    public int jumpForce;
    private bool groundedPlayer;

    // Start is called before the first frame update
    void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        groundedPlayer = controller.isGrounded;

        gravity = new Vector3(Input.GetAxis("Horizontal") * speed, gravity.y, 0);
        if (groundedPlayer && gravity.y < 0)
        {
            gravity.y = 0f;
        }

        // controller.Move(movement * Time.deltaTime * speed);

        // Makes the player jump
        if (Input.GetButtonDown("Jump") && groundedPlayer)
        {  
            gravity.y += Mathf.Sqrt(jumpForce * -2.0f * gravityScale);
        }
        gravity.y += gravityScale * Time.deltaTime;
        controller.Move(gravity * Time.deltaTime);
    }

    IEnumerator DisableSpeedForTime(float time)
    {
        float tempSpeed = speed;
        Debug.Log(tempSpeed);
        speed = 0;
        yield return new WaitForSeconds(time);
        speed = tempSpeed;
    }
}
