using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChanger : InteractableObject
{
    [SerializeField] private Color baseColor, toggledColor;
    public Light controlledLight;
    public float intensity = 1f;

    void Start()
    {
        baseColor = controlledLight.color;
    }

    override
    public void Interaction()
    {
        if (toggledColor !=null){
            if(controlledLight.color == baseColor){
                controlledLight.color = toggledColor;
            } else {
                controlledLight.color = baseColor;
            }
        }
    }
}
