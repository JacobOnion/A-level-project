using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2 : MonoBehaviour
{
    public Vector2 input;
    public float maxSpeed;
    public float accelRate;
    public float deccelRate;
    private Rigidbody2D rb;
    void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        input.x = Input.GetAxisRaw("Horizontal");
        input.y = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
        Run();
    }

    private void Run()
    {
        if (input.x == 1 && input.y == 1)
        {
            input.x = 0.707f;
            input.y = 0.707f;
        }
        else if (input.x == -1 && input.y == -1)
        {
            input.x = -0.707f;
            input.y = -0.707f;
        }
        else if (input.x == 1 && input.y == -1)
        {
            input.x = 0.707f;
            input.y = -0.707f;
        }
        else if (input.x == -1 && input.y == 1)
        {
            input.x = -0.707f;
            input.y = 0.707f;
        }
        //float target = Mathf.Sqrt(Mathf.Pow(input.x, 2f) + Mathf.Pow(input.y, 2f)) * movespeed;
        Vector2 targetSpeed = input * maxSpeed;;

        float acceleration;
        if (Mathf.Abs(targetSpeed.x) > 0.1f || Mathf.Abs(targetSpeed.y) > 0.1f)
        {
            acceleration = accelRate;
        }
        else
        {
            acceleration = deccelRate;
        }

        Vector2 speedDif = targetSpeed - rb.velocity;
        Vector2 movement = speedDif * acceleration;
        rb.AddForce(movement, ForceMode2D.Force);
    }
}
