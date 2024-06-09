using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // This script is from Ragdoll Tutorial - Ragdoll Movement by Happy Chuck Programming
    // Daniel & Terence | 5/26/2024 4:51 PM
    public float speed = 0.0f; // fwd and bwd
    private float mouseX = 0.0f;
    public Rigidbody hip; // reference to the rigidbody
    private void Start()
    {
        hip = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        mouseX = rotatePlayerX(Input.mousePosition);

        if(Input.GetKey(KeyCode.D))
            hip.AddForce(hip.transform.forward * speed);
        if(Input.GetKey(KeyCode.A))
            hip.AddForce(-hip.transform.forward * speed);
        if(Input.GetKey(KeyCode.W))
            hip.AddForce(-hip.transform.right * speed);
        if(Input.GetKey(KeyCode.S))
            hip.AddForce(hip.transform.right * speed);
        if(Input.anyKey)
            hip.AddForce(hip.transform.up * 100);

        hip.transform.LookAt(new Vector3(hip.transform.rotation.x,hip.transform.rotation.y+mouseX,hip.transform.rotation.y));

    }
    private float rotatePlayerX(Vector3 mousePos) {
        float horizontal = mousePos.x;
        if (horizontal > (Screen.width*0.90)) {
            Debug.Log("look right bruv");
            return 60.0f;
        }
        else if (horizontal < (Screen.width*0.10)) {
            Debug.Log("look left bruv");
            return -60.0f;
        }
        else
            return 0.0f;
    }
}
