using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthManager : MonoBehaviour
{
    public int health;
    private int currentHealth;

    //Connects enemy to wellbeing manager
    public WellbeingManager wellbeingManager;
    public RegenVolume regenScript;
    [Tooltip("0 = Social, 1 = Physical, 2 = Academic, 3 = Financial")]
    [Range(0, 3)] public int wellbeingID;
    public string wellbeingState;

    private void Awake()
    {
        wellbeingManager = FindObjectOfType<WellbeingManager>();
        regenScript = FindObjectOfType<RegenVolume>();
    }

    void Start()
    {
        currentHealth = health;
        wellbeingID = regenScript.currentState;

        if (wellbeingID == 0)
        {
            wellbeingState = "Social";
        }
        else if (wellbeingID == 1)
        {
            wellbeingState = "Physical";
        }
        else if (wellbeingID == 2)
        {
            wellbeingState = "Academic";
        }
        else if (wellbeingID == 3)
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
