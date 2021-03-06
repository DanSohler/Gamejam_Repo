using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SocialPoint : MonoBehaviour
{
    public WellbeingManager wellbeingManager;

    private bool isInArea = false;

    private void Update()
    {   
        if (isInArea)
        {
            StartCoroutine(SocialTimer());
        }
        else
        {
            StopCoroutine(SocialTimer());
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            isInArea = true;
        }
    }


    public IEnumerator SocialTimer()
    {
        yield return new WaitForSeconds(1f);
        wellbeingManager.SocialAdd();
    }

    private void OnTriggerExit(Collider other)
    {
        isInArea = false;
        StopCoroutine(SocialTimer());
    }
}
