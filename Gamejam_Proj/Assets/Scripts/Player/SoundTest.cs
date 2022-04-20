using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundTest : MonoBehaviour
{


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            FindObjectOfType<AudioManagerScript>().Play("Hurt");
            Debug.Log("Playu");
        }
    }
}
