using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyPointManager : MonoBehaviour
{
    public WellbeingManager wellbeingManager;

    private bool playerEnteredArea = false;
    public bool boxGrabbed = false;
    public int chosenPointA;
    public int chosenPointB;

    public bool boxAreaEntered = false;


    public GameObject[] boxPoints = new GameObject[9];

    private void Update()
    {
        if (boxAreaEntered == true)
        {
            StartCoroutine(BoxTimer());
            boxAreaEntered = false;
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (!playerEnteredArea)
        {
            if (other.gameObject.tag == "Player")
            {
                chosenPointA = Random.Range(0, 9);
                boxPoints[chosenPointA].SetActive(true);
                playerEnteredArea = true;
            }
        }
                
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerEnteredArea = false;

            boxPoints[chosenPointA].SetActive(false);
            boxPoints[chosenPointB].SetActive(false);

            chosenPointA = 0;
            chosenPointB = 0;
        }
    }



    public IEnumerator BoxTimer()
    {
        yield return new WaitForSeconds(0.1f);
        boxPoints[chosenPointB].SetActive(true);
        boxGrabbed = true;
    }
}
