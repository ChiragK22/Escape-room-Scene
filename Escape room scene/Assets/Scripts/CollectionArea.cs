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
        if (collision.gameObject.tag == "Points") {

            collision.gameObject.tag = "Untagged";
            StartCoroutine(addPoints());
        }
    }
    IEnumerator addPoints()
    {
        yield return new WaitForSeconds(0.2f);
        countPoints += 1;
        Debug.Log(countPoints);
    }
}
