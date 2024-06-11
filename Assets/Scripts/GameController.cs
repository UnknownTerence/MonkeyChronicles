using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public double score = 0.0; 
    private float difficulty = 0.0f; 
    public float difficultyMultiplier = 0.0f; 
    private float timer = 0.0f; 
    public GameObject enemyObject; 
    public GameObject enemyTarget; 
    public Transform node1; 
    public Transform node2;
    public Transform node3; 
    public Transform node4; 

    private void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.H)) {
            spawnEnemy(); 
        }
    }

    private void spawnEnemy() {
        byte node = (byte)Random.Range(0, 4); 
        GameObject enemy = null; 
        EnemyController.target = enemyTarget.transform;
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
