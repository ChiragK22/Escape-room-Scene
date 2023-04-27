using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PrefabsLoader : MonoBehaviour
{
    public static PrefabsLoader instance;

    public GameObject[] prefabs;
    public Vector3 spawnRotation;
    public Transform[] positions;

    
    public int prefabNum;
    public int prefabsGenNum;
    public int prefabObjectNum;
    public int prefabColorNum;
    public int prefabNumberFieldNum;
    public int numberOfObjects = 0;
    
    public string prefabName;
    public string prefabObjectName; 
    public string prefabColorName;
    public string prefabNumberName;
    
    public bool objectClicked;
    public bool inGameCubeClicked;
    public bool colorClicked;
    public bool numberClicked;
    public bool onlyOnePrefabClicked;

    public Material[] materials;
    public Renderer renderers;
    

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        objectClicked = false;
        colorClicked = false;
        renderers = GetComponent<Renderer>();
    }
   
    public void inGameButton(Button inGameCubeButton)
    {
        prefabName = inGameCubeButton.gameObject.name;
        prefabNum = int.Parse(prefabName);
        inGameCubeClicked = !inGameCubeClicked;
    }
    public void OnObjectClick(Button clickedButton)
    {
        string prefabObjectName = clickedButton.gameObject.name;
        prefabObjectNum = int.Parse(prefabObjectName);
        Debug.Log("Object number" + prefabObjectName);
        objectClicked = !objectClicked;
    }

    public void OnColorClick(Button clickedButton)
    {
        prefabColorName = clickedButton.gameObject.name;
        Debug.Log(prefabColorName);
        
        if(prefabColorName == "Blue")
        {
            prefabColorName = "0";
            Debug.Log(prefabColorName);
        }
        else if (prefabColorName == "Red")
        {
            prefabColorName = "1";
            Debug.Log(prefabColorName);
        }
        else if (prefabColorName == "Green")
        {
            prefabColorName = "2";
            Debug.Log(prefabColorName);
        }
        else if (prefabColorName == "Yellow")
        {
            prefabColorName = "3";
            Debug.Log(prefabColorName);
        }
        else if (prefabColorName == "Grey")
        {
            prefabColorName = "4";
            Debug.Log(prefabColorName);
        }
        Debug.Log("Prefab color name" + prefabColorName);
        prefabColorNum = int.Parse(prefabColorName);
        Debug.Log("color number" + prefabColorName);
        colorClicked = !colorClicked;
    }
    public void OnNumberFieldClicked(Button OnNumberButtonClicked)
    {
        prefabNumberName = OnNumberButtonClicked.gameObject.name;
        Debug.Log("Number ==" + prefabNumberName);

        if (prefabNumberName == "Five")
        {
            prefabNumberName = "5";
            Debug.Log(prefabColorName);
        }
        else if (prefabNumberName == "Ten")
        {
            prefabNumberName = "10";
            Debug.Log(prefabColorName);
        }

        prefabNumberFieldNum = int.Parse(prefabNumberName);
        prefabsGenNum = prefabNumberFieldNum;
        Debug.Log(prefabsGenNum + "HOW?");
        numberClicked = !numberClicked;
    }
    public void PrefabGetter()
    {
        renderers = prefabs[prefabObjectNum].GetComponent<Renderer>();
    }
    public void changeColor()
    {
        renderers.material = materials[prefabColorNum];
    }

    public void onePrefabLoader()
    {
        changeColor();
        for (int i = 0; i < prefabsGenNum; i++)
        {
            // Calculate the index of the prefab and position based on the loop counter
            int prefabIndex = i % prefabs.Length;
            int positionIndex = i % positions.Length;

            // Instantiate the prefab at the position
            Instantiate(prefabs[prefabObjectNum], positions[positionIndex].position, Quaternion.Euler(spawnRotation));
        }
    }

    public void QuitGameUI(string quiteTheGame)
    {
        if (quiteTheGame == "Yes")
        {
            onlyOnePrefabClicked = true;
        }
        else if (quiteTheGame == "No")
        {
            onlyOnePrefabClicked = false;
        }
    }


    public void loadPrefab()
    {
        if (onlyOnePrefabClicked == true)
        {
            PrefabLoader();
        }
        else
        {
            onePrefabLoader();
        }
    }
    public void PrefabLoader()
    {
        Debug.Log("prefabLoader");
        destroyGameObjects();
        changeColor();

        for (int i = 0; i < prefabsGenNum; i++)
        {
            // Calculate the index of the prefab and position based on the loop counter
            int prefabIndex = i % prefabs.Length;
            int positionIndex = i % positions.Length;

            // Instantiate the prefab at the position
            Instantiate(prefabs[prefabObjectNum], positions[positionIndex].position, Quaternion.Euler(spawnRotation));
        }


        //Instantiate(prefabs[prefabObjectNum], positions[numberOfObjects].position, Quaternion.Euler(spawnRotation));
    }
    public void destroyGameObjects()
    {
        if (prefabObjectNum == 0|| prefabObjectNum == 1 || prefabObjectNum == 2 || prefabObjectNum == 3 
        || prefabObjectNum == 4 || prefabObjectNum == 5 || prefabObjectNum == 6 || prefabObjectNum == 7 
        || prefabObjectNum == 8 || prefabObjectNum == 9 || prefabObjectNum == 10 || prefabObjectNum == 11)
        {
            GameObject[] pointObjects = GameObject.FindGameObjectsWithTag("Points");
            foreach (GameObject pointObject in pointObjects)
            {
                Destroy(pointObject);
            }
        }
    }
}
