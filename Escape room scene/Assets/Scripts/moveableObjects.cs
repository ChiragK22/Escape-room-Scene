using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveableObjects : MonoBehaviour
{
    public float pushForce;

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Rigidbody rb = hit.collider.attachedRigidbody;

        if(rb != null && hit.collider.gameObject.tag != "EscapeObstacle" )
        {
            Vector3 forceDirection = hit.gameObject.transform.position - transform.position;
            forceDirection.y = 0;
            forceDirection.Normalize();
            rb.AddForceAtPosition(forceDirection * pushForce, transform.position, ForceMode.Impulse);
        }
    }

    
}
