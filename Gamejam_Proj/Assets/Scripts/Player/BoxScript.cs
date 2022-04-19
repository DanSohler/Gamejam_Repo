using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxScript : MonoBehaviour
{

    public GameObject box;

    public bool boxOn;

    // Start is called before the first frame update
    void Start()
    {
        box.SetActive(false);
    }

    public void BoxOn()
    {
        box.SetActive(true);
    }

    public void BoxOff()
    {
        box.SetActive(false);
    }
}
