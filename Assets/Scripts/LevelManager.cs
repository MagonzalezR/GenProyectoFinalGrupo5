using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class LevelManager : MonoBehaviour
{

    [SerializeField]private CinemachineVirtualCamera puzzle1Camera;
    
    [SerializeField] private OpenDoor openDoor;
    [SerializeField] private GameObject playerObj;
    public static LevelManager instance;

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
        // Cursor.lockState = CursorLockMode.Locked;
    }

    public void SolvePuzzle(){
        StartCoroutine("CameraOneViewChange");
        StopPlayer(4);
    }

    IEnumerator CameraOneViewChange(){
        puzzle1Camera.Priority = 11;
        yield return new WaitForSeconds(2);
        openDoor.Open();
        yield return new WaitForSeconds(2);
        puzzle1Camera.Priority = 1;

    }

    public void StopPlayer(float time){
        if(time<=0) return;
        playerObj.GetComponent<MovePlayer>().StartCoroutine("DisableSpeedForTime",time);
    }
}
