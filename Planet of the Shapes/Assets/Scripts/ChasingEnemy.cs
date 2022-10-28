using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChasingEnemy : Enemy
{
    public float accelRate;
    public float deccelRate;
    public float maxSpeed;
    public int size;
    public float knockbackStrength;
    private Rigidbody2D rb;
    public GameObject splitter1;
    public GameObject splitter2;
    public ChasingEnemy(float newHealth, float newEnemyDamage, float newAccelRate, float newDeccelRate, float newMaxSpeed, float newKnockbackStrength) : base(newHealth, newEnemyDamage)
    {
        accelRate = newAccelRate;
        deccelRate = newDeccelRate;
        maxSpeed = newMaxSpeed;
        knockbackStrength = newKnockbackStrength;
    }
    private void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Spawner();
        Die();
    }

    private void Spawner()
    {
        if (health <= 0 && size == 3)
        {
            Instantiate(splitter1, new Vector3(transform.position.x + 0.25f, transform.position.y, 0), transform.rotation, transform.parent);
            Instantiate(splitter1, new Vector3(transform.position.x - 0.25f, transform.position.y, 0), transform.rotation, transform.parent);
        }
        else if (health <= 0 && size == 2)
        {
            Instantiate(splitter2, new Vector3(transform.position.x + 0.25f, transform.position.y, 0), transform.rotation, transform.parent);
            Instantiate(splitter2, new Vector3(transform.position.x - 0.25f, transform.position.y, 0), transform.rotation, transform.parent);
        }
    }

    private void FixedUpdate()
    {
        Chase();
    }

    private void Chase()
    {
        float moveDir = Vector2.Angle(new Vector2(0f, 1f), rb.velocity);
        if (rb.velocity.x > 0)
        {
            moveDir *= -1;
            moveDir += 360; //turns the angle into a bearing
        }
        
        if (rb.velocity.magnitude <= maxSpeed)
        {
            if (Mathf.Abs(moveDir - gameObject.GetComponent<AimingEnemy3>().angle) > 100f && (Mathf.Abs(rb.velocity.x) > 0.1f || Mathf.Abs(rb.velocity.y) > 0.1f))
            {
                rb.AddForce(rb.velocity.normalized * -1 * deccelRate, ForceMode2D.Force);
            }
            
            rb.AddForce(gameObject.GetComponent<AimingEnemy3>().lateRot.Peek().normalized * accelRate, ForceMode2D.Force);
            
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("player"))
        {
            Vector2 knockbackDirection = gameObject.GetComponent<AimingEnemy3>().lookDirection * new Vector2(-1f, -1f);
            Debug.Log(knockbackDirection);
            rb.AddForce(knockbackDirection * knockbackStrength, ForceMode2D.Impulse);
        }
    }
}
