using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcademicManager : MonoBehaviour
{
    public bool inAca = false;
    public WellbeingManager wellbeingManager;



    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            inAca = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            inAca = false;
        }
    }
}
