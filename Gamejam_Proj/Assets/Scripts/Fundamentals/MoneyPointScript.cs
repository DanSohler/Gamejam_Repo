using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyPointScript : MonoBehaviour
{
    public MoneyPointManager moneyManager;
    public WellbeingManager wellbeingManager;



    private void Awake()
    {
        wellbeingManager = FindObjectOfType<WellbeingManager>();
    }


    private void OnTriggerEnter(Collider other)
    {

        if (moneyManager.boxGrabbed == false)
        {

            if (other.gameObject.tag == "Player")
            {

                moneyManager.chosenPointB = Random.Range(0, 9);
                if (moneyManager.chosenPointA == moneyManager.chosenPointB)
                {
                    moneyManager.chosenPointB = Random.Range(0, 9);
                }
                moneyManager.boxAreaEntered = true;
                moneyManager.boxPoints[moneyManager.chosenPointA].gameObject.SetActive(false);
                
            }
        }
        else
        {
            if (other.gameObject.tag == "Player")
            {
                moneyManager.boxGrabbed = false;
                wellbeingManager.MoneyAdd();

                moneyManager.chosenPointA = Random.Range(0, 9);
                if (moneyManager.chosenPointB == moneyManager.chosenPointA)
                {
                    moneyManager.chosenPointA = Random.Range(0, 9);
                }
                moneyManager.boxPoints[moneyManager.chosenPointA].gameObject.SetActive(true);
                moneyManager.boxPoints[moneyManager.chosenPointB].gameObject.SetActive(false);

            }
        }
    }
}
