using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegenVolume : MonoBehaviour
{
    public WellbeingManager wellbeingManager;
    public EnemySpawner enemySpawner;
    public BoxScript boxScript;
    [Tooltip("0 = Social, 1 = Physical, 2 = Academic, 3 = Financial")]
    public int currentState;
    public bool playerEntered = false;
    public float spawnDelay;
    public bool coroutineBreaker = false;


    #region Checks

    private void Awake()
    {
        boxScript = FindObjectOfType<BoxScript>();
    }

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
                playerEntered = true;
                EnemyCall();
            }
        }

        if (currentState == 1)
        {
            if (other.gameObject.tag == "Player")
            {
                wellbeingManager.physicalRegen = true;
                playerEntered = true;
                EnemyCall();
            }
        }

        if (currentState == 2)
        {
            if (other.gameObject.tag == "Player")
            {
                wellbeingManager.academicRegen = true;
                playerEntered = true;
                EnemyCall();
            }
        }

        if (currentState == 3)
        {
            if (other.gameObject.tag == "Player")
            {
                boxScript.BoxOff();
                wellbeingManager.moneyRegen = true;
                playerEntered = true;
                EnemyCall();
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
                coroutineBreaker = false;
            }
        }

        if (currentState == 1)
        {
            if (other.gameObject.tag == "Player")
            {
                EnemyCull();
                wellbeingManager.physicalRegen = false;
                playerEntered = false;
                coroutineBreaker = false;
            }
        }

        if (currentState == 2)
        {
            if (other.gameObject.tag == "Player")
            {
                EnemyCull();
                wellbeingManager.academicRegen = false;
                playerEntered = false;
                coroutineBreaker = false;
            }
        }

        if (currentState == 3)
        {
            if (other.gameObject.tag == "Player")
            {
                boxScript.BoxOff();
                EnemyCull();
                wellbeingManager.moneyRegen = false;
                playerEntered = false;
                coroutineBreaker = false;
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
