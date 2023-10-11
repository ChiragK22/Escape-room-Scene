using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GrabableObject : MonoBehaviour
{
    public Rigidbody objectRigidbody;
    private Transform objectGrabPointTransform;
    float rotateSpeed = 100f;
    public bool isRigidbodyEnabled = true;

    public PhysicMaterial ballMaterial;
    public PhysicMaterial defaultMaterial;
    public PhysicMaterial boxMaterial;

    private Collider collider;
    public bool isMaterialEnabled = false;
    bool changeBox = false;
    bool changeSphere = false;
    float scaleSlider;

    private void Awake()
    {
        
        objectRigidbody = GetComponent<Rigidbody>();
        isRigidbodyEnabled = true;
        isMaterialEnabled = false;
        changeBox = false;
        changeSphere = false;
        collider = gameObject.GetComponent<Collider>();
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

    public void removePM()
    {
            if(collider is BoxCollider boxCollider)
            {
                changeBox = !changeBox;
                Debug.Log(changeBox);
                if(boxCollider.material = boxMaterial)
                {
                    if (changeBox == true)
                    {
                        boxCollider.material = defaultMaterial;
                        Debug.Log("Check the Material is null condition = " + boxCollider.material);
                    }
                }    
                else if (boxCollider.material = defaultMaterial)
                {
                    if (changeBox == false)
                    {
                        boxCollider.material = boxMaterial;
                        Debug.Log("Check the Material is null condition = " + boxCollider.material);
                    }
                }
                Debug.Log("Check the Material = " + boxCollider.material);
            }
            else if (collider is SphereCollider SphereCollider)
            {
                changeSphere = !changeSphere;
                Debug.Log(changeSphere);
                if (SphereCollider.material = ballMaterial)
                {
                    if (changeSphere == true)
                    {
                        SphereCollider.material = defaultMaterial;
                        Debug.Log("Check the Material is null condition = " + SphereCollider.material);
                    }
                }
                else if (SphereCollider.material = defaultMaterial)
                {
                    if (changeSphere == false)
                    {
                        SphereCollider.material = ballMaterial;
                        Debug.Log("Check the Material is null condition = " + SphereCollider.material);
                    }
                }
                Debug.Log("Check the Material = " + SphereCollider.material);
            }
    }


    /*public void MyCustomMethod(float scaleValue)
    {
        objectRigidbody.transform.localScale = new Vector3(scaleValue, scaleValue, scaleValue);
    }*/

    public void SetScale(float scaleValue)
    {
        objectRigidbody.transform.localScale = new Vector3(scaleValue, scaleValue, scaleValue);
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

    public void changeRigidBody()
    {
        isRigidbodyEnabled = !isRigidbodyEnabled;
        objectRigidbody.isKinematic = !isRigidbodyEnabled;
    }
    public void Drop()
    {
        this.objectGrabPointTransform = null;
        objectRigidbody.useGravity = true;
        objectRigidbody.constraints = RigidbodyConstraints.None;
    }
    public void destroyGameObject()
    {
        Destroy(objectRigidbody.gameObject);
    }


    /*public void SetScaleSlider()
    {
        if (GrabObjects.instance.isSelected == true)
        {
            SetScale(GrabObjects.instance.localScale.x);
        }
        else
        {
            SetScale(UIManger.instance.scaleValue);
        }
    }*/

    void GetSlider()
    {
        if(GrabObjects.instance.isSelected == true)
        {
            SetScale(UIManger.instance.defaultValue);
            GrabObjects.instance.isSelected = false;
            Debug.Log(UIManger.instance.defaultValue + "= Assign to DScale");
        }
        else
        {
            SetScale(UIManger.instance.scaleValue);
            Debug.Log(UIManger.instance.scaleValue + "= Assign to SScale");
        }
    }

    private void FixedUpdate()
    {
        if(objectGrabPointTransform != null)
        {
            float lerpSpeed = 10f;
            Vector3 newPositoin = Vector3.Lerp(transform.position, objectGrabPointTransform.position, Time.deltaTime * lerpSpeed);
            objectRigidbody.MovePosition(newPositoin);

            //SetScaleSlider();
            //GetSlider();
            SetScale(UIManger.instance.scaleValue);
        }

       
    }
}
