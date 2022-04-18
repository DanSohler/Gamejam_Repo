using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletController : MonoBehaviour
{
    public float speed;
    public float bulletDecay;
    public int bulletDamage;

    //calls enemies wellbeing state
    public WellbeingManager wellbeingManager;
    private EnemyHealthManager yourHealth;

    private void Awake()
    {
        yourHealth = GetComponent<EnemyHealthManager>();
        wellbeingManager = GetComponent<WellbeingManager>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        Destroy(gameObject, bulletDecay);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //put stat damage here


            Destroy(gameObject);

        }
    }
}
