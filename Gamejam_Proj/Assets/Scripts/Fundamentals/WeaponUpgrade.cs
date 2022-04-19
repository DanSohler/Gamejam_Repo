using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponUpgrade : MonoBehaviour
{
    public TDC_Script playerScript;
    [Tooltip("Sets gun type, 0 = pistol, 1 = spread, 2 = boom")]
    public int weaponType;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerScript.SetGun(weaponType);
            Destroy(gameObject);
        }
    }
}
