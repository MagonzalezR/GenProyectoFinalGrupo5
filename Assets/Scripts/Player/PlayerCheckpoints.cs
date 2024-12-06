using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCheckpoints : MonoBehaviour
{
    [SerializeField] private Vector3 respawnPoint;
    [SerializeField] private float botomLimit;
    [SerializeField] private Reposition mainCameraReposition;
    
    private void Awake() {
        respawnPoint = transform.position;
    }

    private void Update() {
        if(transform.position.y <= botomLimit){
            Respawn();
        }
    }
    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("checkpoint")){
            respawnPoint = other.transform.position;
        }
        if(other.gameObject.CompareTag("Respawn")){
            Respawn();
        } 
    }

    private void Respawn(){
        transform.SetPositionAndRotation(respawnPoint, transform.rotation);
        mainCameraReposition.RepositionCamera();
    }
}
