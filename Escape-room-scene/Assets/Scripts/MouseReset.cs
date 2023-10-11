using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseReset : MonoBehaviour
{
    public float sensitivity; // mouse sensitivity
    public Camera cam; // main camera
    bool isRotating;

    private Vector2 mouseCenter; // center of the screen
    private Quaternion initialRotation; // initial rotation of the camera

    private void Start()
    {
        isRotating = false;
        // calculate center of the screen
        mouseCenter = new Vector2(Screen.width / 2f, Screen.height / 2f);

        // store initial rotation of the camera
        initialRotation = cam.transform.rotation;
    }

    private void Update()
    {
        // get current mouse position
        Vector2 mousePos = Input.mousePosition;

        // calculate distance from center of screen
        //float deltaX = mousePos.x - mouseCenter.x;
        float deltaY = mousePos.y - mouseCenter.y;
        if (Input.GetKeyDown(KeyCode.M))
        {
            isRotating = !isRotating;
            Debug.Log(isRotating);
        }
        if (isRotating == true)
        {
            cam.transform.rotation *= Quaternion.Euler(-deltaY * sensitivity, 0, 0f);
        }

        // rotate camera based on mouse input

        // reset camera rotation to initial position
       /* if (Input.GetKeyDown(KeyCode.R))
        {
            cam.transform.rotation = initialRotation;
        }*/

        // reset mouse position to center of screen
       /* Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;*/
        mouseCenter = Input.mousePosition;
    }

}
