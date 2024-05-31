using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class headAnimation : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody head; 
    public float power = 0.0f; 
    void Start()
    {
        head = GetComponent<Rigidbody>(); 
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(Input.GetKey(KeyCode.W)) {
             head.AddTorque(transform.forward*power);
        } else if (Input.GetKey(KeyCode.S)) {
            head.AddTorque(-transform.forward*power);
        }
        if(Input.GetKey(KeyCode.A)) {
             head.AddTorque(-transform.right*power*1000);
        } else if (Input.GetKey(KeyCode.D)) {
            head.AddTorque(transform.right*power*1000);
        }
    }
}
