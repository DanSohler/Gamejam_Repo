using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    private Rigidbody myRB;
    public float moveSpeed;

   // public Transform player;
    public NavMeshAgent agent;

    public TDC_Script thePlayer;

    private void Awake()
    {
        myRB = GetComponent<Rigidbody>();

        thePlayer = FindObjectOfType<TDC_Script>();
        agent = GetComponent<NavMeshAgent>();

        //player = GameObject.Find("ExampleController").transform;
    }

    public void MoveToPlayer()
    {
        transform.LookAt(thePlayer.transform);
        agent.SetDestination(thePlayer.transform.position);
    }

    void FixedUpdate()
    {
        //transform.LookAt(new Vector3(thePlayer.transform.position.x, transform.position.y, thePlayer.transform.position.z));
        MoveToPlayer();
       // myRB.velocity = (transform.forward * moveSpeed);
    }
}
