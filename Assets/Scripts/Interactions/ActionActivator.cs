using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class ActionActivator : MonoBehaviour
{
    [SerializeField] private int puzzleIndex;
    [SerializeField] private List<GameObject> ActiveObjList;
    [SerializeField] private GameObject ActiveObj;
    [SerializeField] private bool isSequencePuzzle;
    [SerializeField] private float timeCinematics;
    [SerializeField] private CinemachineVirtualCamera cameraPuzzle;

    public void ActivateObj()
    {
        StartCoroutine("CameraViewChange", timeCinematics);

        if (isSequencePuzzle)
        {
            ActivationPuzzleController.instance.PuzzleInteract(ActiveObj);
            ActivationPuzzleController.instance.AddToPlayerSequence(puzzleIndex);
        }

    }

    IEnumerator CameraViewChange(float time)
    {
        Debug.Log(time);
        if (time > 0)
        {
            cameraPuzzle.Priority += 2;
        }
        yield return new WaitForSeconds(time);
        foreach (var Obj in ActiveObjList)
        {
            ActivationPuzzleController.instance.PuzzleInteract(Obj);
        }
        yield return new WaitForSeconds(time);
        if (time > 0)
        {
            cameraPuzzle.Priority -= 2;
            timeCinematics = 0;
        }

    }
}
