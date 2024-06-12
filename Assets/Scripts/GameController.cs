using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public double score = 0.0; 
    private float difficulty = 20.0f; 
    private float timer = 0.0f; 
    public double campfireHealth = 100.0f; 
    public GameObject enemyObject; 
    public GameObject enemyTarget; 
    public GameObject player; 
    public Transform node1; 
    public Transform node2;
    public Transform node3; 
    public Transform node4; 


    // Update is called once per frame
    private void Update()
    {
        difficulty-=Time.deltaTime*0.1f; 
        if (difficulty<7.0f) difficulty = 7.0f; 
        if (timer < 0.0f) {
            spawnEnemy(); 
            timer = difficulty; 
        }
        timer-=Time.deltaTime;
    }

    private void spawnEnemy() {
        byte node = (byte)Random.Range(0, 4); 
        GameObject enemy = null; 
        EnemyController.target = enemyTarget.transform;
        EnemyController.swordArmMovement = player.GetComponentInChildren<SwordArmMovement>(); 
        EnemyController.gameController = this; 
        if (node==0) {
            enemy = Instantiate(enemyObject, node1.position, transform.rotation); 
        } else if (node==1) {
            enemy = Instantiate(enemyObject, node2.position, transform.rotation);         
        } else if (node==2) {
            enemy = Instantiate(enemyObject, node3.position, transform.rotation);     
        } else {
            enemy = Instantiate(enemyObject, node4.position, transform.rotation);        
        }
    }

}
