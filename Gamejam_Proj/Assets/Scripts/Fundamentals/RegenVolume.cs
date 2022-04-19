using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegenVolume : MonoBehaviour
{
    public WellbeingManager wellbeingManager;
    public EnemySpawner enemySpawner;
    [Tooltip("0 = Social, 1 = Physical, 2 = Academic, 3 = Financial")]
    public int currentState;
    public bool playerEntered = false;
    public float spawnDelay;
    private bool coroutineBreaker = false;


    #region Checks


    void EnemyCall()
    {
        coroutineBreaker = false;
        StartCoroutine(spawnEnemyInScene());
    }

    void EnemyCull()
    {
        enemySpawner.Despawn();
        coroutineBreaker = true;
        StopCoroutine(spawnEnemyInScene());
        enemySpawner.Despawn();
    }


    //Regen Volume
    private void OnTriggerEnter(Collider other)
    {
        if (currentState == 0)
        {
            if (other.gameObject.tag == "Player")
            {
                wellbeingManager.socialRegen = true;
                EnemyCall();
                playerEntered = true;
            }
        }

        if (currentState == 1)
        {
            if (other.gameObject.tag == "Player")
            {
                wellbeingManager.physicalRegen = true;
                EnemyCall();
                playerEntered = true;
            }
        }

        if (currentState == 2)
        {
            if (other.gameObject.tag == "Player")
            {
                wellbeingManager.academicRegen = true;
                EnemyCall();
                playerEntered = true;
            }
        }

        if (currentState == 3)
        {
            if (other.gameObject.tag == "Player")
            {
                wellbeingManager.moneyRegen = true;
                EnemyCall();
                playerEntered = true;
            }
        }
    }

    //cleanup section
    private void OnTriggerExit(Collider other)
    {
        if (currentState == 0)
        {
            if (other.gameObject.tag == "Player")
            {
                EnemyCull();
                wellbeingManager.socialRegen = false;
                playerEntered = false;
                EnemyCull();
            }
        }

        if (currentState == 1)
        {
            if (other.gameObject.tag == "Player")
            {
                EnemyCull();
                wellbeingManager.physicalRegen = false;
                playerEntered = false;
                EnemyCull();
            }
        }

        if (currentState == 2)
        {
            if (other.gameObject.tag == "Player")
            {
                EnemyCull();
                wellbeingManager.academicRegen = false;
                playerEntered = false;
                EnemyCull();
            }
        }

        if (currentState == 3)
        {
            if (other.gameObject.tag == "Player")
            {
                EnemyCull();
                wellbeingManager.moneyRegen = false;
                playerEntered = false;
                EnemyCull();
            }
        }
    }

    #endregion


    public IEnumerator spawnEnemyInScene()
    {
        while (playerEntered && !coroutineBreaker)
        {
            enemySpawner.SpawnEnemy();
            yield return new WaitForSeconds(spawnDelay);
        }
    }
}
