using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectionArea : MonoBehaviour
{
    public int countPoints = 0;
    public static CollectionArea instance;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        /*if (collision.gameObject.tag == "Points") {

            collision.gameObject.tag = "Untagged";
            StartCoroutine(addPoints());
        }*/
        Debug.Log(collision.gameObject.layer);
        if(collision.gameObject.layer== 8)
        {
            StartCoroutine(addPoints());
        }
        else if(collision.gameObject.layer == 6)
        {
            StartCoroutine(cutPoints());
        }
    }
    IEnumerator addPoints()
    {
        yield return new WaitForSeconds(0.5f);
        countPoints += 1;
        Debug.Log(countPoints);
    }

    IEnumerator cutPoints()
    {
        yield return new WaitForSeconds(0.5f);
        countPoints -= 1;
        Debug.Log(countPoints);
    }
}
