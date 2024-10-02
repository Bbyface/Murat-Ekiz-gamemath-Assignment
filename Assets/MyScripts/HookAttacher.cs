using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookAttacher : MonoBehaviour
{
    public GameObject cable;
    public GameObject hook;

    void Start()
    {
        if (cable == null || hook == null)
        {
            Debug.LogWarning("You've gotta assign the Cable and Hook into the HookAttacher script on the scripthandler GameObject!");
        }
    }

    void Update()
    {
        if (cable != null && hook != null)
        {
            // Get the cable's collider
            Collider cableCollider = cable.GetComponent<Collider>();
            if (cableCollider != null)
            {
                // Calculate the bottom position of the cable
                Vector3 cableBottom = cableCollider.bounds.min;

                // Set the hook's position at the bottom of the cable's collider
                Vector3 hookPosition = new Vector3(cableCollider.bounds.center.x, cableBottom.y, cableCollider.bounds.center.z);
                hook.transform.position = hookPosition;

                // Match the hook's rotation to the cable's rotation
                hook.transform.rotation = cable.transform.rotation;
            }
        }
    }
}
