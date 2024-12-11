using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorActivator : InteractableObject
{
    [SerializeField] private float xMovement, yMovement, zMovement, duration = 3.0f;
    private Vector3 initPos, startPosition, endPosition; // Ending position
    float elapsedTime; // Time elapsed since the start of the movement
    void Start()
    {
        elapsedTime = duration;
        endPosition = transform.position;
        startPosition = endPosition + new Vector3(xMovement, yMovement, zMovement);
    }

    // Update is called once per frame
    void Update()
    {
         if (elapsedTime < duration)
        {
            float t = elapsedTime / duration; // Calculate the interpolation factor
            transform.position = Vector3.Lerp(startPosition, endPosition, t); // Interpolate position
            elapsedTime += Time.deltaTime; // Update elapsed time
        }
    }

    override
    public void Interaction()
    {
        elapsedTime = 0;
        initPos = startPosition;
        startPosition = endPosition;
        endPosition = initPos;
    }
}
