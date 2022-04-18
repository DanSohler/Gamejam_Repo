using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthManager : MonoBehaviour
{
    public int health;
    private int currentHealth;

    //Connects enemy to wellbeing manager
    public WellbeingManager wellbeingManager;
    public int wellbeingID;
    public string wellbeingState;

    void Start()
    {
        currentHealth = health;
        // will produce a number thats either 1, 2, 3 or 4
        wellbeingID = Random.Range(1, 5);

        if (wellbeingID == 1)
        {
            wellbeingState = "Social";
        }
        else if (wellbeingID == 2)
        {
            wellbeingState = "Physical";
        }
        else if (wellbeingID == 3)
        {
            wellbeingState = "Academic";
        }
        else if (wellbeingID == 4)
        {
            wellbeingState = "Financial";
        }

    }

    private void Update()
    {
        if(currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void HurtEnemy(int damage)
    {
        currentHealth -= damage;
    }
}
