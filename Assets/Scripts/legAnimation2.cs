using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class legAnimation2 : MonoBehaviour
{
    // Start is called before the first frame update
    public double limit = 4.5; 
    private double interval = 0.0; 
    public ConfigurableJoint configurableJoint; 
    public int direction = 0; 


    // Update is called once per frame
    void FixedUpdate()
    {
        if(Input.GetKey(KeyCode.W)) {
            interval+=0.1;
            configurableJoint.targetRotation = Quaternion.Euler(new Vector3(0f, 0f, 55*direction)); 
        } else if (Input.GetKey(KeyCode.S)) {
            interval+=0.1; 
            configurableJoint.targetRotation = Quaternion.Euler(new Vector3(0f, 0f, -55*direction)); 
        } else configurableJoint.targetRotation = Quaternion.Euler(new Vector3(0f, 0f, 0f)); 
        Debug.Log(interval); 
        if (interval>limit) {direction*=-1; interval=0.0;}
    }
}
