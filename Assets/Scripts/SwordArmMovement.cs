using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordArmMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public ConfigurableJoint armAngle; 
    public float configurationFactor = 1.0f; 
    public Rigidbody thrust; 
    private float charge = 0.0f; 
    void Update()
    {
        
        //charging up attack
        if (Input.GetKey(KeyCode.K)) { //charging up right attack 
            Debug.Log("Charge: " + charge); 
            charge+=Time.deltaTime*2; 
        } 

        //determining of stage 
        if (charge==0) armAngle.targetRotation = Quaternion.Euler(new Vector3(0, 0, 0)); 
        else if (charge<2) {
            armAngle.targetRotation = Quaternion.Euler(new Vector3(300, 0, 0)); 
        } else if (charge<4) { 
            armAngle.targetRotation = Quaternion.Euler(new Vector3(25, 0, 0)); 
        } else if (charge<6) { 
            armAngle.targetRotation = Quaternion.Euler(new Vector3(50, 0, 0)); 
        } else {
            armAngle.targetRotation = Quaternion.Euler(new Vector3(100, 0, 0)); 
        } 

        //sword movement
        if ((!Input.GetKey(KeyCode.K) && !Input.GetKey(KeyCode.J)) && charge>0) {
            Debug.Log("launching"); 
            if (charge<2) {
                armAngle.targetRotation = Quaternion.Euler(new Vector3(0, 330, 0)); 
                thrust.AddForce(-thrust.transform.right * 10 * configurationFactor); 
            } else if (charge<4) {
                armAngle.targetRotation = Quaternion.Euler(new Vector3(0, 350, 0)); 
                thrust.AddForce(-thrust.transform.right * 20 * configurationFactor);
            } else if (charge<6) {
                armAngle.targetRotation = Quaternion.Euler(new Vector3(0, 350, 0)); 
                thrust.AddForce(-thrust.transform.right * 40 * configurationFactor);
            } else if (charge>6) {
                armAngle.targetRotation = Quaternion.Euler(new Vector3(0, 350, 0)); 
                thrust.AddForce(-thrust.transform.right * 80 * configurationFactor);
                thrust.AddForce(thrust.transform.up * configurationFactor/4);
            }
            charge = 0; 
        }
    }

}
