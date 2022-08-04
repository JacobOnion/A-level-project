using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private FrictionJoint2D fj;
    public Vector2 inputDirection;
    public float moveSpeed;
    //public float friction;
    public float maxVelocity;
    public float acceleration;
    void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        fj = gameObject.GetComponent<FrictionJoint2D>();
    }

    private void Update()
    {
        inputDirection.x = Input.GetAxis("Horizontal");
        inputDirection.y = Input.GetAxis("Vertical");
    }

    void FixedUpdate()
    {
        //rb.velocity += (inputDirection * moveSpeed * Time.fixedDeltaTime);
        Accelerate();
    }
    
    private void Accelerate()
    {
        float friction = GetFriction();
        //maxVelocity += friction;
        //acceleration += friction;

        if (rb.velocity.magnitude > maxVelocity)
        {
            return;
        }

        rb.velocity += inputDirection * acceleration;

        if (rb.velocity.magnitude > maxVelocity)
        {
            rb.velocity = rb.velocity.normalized * maxVelocity;
        }
    }
    private float GetFriction()
    {
        return (fj.maxForce / rb.mass) * Time.fixedDeltaTime;
    }
}
