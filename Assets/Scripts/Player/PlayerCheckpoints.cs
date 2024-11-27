using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCheckpoints : MonoBehaviour
{
    [SerializeField] private GameObject respawnOBj;
    
    private void Awake() {
        respawnOBj.transform.position = transform.position;
    }
    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("checkpoint")){
            respawnOBj.transform.position = other.transform.position;
        }
    }
}
