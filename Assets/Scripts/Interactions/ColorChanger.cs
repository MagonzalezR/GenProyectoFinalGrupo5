using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    [SerializeField] private Color baseColor, toggledColor;
    public Light controlledLight;
    public float intensity = 1f;

    void Start()
    {
        baseColor = controlledLight.color;
    }

    public void changeColor()
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
