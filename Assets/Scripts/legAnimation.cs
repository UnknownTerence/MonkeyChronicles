using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class legAnimation : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody leg; 
    public float power = 0.0f; 
    public float speed = 0.0f; 
    void Start()
    {
        leg = GetComponent<Rigidbody>(); 
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(Input.GetKey(KeyCode.W)) {
             leg.AddTorque(transform.forward*power);
        } else if (Input.GetKey(KeyCode.S)) {
            leg.AddTorque(-transform.forward*power);
        }
    }
}
