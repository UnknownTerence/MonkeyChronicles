using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class campfireCollisionDetection : MonoBehaviour
{
    private bool attacking = false;
    public GameController gameController;
    private HashSet<Collider> enemiesColliding = new HashSet<Collider>();

    void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.gameObject.transform.root.CompareTag("Enemy"))
        {
            EnemyController enemyController = collisionInfo.transform.root.gameObject.GetComponent<EnemyController>(); 
            enemyController.arrived = true; 
            enemiesColliding.Add(collisionInfo.collider);
            attacking = true;
        }
        if (collisionInfo.gameObject.CompareTag("Sword")) gameController.campfireHealth+=0.1; 
    }

    void OnCollisionExit(Collision collisionInfo)
    {
        if (collisionInfo.gameObject.transform.root.CompareTag("Enemy"))
        {
            enemiesColliding.Remove(collisionInfo.collider);
            if (enemiesColliding.Count == 0)
            {
                attacking = false;
            }
        }
    }

    void Update()
    {
        if (attacking)
        {
            // Detecting distance
            gameController.campfireHealth -= Time.deltaTime;
        }
    }
}
