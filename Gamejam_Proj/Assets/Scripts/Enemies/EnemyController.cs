using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Rigidbody myRB;
    public float moveSpeed;

    public TDC_Script thePlayer;

    void Start()
    {
        myRB = GetComponent<Rigidbody>();
        thePlayer = FindObjectOfType<TDC_Script>();
    }

    void FixedUpdate()
    {
        myRB.velocity = (transform.forward * moveSpeed);
    }

    void Update()
    {
        transform.LookAt(thePlayer.transform.position);
    }
}
