using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyPointManager : MonoBehaviour
{
    public WellbeingManager wellbeingManager;

    public BoxScript boxScript;

    private bool playerEnteredArea = false;
    public bool boxGrabbed = false;
    public int chosenPointA;
    public int chosenPointB;

    public bool boxAreaEntered = false;

    public GameObject[] boxPoints = new GameObject[9];

    private void Awake()
    {
        wellbeingManager = FindObjectOfType<WellbeingManager>();
        boxScript = FindObjectOfType<BoxScript>();
    }

    private void Update()
    {
        if (boxAreaEntered == true)
        {
            StartCoroutine(BoxTimer());
            boxAreaEntered = false;
        }
    }

    public void ResetMoArea()  
    {
        chosenPointA = Random.Range(0, 9);
        boxPoints[chosenPointA].SetActive(true);
        playerEnteredArea = true;
    }

    public void VoidMoArea()
    {
        boxScript.BoxOff();
        boxGrabbed = false;
        playerEnteredArea = false;

        boxPoints[chosenPointA].SetActive(false);
        boxPoints[chosenPointB].SetActive(false);

        chosenPointA = 0;
        chosenPointB = 0;

    }

    private void OnTriggerEnter(Collider other)
    {
        if (!playerEnteredArea)
        {
            if (other.gameObject.tag == "Player")
            {
                ResetMoArea();
            }
        }    
    }

    private void OnTriggerExit(Collider other)
    {
        if (playerEnteredArea)
        {
            if (other.gameObject.tag == "Player")
            {
                VoidMoArea();
            }
        }
        
    }



    public IEnumerator BoxTimer()
    {
        yield return new WaitForSeconds(0.5f);
        boxPoints[chosenPointB].SetActive(true);
        boxGrabbed = true;
    }
}
