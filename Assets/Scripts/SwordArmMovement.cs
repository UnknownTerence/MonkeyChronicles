using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordArmMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public ConfigurableJoint configurableJoint; 
    public float configurationFactorX = 0.0f; 
    public float configurationFactorY = 0.0f; 

    void FixedUpdate()
    {
        //Z AXIS movement (l r)
        float mouseXTranslation = translateMousePosX(Input.mousePosition);
        float mouseYTranslation = translateMousePosY(Input.mousePosition); 
        Quaternion newRotation = Quaternion.Euler(new Vector3(mouseYTranslation, mouseXTranslation, mouseXTranslation));
        configurableJoint.targetRotation = newRotation; 
    }

    public float translateMousePosX(Vector3 v) { //limits 540, -290
        float center = Screen.width/2; 
        float limit = Input.mousePosition.x-center; 
        if (limit > 540) limit = 540; 
        else if (limit < -290) limit = -310; 
        return (float)(limit)*configurationFactorX; 
        
    }

    public float translateMousePosY(Vector3 v) {
        float center = Screen.height/2; 
        return (float)(Input.mousePosition.y-center)*configurationFactorY;
    }
}
