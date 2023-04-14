using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabableObject : MonoBehaviour
{
    public Rigidbody objectRigidbody;
    private Transform objectGrabPointTransform;
    float rotateSpeed = 100f;

    private void Awake()
    {
        objectRigidbody = GetComponent<Rigidbody>();
    }
    public void Grab(Transform objectGrabPointTransform)
    {
        this.objectGrabPointTransform = objectGrabPointTransform;
        objectRigidbody.useGravity = false;
        objectRigidbody.constraints = RigidbodyConstraints.FreezeRotation;
    }

    public void RotateObjectsH()
    {
        if(objectRigidbody.tag == "Points")
        {
            objectRigidbody.transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime);
        }
    }

    public void RotateObjectsV()
    {
        if (objectRigidbody.tag == "Points")
        {
            objectRigidbody.transform.Rotate(Vector3.right * rotateSpeed * Time.deltaTime);
        }
    }

    public void ObjectLoader()
    {
        Debug.Log("ObjectLoader");
        if(objectRigidbody != null)
        {
            Destroy(objectRigidbody.gameObject);
        }
        Instantiate(PrefabsLoader.instance.prefabs[PrefabsLoader.instance.prefabNum], objectGrabPointTransform.position, Quaternion.Euler(PrefabsLoader.instance.spawnRotation));
        Debug.Log("This gives number of object that should be load" + PrefabsLoader.instance.prefabNum);
    }

    public void ColorChange()
    {
        PrefabsLoader.instance.changeColor();
    }
    public void Drop()
    {
        this.objectGrabPointTransform = null;
        objectRigidbody.useGravity = true;
        objectRigidbody.constraints = RigidbodyConstraints.None;
    }

    private void FixedUpdate()
    {
        if(objectGrabPointTransform != null)
        {
            float lerpSpeed = 10f;
            Vector3 newPositoin = Vector3.Lerp(transform.position, objectGrabPointTransform.position, Time.deltaTime * lerpSpeed);
            objectRigidbody.MovePosition(newPositoin);
        }
    }
}
