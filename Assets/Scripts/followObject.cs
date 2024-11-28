using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followObject : MonoBehaviour
{
    public GameObject player;
    MovePlayer playerControl;
    public Vector3 offset;
    public bool firstPerson = false;
    float xCamRotation, yCamRotation;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        playerControl = player.GetComponent<MovePlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = new Quaternion(0, 0, 0, 0);
        CamaraAerea();
    }

    private void CamaraAerea()
    {
        transform.position = new Vector3( player.transform.position.x, player.transform.position.y, 0) + offset;
    }

}
