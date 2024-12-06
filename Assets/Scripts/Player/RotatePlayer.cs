using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePlayer : MonoBehaviour
{
    float movX;
    [SerializeField]bool isMoving;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        movX = Input.GetAxis("Horizontal");
        isMoving = Input.GetButton("Horizontal");

        if(isMoving){
            Rotaion();
        }
    }

    void Rotaion()
    {
        // Aplicar la rotación al Player
        transform.localRotation = Quaternion.Euler(0, 90 * Mathf.Sign(movX), 0);
    }
}
