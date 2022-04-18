using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtPlayer : MonoBehaviour
{
    public int damageToGive;


    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Hey, got you!");
            
            //other.gameObject.GetComponent<PlayerHealthManager>().HurtPlayer(damageToGive);
        }
    }


}
