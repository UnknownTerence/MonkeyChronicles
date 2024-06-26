using System.Collections;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    // ENEMY MOVEMENT
    private ConfigurableJoint[] joints;
    private Rigidbody[] rigidbodies;
    protected bool movingFoward = false;
    protected bool movingBackward = false;
    protected bool movingRight = false;
    protected bool movingLeft = false;
    [HideInInspector] public double health = 60.0;
    protected bool dying = false;
    public static Transform target; 
    public static SwordArmMovement swordArmMovement; 
    public static GameController gameController; 
    public bool arrived = false; 

    void Start()
    {
        joints = gameObject.transform.root.gameObject.GetComponentsInChildren<ConfigurableJoint>();
        rigidbodies = gameObject.transform.root.gameObject.GetComponentsInChildren<Rigidbody>();
    }

    

    void Update()
    {
        if (!arrived) movingFoward = true;
        else movingFoward = false; 

        if (health < 0 && !dying)
        {
            dying = true;
            Die();
        }
    }

    private void Die()
    {
        // Disable each joint by setting its connectedBody to null
        foreach (ConfigurableJoint joint in joints)
        {
            joint.connectedBody = null;
        }

        // Start the coroutine to shrink and destroy the body parts
        StartCoroutine(ShrinkAndDestroy());
    }

    private IEnumerator ShrinkAndDestroy()
    {
        float shrinkDuration = 5.0f; // Duration over which the body parts will shrink
        float elapsedTime = 0.0f;

        while (elapsedTime < shrinkDuration)
        {
            // Calculate the scale factor based on the elapsed time
            float scale = Mathf.Lerp(1.0f, 0.0f, elapsedTime / shrinkDuration);

            // Apply the scale to each body part
            foreach (Rigidbody rb in rigidbodies)
            {
                if (rb != null)
                {
                    rb.transform.localScale = new Vector3(scale, scale, scale);
                }
            }

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Destroy the body parts after shrinking
        foreach (Rigidbody rb in rigidbodies)
        {
            if (rb != null)
            {
                Destroy(rb.gameObject);
            }
        }

        // Destroy the main game object
        GameController.score+=50; 
        gameController.money+=4; 
        gameController.monkeyKilled+=1; 
        Destroy(gameObject.transform.root.gameObject); 
    }
}
