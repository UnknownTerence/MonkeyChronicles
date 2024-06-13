using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordArmMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public ConfigurableJoint armAngle; 
    public double attacking = 0.0; 

    void Update()
    { 
        //if the user presses mouse, the sword moves down for 0.5 seconds, even once they let go. if the user presses mouse while sword is moving down, nothing happens.
        if (Input.GetMouseButton(0)) {
            if (attacking==0.0) {
                Debug.Log("Now attacking"); 
                attacking = 1;
            } 
        }
        if (attacking>0.0) {
            armAngle.targetRotation = Quaternion.Euler(new Vector3(-50, 0, 0)); 
        } else armAngle.targetRotation = Quaternion.Euler(new Vector3(50, 0, 15)); 

        attacking-=Time.deltaTime; 
        if (attacking<0) attacking=0.0; 
    }

}
