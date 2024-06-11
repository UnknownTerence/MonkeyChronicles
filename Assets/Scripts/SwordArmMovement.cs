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
    private float finalCharge = 0.0f; 
    private float animationDuration;

    public float getCharge() {
        if (animationDuration>0.0f) return finalCharge; 
        else return 0.0f;  
    }

    void Update()
    {
        
        //charging up attack
        if (Input.GetMouseButton(0)) { //charging up right attack 
            charge+=Time.deltaTime*2; 
        } 

        //determining of stage 
        if (charge==0) armAngle.targetRotation = Quaternion.Euler(new Vector3(0, 0, 0)); 
        else if (charge<2) {
            armAngle.targetRotation = Quaternion.Euler(new Vector3(300, 0, 15)); 
        } else if (charge<4) { 
            armAngle.targetRotation = Quaternion.Euler(new Vector3(25, 0, 15)); 
        } else if (charge<6) { 
            armAngle.targetRotation = Quaternion.Euler(new Vector3(50, 0, 15)); 
        } else {
            armAngle.targetRotation = Quaternion.Euler(new Vector3(75, 0, 15)); 
        } 

        //sword movement
        if ((!Input.GetMouseButton(0)) && charge>0) {
            if (charge>6) finalCharge = 6.0f;
            else finalCharge = charge; 
            if (charge<2) {
                armAngle.targetRotation = Quaternion.Euler(new Vector3(0, 330, 0)); 
                thrust.AddForce(-thrust.transform.forward * 10 * configurationFactor); 
                animationDuration = 0.5f; 
            } else if (charge<4) {
                armAngle.targetRotation = Quaternion.Euler(new Vector3(0, 350, 0)); 
                thrust.AddForce(-thrust.transform.forward * 20 * configurationFactor);
                animationDuration = 1.0f; 
            } else if (charge<6) {
                armAngle.targetRotation = Quaternion.Euler(new Vector3(0, 350, 0)); 
                thrust.AddForce(-thrust.transform.forward * 40 * configurationFactor);
                animationDuration = 1.5f;
            } else if (charge>6) {
                armAngle.targetRotation = Quaternion.Euler(new Vector3(0, 350, 0)); 
                thrust.AddForce(-thrust.transform.forward * 80 * configurationFactor);
                thrust.AddForce(thrust.transform.up * configurationFactor/4);
                animationDuration = 2.0f; 
            }
            charge = 0;
        } 
        animationDuration-=Time.deltaTime; 
        if (animationDuration<0) animationDuration = 0.0f; 
    }

}
