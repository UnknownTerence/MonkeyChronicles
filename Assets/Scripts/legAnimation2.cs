using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class legAnimation2 : MonoBehaviour
{
    // Start is called before the first frame update
    public double limit = 4.5; 
    private double interval = 0.0; 
    private double strafeInterval = 0.0;
    public ConfigurableJoint configurableJoint; 
    public int direction = 0; 
    /*
    direction = -1  represents the left leg
    direction = 1   represents the right leg
    */
    public int sDirection = 0;


    // Update is called once per frame
    void FixedUpdate()
    {
        // forward and backwards movement
        if(Input.GetKey(KeyCode.W)) {
            interval+=0.1;
            configurableJoint.targetRotation = Quaternion.Euler(new Vector3(0f, 0f, 55*direction)); 
        } else if (Input.GetKey(KeyCode.S)) {
            interval+=0.1; 
            configurableJoint.targetRotation = Quaternion.Euler(new Vector3(0f, 0f, -55*direction)); 
        } else configurableJoint.targetRotation = Quaternion.Euler(new Vector3(0f, 0f, 0f)); 
        Debug.Log(interval); 
        if (interval>limit) {direction*=-1; interval=0.0;}

        // strafe movement
        if(Input.GetKey(KeyCode.A)) {
            strafeInterval+=0.1;
            configurableJoint.targetRotation = Quaternion.Euler(new Vector3(-35*sDirection, 0f, 0f));
        }
        if(Input.GetKey(KeyCode.D)) {
            strafeInterval+=0.1;
            configurableJoint.targetRotation = Quaternion.Euler(new Vector3(35*sDirection, 0f, 0f));
        }
        if (strafeInterval>limit) {sDirection*=-1; strafeInterval=0.0;}
    }
}
