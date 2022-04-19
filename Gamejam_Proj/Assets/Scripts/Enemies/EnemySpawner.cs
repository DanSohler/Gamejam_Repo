using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public RegenVolume regenScript;

    [SerializeField] private GameObject[] walkerType = new GameObject[4];
    [SerializeField] private GameObject[] shooterType = new GameObject[4];

    [SerializeField] private GameObject[] spawnLocationArray = new GameObject[4];

    private int spawnLocation;
    public float spawnDelay;
    private float compChoice;

    public void SpawnEnemy()
    {
        compChoice = Random.Range(0, 2);
        Debug.Log(compChoice);
        if (compChoice == 0)
        {
            spawnLocation = Random.Range(0, 4);
            StartCoroutine(spawnWalk(spawnDelay, walkerType[regenScript.currentState]));
        }
        else
        {
            spawnLocation = Random.Range(0, 4);
            StartCoroutine(spawnShoot(spawnDelay, shooterType[regenScript.currentState]));
        }
    }

    public void Despawn()
    {
        var clones = GameObject.FindGameObjectsWithTag ("Enemy");
        foreach (var clone in clones)
        {
            Destroy(clone);
        }
    }

    public IEnumerator spawnWalk(float interval, GameObject enemy)
    {
        yield return new WaitForSeconds(interval);
        GameObject newEnemy = Instantiate(enemy, spawnLocationArray[spawnLocation].transform.position,Quaternion.identity);
    }

    public IEnumerator spawnShoot(float interval, GameObject enemy)
    {
        yield return new WaitForSeconds(interval);
        GameObject newEnemy = Instantiate(enemy, spawnLocationArray[spawnLocation].transform.position, Quaternion.identity);
    }

}
