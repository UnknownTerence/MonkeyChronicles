using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : EnemyController
{
    //HEAD ANIMATION 
    public RigidBody Head;
    public float headPower = 0.0;

    //LEG ANIMATION 
    public ConfigurableJoint LegR; 
    public ConfigurableJoint LegL; 
    private double interval = 0.0; 
    private double strafeInterval = 0.0; 
    private int direction = 1; 

    
    

    void FixedUpdate()
    {
        //put movement here based on enemyController 
    }
}
