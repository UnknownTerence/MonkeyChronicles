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

    private void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.H)) {
            Instantiate(enemyObject, transform.position, transform.rotation);
        }
    }

    void spawnEnemy() {

    }

}
