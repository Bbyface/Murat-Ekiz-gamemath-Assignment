using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookPicksUpConcrete : MonoBehaviour
{
    public GameObject hook;
    public GameObject concrete;
    public float yOffset = 1.0f;
    private bool isAttached = false;

    
    private void Update()
    {
        if (hook != null && concrete != null)
        {
            CheckForCollision();
            if (isAttached)
            {
                FollowHook();
            }
        }
    }
    
    private void CheckForCollision()
    {
        //this gets the box colliders of both gameobjects, hook and concrete
        BoxCollider hookCollider = hook.GetComponent<BoxCollider>();
        SphereCollider concreteCollider = concrete.GetComponent<SphereCollider>();

        if (hookCollider != null && concreteCollider != null)
        {
            if (hookCollider.bounds.Intersects(concreteCollider.bounds))
            {
                AttachConcrete();
            }
        }
    }

    private void AttachConcrete()
    {
        //this calculates the midpoint of hook and concrete to more accurately depict the hook carrying the concrete by the lines.
        Vector3 hookPosition = hook.transform.position;
        Vector3 concretePosition = concrete.transform.position;

        Vector3 midpoint = (hookPosition + concretePosition);
        //this could've been done by transforming the concrete into a child of the hook but since that's what I assume transform parenting is, it's not allowed.
        concrete.transform.position = midpoint;
        //this disables further updates so it doesn't constantly keep trying to attach the hook.
        isAttached = true;
    }

    private void FollowHook()
    {
        concrete.transform.position = new Vector3(hook.transform.position.x, hook.transform.position.y + yOffset, hook.transform.position.z);
    }
}
