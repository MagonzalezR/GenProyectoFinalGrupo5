using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private GameObject respawnOBj;
    private void FixedUpdate() {
        if(Input.GetButtonDown("Fire1")){
            PlayerRespawn();
            transform.SetPositionAndRotation(respawnOBj.transform.position, transform.rotation);
        }
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
