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
    public float moveSpeed;
    public float moveLimit;

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

        if (Input.GetKeyDown(KeyCode.Z))
        {
            if (objectGrabPointTransform.position.y < moveLimit)
            {
                objectGrabPointTransform.position = new Vector3(objectGrabPointTransform.position.x, moveLimit, objectGrabPointTransform.position.z);
            }
            else
            {
                objectGrabPointTransform.position += Vector3.up * moveSpeed;
            }
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            objectGrabPointTransform.position -= Vector3.up * moveSpeed;
            if (objectGrabPointTransform.position.y < moveLimit)
            {
                objectGrabPointTransform.position = new Vector3(objectGrabPointTransform.position.x, moveLimit, objectGrabPointTransform.position.z);
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
        if (Input.GetKey(KeyCode.R))
        {
            // StartCoroutine(changeRB());
            grabable.changeRigidBody();
        }

        if (PrefabsLoader.instance.inGameCubeClicked == true)
        {
            Debug.Log("If this is true load the Method");
            grabable.ObjectLoader();
            PrefabsLoader.instance.inGameCubeClicked = false;
        }

        if (Input.GetKeyDown(KeyCode.G))
        {
            grabable.removePM();
        }

        /*if (PrefabsLoader.instance.colorClicked == true)
        {
            PrefabsLoader.instance.colorClicked = false;
            Debug.Log("If this is true change the color");
            grabable.ColorChange();
        }*/
    }
    /*IEnumerator changeRB()
        {
            yield return new WaitForSeconds(0.5f);
            grabable.changeRigidBody();
        }*/
}
