using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float distanceX = 0.0f; 
    public float distanceZ = 0.0f; 
    public float distanceY = 0.0f; 
    public GameObject reference; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(reference.transform.position.x + distanceX, reference.transform.position.y + distanceY, reference.transform.position.z + distanceZ);
    }


}
