using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraneTrueForward : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Vector3 newForward = new Vector3(1, 0, 0); // Example: Pointing along the X-axis
        Quaternion newRotation = Quaternion.LookRotation(newForward, Vector3.up); // Assuming up is Y
        transform.rotation = newRotation;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
