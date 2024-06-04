using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController 
{
    //TYPE OF ENEMY 
    public bool isRanged = false; 

    //ENEMY MOVEMENT 
    protected bool movingFoward = false; 
    protected bool movingBackward = false; 
    protected bool movingRight = false; 
    protected bool movingLeft = false; 

    //ATTACK & PARRY DECISIONS 

    // Update is called once per frame
    void Update()
    {
        if (isRanged) {
            //isRanged ai is here, controls everything 
        } else {
            //if is melee ai is here, controls everything 
        }
    }
}
