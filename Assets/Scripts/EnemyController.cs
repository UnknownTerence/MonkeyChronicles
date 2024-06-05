using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    //TYPE OF ENEMY 
    public bool isRanged = false; 

    //ENEMY MOVEMENT 
    protected bool movingFoward = false; 
    protected bool movingBackward = false; 
    protected bool movingRight = false; 
    protected bool movingLeft = false; 

    //ENEMY ROTATION 
    public Transform target; 
    private Quaternion targetRotation; 
    //protected Quaternion gradualRotation; WORK FROM HERE" PROBLEM IS THAT I T AUTOMATICALLT SANAPAPS TO ROTATIATION
    public float rotationSpeed = 5f; 

    //ATTACK & PARRY DECISIONS 

    // Update is called once per frame
    void Update()
    {
        if (isRanged) {
            //isRanged ai is here, controls everything 
        } else {
            targetRotation = Quaternion.Euler(transform.rotation.x, target.rotation.y-transform.rotation.y, transform.rotation.z); 

        }
    }
}
