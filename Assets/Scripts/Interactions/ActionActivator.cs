using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionActivator : MonoBehaviour
{
    [SerializeField] private int puzzleIndex;
    [SerializeField] private GameObject ActiveObj;

    public void ActivateObj()
    {
        ActivationPuzzleController.instance.AddToPlayerSequence(puzzleIndex);
        ActivationPuzzleController.instance.toggleColor(ActiveObj);

    }
}
