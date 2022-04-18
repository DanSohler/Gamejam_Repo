using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtPlayer : MonoBehaviour
{
    public int damageToGive;
    public GameObject enemyObj;

    //calls enemies wellbeing state
    public WellbeingManager wellbeingManager;
    public EnemyHealthManager yourHealth;

    private void Awake()
    {
        wellbeingManager = FindObjectOfType<WellbeingManager>();
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //put stat damage here
            
            if (yourHealth.wellbeingState == "Social")
            {
                wellbeingManager.HitSocial();
            }
            else if (yourHealth.wellbeingState == "Physical")
            {
                wellbeingManager.HitPhysical();
            }
            else if (yourHealth.wellbeingState == "Academic")
            {
                wellbeingManager.HitAcademic();
            }
            else if (yourHealth.wellbeingState == "Financial")
            {
                wellbeingManager.HitMoney();
            }
            
                //Destroys enemy when they collide with player
                Destroy(enemyObj);
            
        }
    }


}
