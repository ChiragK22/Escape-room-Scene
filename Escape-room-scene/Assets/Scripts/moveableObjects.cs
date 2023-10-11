using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveableObjects : MonoBehaviour
{
    public float pushForce;
    public float pushForce1;

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Rigidbody rb = hit.collider.attachedRigidbody;

        if (rb != null && hit.collider.gameObject.tag != "EscapeObstacle" && hit.collider.gameObject.tag != "Points")
        {
            Vector3 forceDirection = hit.gameObject.transform.position - transform.position;
            forceDirection.y = 0;
            forceDirection.Normalize();
            rb.AddForceAtPosition(forceDirection * pushForce, transform.position, ForceMode.Impulse);
        }

        else if(hit.collider.gameObject.layer == 8)
        {
            Vector3 forceDirection = hit.gameObject.transform.position - transform.position;
            forceDirection.y = 0;
            forceDirection.Normalize();
            rb.AddForceAtPosition(forceDirection * pushForce1, transform.position, ForceMode.Impulse);
        }

    }



}
