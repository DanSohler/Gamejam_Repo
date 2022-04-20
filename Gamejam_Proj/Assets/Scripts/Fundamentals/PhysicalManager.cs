using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicalManager : MonoBehaviour
{
    public WellbeingManager wellbeingManager;
    public bool playerEntered = false;

    public GameObject[] relayPoints = new GameObject[2];
    public int pointA = 1;
    public int pointB = 0;
    public int relayCounter = 0;


    private void Awake()
    {
        wellbeingManager = FindObjectOfType<WellbeingManager>();
    }


    public void ResetPoints()
    {
        relayPoints[pointA].SetActive(true);
    }

    public void VoidPoints()
    {
        relayPoints[pointA].SetActive(false);
        relayPoints[pointB].SetActive(false);
        playerEntered = false;
        relayCounter = 0;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (!playerEntered)
        {
            if (other.gameObject.tag == "Player")
            {
                ResetPoints();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            VoidPoints();
        }

    }
}
