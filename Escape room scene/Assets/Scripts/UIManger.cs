using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class UIManger : MonoBehaviour
{
    public GameObject MenuUI;
    public GameObject LevelItemsUI;
    public GameObject InGameUI;
    public GameObject ObjectGeneration;
    public GameObject ColorPanel;
    public GameObject NumberPanel;
    public GameObject AskPanel;
    bool isMenuOpen;
    bool isLevelOpen;
    public string levelName;

    public float minScale = 1f;
    public float maxScale = 100f;
    public Slider slider;
    public TextMeshProUGUI textSizeNumber;
    public float scaleValue;
    public float defaultValue;

    public static UIManger instance;


    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {

        if (InGameUI != null)
        {
            InGameUI.SetActive(false);
        }
        if (ObjectGeneration != null)
        {
            ObjectGeneration.SetActive(false);
        }
        if (ColorPanel != null)
        {
            ColorPanel.SetActive(false);
        }
        if (NumberPanel != null)
        {
            NumberPanel.SetActive(false);
        }
        if (AskPanel != null)
        {
            AskPanel.SetActive(false);
        }
        isMenuOpen = false;
        isLevelOpen = false;
    }

    public void OnUiButtonClick(Button clickedButton)
    {
        levelName = clickedButton.gameObject.name;
        Debug.Log("Button clicked: " + levelName);
        StartCoroutine(LoadLevel());
    }

    IEnumerator LoadLevel()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(levelName);
    }

    public void OnMenuButton(Button clickedButton)
    {
        string levelName = clickedButton.gameObject.name;
        Debug.Log(levelName + "last screen");
        if(levelName == "Levels")
        {
            if (isLevelOpen == false)
            {
                LeanTween.moveX(LevelItemsUI, 0, 1f);
                isLevelOpen = !isLevelOpen;
                LeanTween.moveX(MenuUI, -200, 0.5f);
                isMenuOpen = !isMenuOpen;
            }
        }
        else if(levelName == "LevelLoader" || levelName == "Level 1 Train" || levelName == "Level 1 Test" || levelName == "Level 2 Train" || levelName == "Level 2 Test")
        {
            if (isLevelOpen == true)
            {
                LeanTween.moveX(LevelItemsUI, -200, 0.5f);
                isLevelOpen = !isLevelOpen;
            }
        }
        else if(levelName == "Generate")
        {
            AskPanel.SetActive(!AskPanel.gameObject.activeSelf);
        }
        else if (levelName == "AskSpearate")
        {
            ObjectGeneration.SetActive(!ObjectGeneration.gameObject.activeSelf);
            AskPanel.SetActive(false);
        }
        else if (levelName == "0" || levelName == "1" || levelName == "2" || levelName == "3" || levelName == "4" || levelName == "5" || levelName == "6"
            || levelName == "7" || levelName == "8" || levelName == "9" || levelName == "10" || levelName == "11")
        {
            ColorPanel.SetActive(!ColorPanel.gameObject.activeSelf);
            ObjectGeneration.SetActive(false);
        }
        else if(levelName == "Blue" || levelName == "Red" || levelName == "Green" || levelName == "Yellow" || levelName == "Grey")
        {
            NumberPanel.SetActive(!NumberPanel.gameObject.activeSelf);
            ColorPanel.SetActive(false);
        }
        else if(levelName == "Five" || levelName == "Ten" || levelName == "15")
        {
            Debug.Log(levelName + "last and last");
            NumberPanel.SetActive(false);
        }
    }

    public void closeUI()
    {
        ObjectGeneration.SetActive(false);
    }


    private void Update()
    {
        if (GrabObjects.instance.isSelected == true && scaleValue != GrabObjects.instance.localScale.x)
        {
            defaultValue = GrabObjects.instance.localScale.x;
            //slider = 0 means local scale 1 and if slider 1 means scale 2 
            // 1
            slider.value = (defaultValue - 1f) / (maxScale - minScale);
            scaleValue = Mathf.Lerp(minScale, maxScale, slider.value);
            GrabObjects.instance.isSelected = false;
        }
        else
        {
            scaleValue = Mathf.Lerp(minScale, maxScale, slider.value);
        }

        textSizeNumber.text = "Size of object: " + scaleValue.ToString();

        if (Input.GetKeyDown(KeyCode.C))
        {
            InGameUI.SetActive(!InGameUI.gameObject.activeSelf);
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isMenuOpen == false)
            {
                LeanTween.moveX(MenuUI, 0, 1f);
                isMenuOpen = !isMenuOpen;
            }
            else if (isMenuOpen == true)
            {
                LeanTween.moveX(MenuUI, -200, 1f);
                isMenuOpen = !isMenuOpen;
            }
        }
    }
}
