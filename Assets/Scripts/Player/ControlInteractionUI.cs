using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ControlInteractionUI : MonoBehaviour
{
    private bool selectable = false, isAdded;
    // Update is called once per frame

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Interactive"))
        {
            other.gameObject.GetComponentInChildren<Canvas>().enabled = true;
            selectable = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Interactive"))
        {
            other.gameObject.GetComponentInChildren<Canvas>().enabled = false;
            selectable = false;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (selectable && Input.GetButton("Interact"))
        {
            other.GetComponent<ActionActivator>().ActivateObj();
            selectable = false;
            StartCoroutine("awaitAcction");
        }
    }

    IEnumerator awaitAcction(){
        yield return new WaitForSeconds(2f);
        selectable = true;
    }
}
