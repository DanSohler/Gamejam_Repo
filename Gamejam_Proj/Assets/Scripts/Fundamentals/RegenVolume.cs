using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegenVolume : MonoBehaviour
{
    public WellbeingManager wellbeingManager;
    [Tooltip("Social, Physical, Academic, Financial")]
    public string currentState;

    
    #region Checks

    //Regen Volume
    private void OnTriggerEnter(Collider other)
    {
        if (currentState == "Social")
        {
            if (other.gameObject.tag == "Player")
            {
                wellbeingManager.socialRegen = true;
            }
        }

        if (currentState == "Physical")
        {
            if (other.gameObject.tag == "Player")
            {
                wellbeingManager.physicalRegen = true;
            }
        }

        if (currentState == "Academic")
        {
            if (other.gameObject.tag == "Player")
            {
                wellbeingManager.academicRegen = true;
            }
        }

        if (currentState == "Financial")
        {
            if (other.gameObject.tag == "Player")
            {
                wellbeingManager.moneyRegen = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (currentState == "Social")
        {
            if (other.gameObject.tag == "Player")
            {
                wellbeingManager.socialRegen = false;
            }
        }

        if (currentState == "Physical")
        {
            if (other.gameObject.tag == "Player")
            {
                wellbeingManager.physicalRegen = false;
            }
        }

        if (currentState == "Academic")
        {
            if (other.gameObject.tag == "Player")
            {
                wellbeingManager.academicRegen = false;
            }
        }

        if (currentState == "Financial")
        {
            if (other.gameObject.tag == "Player")
            {
                wellbeingManager.moneyRegen = false;
            }
        }
    }

    #endregion








}
