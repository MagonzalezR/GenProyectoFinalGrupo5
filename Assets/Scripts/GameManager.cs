using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [SerializeField]private CinemachineVirtualCamera puzzle1Camera;
    
    [SerializeField] private OpenDoor openDoor;
    public static GameManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void SolvePuzzle(){
        StartCoroutine("CameraOneViewChange");
    }

    IEnumerator CameraOneViewChange(){
        puzzle1Camera.Priority = 11;
        yield return new WaitForSeconds(2);
        openDoor.Open();
        yield return new WaitForSeconds(2);
        puzzle1Camera.Priority = 1;

    }
}
