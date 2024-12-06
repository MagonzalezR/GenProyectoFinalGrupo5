using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class Reposition : MonoBehaviour
{
    [SerializeField]private float dzHeight, dzWidth;
    [SerializeField]private CinemachineVirtualCamera virtualCamera;
    [SerializeField]CinemachineComposer cinemachineComposer;

    private void Start() {
        virtualCamera = GetComponent<CinemachineVirtualCamera>();
        cinemachineComposer = virtualCamera.GetCinemachineComponent<CinemachineComposer>();
        dzHeight = cinemachineComposer.m_DeadZoneHeight;
        dzWidth = cinemachineComposer.m_DeadZoneWidth;
    }
    public void RepositionCamera(){
        cinemachineComposer.m_DeadZoneHeight=0;
        cinemachineComposer.m_DeadZoneWidth=0;
        StartCoroutine("ReturnToDefault");
        GameManager.instance.StopPlayer(2);
    }

    IEnumerator ReturnToDefault(){
        yield return new WaitForSeconds(2);
        cinemachineComposer.m_DeadZoneHeight=dzHeight;
        cinemachineComposer.m_DeadZoneWidth=dzWidth;
    }
}
