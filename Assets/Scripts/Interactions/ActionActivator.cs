using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionActivator : MonoBehaviour
{
    [SerializeField] private int puzzleIndex;
    [SerializeField] private GameObject ActiveObj;
    [SerializeField] private bool isSequencePuzzle;

    public void ActivateObj()
    {

        ActivationPuzzleController.instance.PuzzleInteract(ActiveObj);
        if (isSequencePuzzle)
        {
            ActivationPuzzleController.instance.AddToPlayerSequence(puzzleIndex);
        }

    }
}
