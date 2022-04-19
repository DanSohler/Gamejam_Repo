using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicalPointScript : MonoBehaviour
{
    public WellbeingManager wellbeingManager;
    public PhysicalManager phsManager;


    private void Awake()
    {
        wellbeingManager = FindObjectOfType<WellbeingManager>();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (!phsManager.playerEntered)
        {
            if (other.gameObject.tag == "Player")
            {
                phsManager.relayPoints[phsManager.pointB].SetActive(true);
                phsManager.relayPoints[phsManager.pointA].SetActive(false);
                phsManager.playerEntered = true;
                if (phsManager.relayCounter >= 1)
                {
                    phsManager.relayCounter = +1;
                    wellbeingManager.PhysicalAdd();
                }
                phsManager.relayCounter = +1;
            }
        }
        else
        {
            if (other.gameObject.tag == "Player")
            {
                phsManager.relayPoints[phsManager.pointB].SetActive(false);
                phsManager.relayPoints[phsManager.pointA].SetActive(true);
                phsManager.playerEntered = false;
                wellbeingManager.PhysicalAdd();
                phsManager.relayCounter = +1;
            }
        }
    }
}
