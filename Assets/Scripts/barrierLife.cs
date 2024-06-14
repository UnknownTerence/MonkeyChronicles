using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class barrierLife : MonoBehaviour
{
    public double barrierHealth = 10;
    private bool attacking = false;
    private HashSet<Collider> enemiesColliding = new HashSet<Collider>();
    private bool isDying = false; // Add a flag to check if the barrier is dying

    void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.gameObject.transform.root.CompareTag("Enemy"))
        {
            EnemyController enemyController = collisionInfo.transform.root.gameObject.GetComponent<EnemyController>();
            enemiesColliding.Add(collisionInfo.collider);
            attacking = true;
        }
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

    // Update is called once per frame
    void Update()
    {
        if (!isDying) // Only update health if the barrier is not dying
        {
            if (attacking)
            {
                barrierHealth -= Time.deltaTime;
                
            }
            barrierHealth -= Time.deltaTime / 7;
            if (barrierHealth < 0)
            {
                StartCoroutine(Die());
            }
        }
    }

    IEnumerator Die()
    {
        isDying = true; // Set the flag to true

        // Disable collider and rigidbody
        Collider collider = GetComponent<Collider>();
        Rigidbody rigidbody = GetComponent<Rigidbody>();

        if (collider != null)
        {
            collider.enabled = false;
        }

        if (rigidbody != null)
        {
            rigidbody.isKinematic = true;
        }

        // Slowly sink into the floor
        Vector3 initialPosition = transform.position;
        float sinkSpeed = 0.5f; // Adjust the speed as needed

        while (transform.position.y > initialPosition.y - 1.0f) // Adjust the sinking distance as needed
        {
            transform.position -= new Vector3(0, sinkSpeed * Time.deltaTime, 0);
            yield return null;
        }

        // Destroy the object
        Destroy(gameObject);
    }
}
