using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MoveObjects : InteractableObject
{
    [SerializeField] private float xMovement, yMovement, zMovement, duration = 3.0f;
    private Vector3 initPos, startPosition, endPosition; // Ending position
    float elapsedTime = 0.0f; // Time elapsed since the start of the movement

    private void Start() {
        startPosition = transform.position;
        endPosition = startPosition + new Vector3(xMovement, yMovement, zMovement);
    }
    void Update()
    {
        if (elapsedTime < duration) {
            float t = elapsedTime / duration; // Calculate the interpolation factor
            transform.position = Vector3.Lerp(startPosition, endPosition, t); // Interpolate position
            elapsedTime += Time.deltaTime; // Update elapsed time
        } else {
            elapsedTime = 0;
            initPos = startPosition;
            startPosition = endPosition;
            endPosition = initPos;
        }
    }

    override
    public void Interaction(){
        gameObject.SetActive(true);
    }


}
