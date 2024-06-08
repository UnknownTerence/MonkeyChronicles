using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testing : MonoBehaviour
{
    public Transform target;
    private float jumpForce = 10f;
    private Rigidbody rb;
    public bool isGrounded; // Check if the object is on the ground
    
    private void Start() {
        rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        transform.LookAt(target, Vector3.up);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded) {
            rb.AddForce(transform.forward*20, ForceMode.Impulse);
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            rb.AddTorque(transform.forward * jumpForce, ForceMode.Impulse);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}
