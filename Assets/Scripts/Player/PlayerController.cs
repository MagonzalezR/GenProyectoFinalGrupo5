using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private void Start() {
        Cursor.lockState = CursorLockMode.Locked;
        
    }
    [SerializeField] private GameObject respawnOBj;
    private void FixedUpdate() {
    }
    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("Respawn")){
            transform.SetPositionAndRotation(respawnOBj.transform.position, transform.rotation);
            // PlayerRespawn();
        }   
    }
    private void PlayerRespawn(){
        Debug.Log(transform.position);
        Debug.Log(transform.position);
    }
}
