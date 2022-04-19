using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    public bool isFiring;

    public TDC_Script playerScript;

    public BulletController bullet;
    public float bulletSpeed;

    public float timeBetweenShots;
    private float shotCounter;

    public GameObject[] firePoint = new GameObject[5];
    private int currentGunType;



    // Update is called once per frame
    void Update()
    {
        //sets what gun is active
        currentGunType = playerScript.currentGun;

        // for the pistol
        if (currentGunType == 0)
        {
            if (isFiring)
            {
                shotCounter -= Time.deltaTime;
                if (shotCounter <= 0)
                {
                    shotCounter = timeBetweenShots;
                    BulletController newBullet = Instantiate(bullet, firePoint[0].transform.position, firePoint[0].transform.rotation) as BulletController;
                    newBullet.speed = bulletSpeed;
                }
            }
            else
            {
                shotCounter = 0;
            }
        }

        // for the spread
        if (currentGunType == 1)
        {
            if (isFiring)
            {
                shotCounter -= Time.deltaTime;
                if (shotCounter <= 0)
                {
                    shotCounter = timeBetweenShots;
                    BulletController newBullet = Instantiate(bullet, firePoint[0].transform.position, firePoint[0].transform.rotation) as BulletController;
                    newBullet.speed = bulletSpeed;
                    BulletController newBullet1 = Instantiate(bullet, firePoint[1].transform.position, firePoint[1].transform.rotation) as BulletController;
                    newBullet1.speed = bulletSpeed;
                    BulletController newBullet2 = Instantiate(bullet, firePoint[2].transform.position, firePoint[2].transform.rotation) as BulletController;
                    newBullet2.speed = bulletSpeed;
                }
            }
            else
            {
                shotCounter = 0;
            }
        }

        // for the Boom
        if (currentGunType == 2)
        {
            if (isFiring)
            {
                shotCounter -= Time.deltaTime;
                if (shotCounter <= 0)
                {
                    shotCounter = timeBetweenShots;
                    BulletController newBullet = Instantiate(bullet, firePoint[0].transform.position, firePoint[0].transform.rotation) as BulletController;
                    newBullet.speed = bulletSpeed;
                }
            }
            else
            {
                shotCounter = 0;
            }
        }
    }
}
