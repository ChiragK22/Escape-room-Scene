using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabObjects : MonoBehaviour
{
    [SerializeField] private Transform playerCameraTranform;
    [SerializeField] private Transform objectGrabPointTransform;
    [SerializeField] private LayerMask pickupMask;

    private GrabableObject grabable;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if(grabable == null) 
            { 
                float pickupDistance = 15f;
                if(Physics.Raycast(playerCameraTranform.position, playerCameraTranform.forward, out RaycastHit hit, pickupDistance, pickupMask))
                {
                    if (hit.transform.TryGetComponent(out grabable))
                    {
                        grabable.Grab(objectGrabPointTransform);
                    }
                }
            }
            else
            {
                grabable.Drop();
                grabable = null;
            }
        }
    }

}
