using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TDC_Script : MonoBehaviour
{
    //Speed Values
    public float SetSpeed = 5;
    private float speed;

    //cc
    public CharacterController characterController;

    //smooth turning Values
    public float turnSmoothTime = 0.08f;
    float turnSmoothVelocity;

    // Start is called before the first frame update
    void Start()
    {
        speed = SetSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        //Movement
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        //Set Movement
        transform.Translate(new Vector3(horizontal, 0, vertical) * (speed * Time.deltaTime));

        //Smooth Turning
        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            characterController.Move(moveDir * speed * Time.deltaTime);
        }

    }
}
