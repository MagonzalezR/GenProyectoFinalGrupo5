using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class ActionActivator : MonoBehaviour
{
    [SerializeField] private ColorChanger objectIndex;
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
            ActivationPuzzleController.instance.AddToPlayerSequence(objectIndex);
        }

    }

    IEnumerator CameraViewChange(float time)
    {
        if (cameraPuzzle != null)
        {
            cameraPuzzle.Priority += 2;
        }
        LevelManager.instance.StopPlayer(time*2);
        yield return new WaitForSeconds(time);
        foreach (var Obj in ActiveObjList)
        {
            ActivationPuzzleController.instance.PuzzleInteract(Obj);
        }
        yield return new WaitForSeconds(time);
        if (cameraPuzzle != null)
        {
            cameraPuzzle.Priority -= 2;
        }
        timeCinematics = 0;

    }
}
