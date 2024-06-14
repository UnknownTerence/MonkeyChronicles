using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class GameController : MonoBehaviour
{
    public static double score = 0.0; 
    private float difficulty = 20.0f; 
    private float timer = 0.0f; 
    public double campfireHealth = 100.0; 
    public double money = 10.0; 
    public int monkeyKilled = 0; 
    public GameObject enemyObject; 
    public GameObject landmine; 
    public GameObject barrier; 
    public GameObject enemyTarget; 
    public GameObject player; 
    public GameObject objectSpawnTarget; 
    public Transform objectRotationTarget; 
    public Transform node1; 
    public Transform node2;
    public Transform node3; 
    public Transform node4; 


    // Update is called once per frame
    private void Update()
    {
        score+=Time.deltaTime*monkeyKilled/10; 
        difficulty-=Time.deltaTime*0.1f; 
        if (difficulty<7.0f) difficulty = 7.0f; 
        if (timer < 0.0f) {
            spawnEnemy(); 
            timer = difficulty; 
        }
        timer-=Time.deltaTime;
        if (campfireHealth<0.0) {
            SceneManager.LoadScene("GameOver");
        }
        if (Input.GetKeyDown(KeyCode.K) && money>=50) {
            score+=150; 
        }
        if (Input.GetKeyDown(KeyCode.J) && money>=5) {
            spawnBarrier(); 
            money-=5; 
        }
    }

    private void spawnLandmine() {
        GameObject landmineObject = null; 
        Vector3 spawnPosition = new Vector3(objectSpawnTarget.transform.position.x, 1, objectSpawnTarget.transform.position.z); 
        landmineObject = Instantiate(landmine, spawnPosition, player.transform.rotation); 
    }

    private void spawnBarrier() {
       Vector3 objectEulerAngles = objectRotationTarget.rotation.eulerAngles;
       GameObject barrierObject = null;
       Vector3 spawnPosition = new Vector3(objectSpawnTarget.transform.position.x, 1, objectSpawnTarget.transform.position.z);
       Quaternion spawnRotation = Quaternion.Euler(new Vector3(-90, objectEulerAngles.y+90, 0));
       barrierObject = Instantiate(barrier, spawnPosition, spawnRotation);
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
