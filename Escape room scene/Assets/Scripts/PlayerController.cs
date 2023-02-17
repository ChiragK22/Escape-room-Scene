using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public int escapeObstacleCount;
    public GameObject door;
    bool _openTheDoor;
    public TextMeshProUGUI textCounter;
    public GameObject endGame;
  //  public GameObject info;
    public GameObject warningUI;
    private void Start()
    {
        escapeObstacleCount = 0;
        _openTheDoor = false;
        endGame.gameObject.SetActive(false);
       // info.gameObject.SetActive(true);
        warningUI.gameObject.SetActive(false);
    }

    private void Update()
    {
        textCounter.text = "Score: " + escapeObstacleCount.ToString();
        if (_openTheDoor == true)
        {
            DoorOpen();
        }

       /* if (Input.GetKeyUp(KeyCode.Tab))
        {
            info.gameObject.SetActive(!info.gameObject.activeSelf);
        }*/
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "EscapeObstacle")
        {
            escapeObstacleCount += 1;
            Debug.Log("EscapeObstacle");
            //collision.gameObject.SetActive(false);
            Destroy(collision.gameObject);
        }
        if(collision.gameObject.tag == "DoorOpenEvent" && escapeObstacleCount == 5)
        {
            Debug.Log("Count 5");
            _openTheDoor = true;
        }
        else if(collision.gameObject.tag == "DoorOpenEvent" && escapeObstacleCount != 5)
        {
            warningUI.gameObject.SetActive(true);
            StartCoroutine(OpenWaringUI());
        }
    }

    IEnumerator OpenWaringUI()
    {
        yield return new WaitForSeconds(2f);
        warningUI.gameObject.SetActive(false);
    }

    public void DoorOpen()
    {
        LeanTween.moveLocalY(door, 6f, 0.5f).setEaseInOutQuad();
        StartCoroutine(EndGameUI());
    }

    IEnumerator EndGameUI()
    {
        yield return new WaitForSeconds(2f);
        endGame.gameObject.SetActive(true);
    }
}
