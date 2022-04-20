using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponUpgrade : MonoBehaviour
{
    public TDC_Script playerScript;
    public WellbeingManager wellMan;
    [Tooltip("Sets gun type, 0 = pistol, 1 = spread, 2 = boom")]
    public int weaponType;
    public bool gunDisable = false;

    private void Awake()
    {
        wellMan = FindObjectOfType<WellbeingManager>();
    }

    private void Update()
    {
        
            if (wellMan.socialVal == 1 && !gunDisable || wellMan.physicalVal == 1 && !gunDisable || wellMan.academicVal == 1 && !gunDisable || wellMan.moneyVal == 1 && !gunDisable)
            {
                gameObject.SetActive(true);
                StartCoroutine(SpawnDelay());
            }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (gunDisable)
        {
            if (other.gameObject.tag == "Player")
            {
                playerScript.SetGun(weaponType);
                Destroy(gameObject);
            }
        }
    }


    IEnumerator SpawnDelay()
    {
        yield return new WaitForSeconds(90f);
        gameObject.GetComponent<MeshRenderer>().enabled = true;
        gameObject.GetComponent<BoxCollider>().enabled = true;
        gunDisable = true;
    }
}
