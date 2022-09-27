using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health;

    public Enemy(float newHealth)
    {
        health = newHealth;
    }

    protected void Die()
    {
        if (health <= 0f)
        {
            Destroy(gameObject);
        }
    }
}
