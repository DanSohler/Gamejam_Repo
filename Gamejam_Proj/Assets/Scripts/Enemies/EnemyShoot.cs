using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyShoot : MonoBehaviour
{

    //sets destined player, its agent, and the players layer
    public NavMeshAgent agent;
    public Transform player;
    public LayerMask whatIsPlayer;

    //attacking
    public float timeBetweenAttacks;
    bool alreadyAttacked;

    //States
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;

    //bullet reference
    public EnemyGunController theirGun;

    private void Awake()
    {
        //sets player to scenes player
        player = GameObject.Find("ExampleController").transform;
        //sets its agent
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        //checks in radius around it, to change its state
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        if (playerInSightRange && !playerInAttackRange) ChasePlayer();
        if (playerInSightRange && playerInAttackRange) AttackPlayer();
    }

    //moves to player
    private void ChasePlayer()
    {
        agent.SetDestination(player.position);
    }

    //attacks when in range
    private void AttackPlayer()
    {
        // Attack Code here
        theirGun.isFiring = true;

        agent.SetDestination(transform.position);

        transform.LookAt(player);

        if (!alreadyAttacked)
        {
            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }

    private void ResetAttack()
    {
        alreadyAttacked = false;
    }
}
