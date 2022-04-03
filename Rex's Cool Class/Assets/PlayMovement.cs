using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayMovement : MonoBehaviour
{
    public bool EventTriggered = false;
    public float speed;

    // Update is called once per frame
    void Update()
    {
        this.transform.position = new
        Vector3(this.transform.position.x+Input.GetAxis("Horizontal") * speed, this.transform.position.y, this.transform.position.z + Input.GetAxis("Vertical") * speed);
        //replace 'X' with *
    }
}
