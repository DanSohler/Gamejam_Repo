using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletController : MonoBehaviour
{
    public float speed;
    public int bulletDamage;

    //calls enemies wellbeing state
    public WellbeingManager wellbeingManager;
    public EnemyHealthManager yourHealth;

    private void Awake()
    {
        wellbeingManager = FindObjectOfType<WellbeingManager>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
    void OnTriggerEnter(Collider other)
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

            Destroy(gameObject);

        }
    }
}
