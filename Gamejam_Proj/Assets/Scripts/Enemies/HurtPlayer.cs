using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtPlayer : MonoBehaviour
{
    public int damageToGive;
    public GameObject enemyObj;


    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Hey, got you!");

            //Destroys enemy when they collide with player
            Destroy(enemyObj);

            //other.gameObject.GetComponent<PlayerHealthManager>().HurtPlayer(damageToGive);
        }
    }


}
