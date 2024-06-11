using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swordCollisionDetection : MonoBehaviour
{
    public SwordArmMovement swordArmMovement; 
    public Transform enemyRagdoll; 
    public float configurationFactor = 1.0f; 
    public float damageConfigurationFactor = 50.0f; 
    void OnCollisionEnter(Collision collisionInfo) {
        Rigidbody rb = collisionInfo.collider.GetComponent<Rigidbody>();
        if (rb!=null) { //checking if there is an existing rigidbody
            if (collisionInfo.collider.transform.root == enemyRagdoll && (!Input.GetMouseButtonDown(0))) {
            rb.AddForce(-rb.transform.forward * 50 * configurationFactor * swordArmMovement.getCharge());   
            rb.AddForce(rb.transform.up * 100 * configurationFactor * swordArmMovement.getCharge());
            EnemyController enemyScript = collisionInfo.collider.transform.root.GetComponent<EnemyController>(); 
            enemyScript.health -= (swordArmMovement.getCharge())/6 * damageConfigurationFactor; 
            Debug.Log(enemyScript.health); 
        }   
        }
            
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
