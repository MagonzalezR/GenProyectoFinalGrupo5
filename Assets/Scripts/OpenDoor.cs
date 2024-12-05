using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    [SerializeField] Animator doorAnimator;
    // Start is called before the first frame update
    void Start()
    {
        doorAnimator = GetComponent<Animator>();
    }

    public void Open(){
        doorAnimator.SetBool("PuzzleSolved", true);
    }
}
