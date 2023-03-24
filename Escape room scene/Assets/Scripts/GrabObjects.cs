using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabObjects : MonoBehaviour
{
    [SerializeField] private Transform playerCameraTranform;
    [SerializeField] private Transform objectGrabPointTransform;
    [SerializeField] private LayerMask pickupMask;

    private GrabableObject grabable;
    public float pickupDistance = 15f;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (grabable == null)
            {
                if (Physics.Raycast(playerCameraTranform.position, playerCameraTranform.forward, out RaycastHit hit, pickupDistance, pickupMask))
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
        if (Input.GetKey(KeyCode.Y))
        {
            grabable.RotateObjectsH();
        }
        if (Input.GetKey(KeyCode.T))
        {
            grabable.RotateObjectsV();
        }
    }
}
