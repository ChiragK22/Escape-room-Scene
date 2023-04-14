using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManger : MonoBehaviour
{
    public GameObject MenuUI;
    public GameObject LevelItemsUI;
    public GameObject InGameUI;
    public GameObject ObjectGeneration;
    public GameObject ColorPanel;
    public GameObject NumberPanel;
    bool isMenuOpen;
    bool isLevelOpen;
    public string levelName;

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
        if (ColorPanel != null)
        {
            NumberPanel.SetActive(false);
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
            ObjectGeneration.SetActive(!ObjectGeneration.gameObject.activeSelf);
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
        if (Input.GetKeyDown(KeyCode.C))
        {
            InGameUI.SetActive(!InGameUI.gameObject.activeSelf);
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(isMenuOpen == false)
            {
            LeanTween.moveX(MenuUI, 0, 1f);
            isMenuOpen = !isMenuOpen;
            }
            else if(isMenuOpen == true)
            {
                LeanTween.moveX(MenuUI, -200, 1f);
                isMenuOpen = !isMenuOpen;
            }
        }
    }
}
