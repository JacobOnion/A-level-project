using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDestroyBullet : MonoBehaviour
{
    public float damage; //Used as an intermediary variable between the enemy and player
    void Start()
    {
        Invoke("BulletTimer", 4f); //Destroys bullet after a set time with no collision
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag != "player bullet")
        {
            Destroy(gameObject); //Destroys bullet on collision
        }
    }

    void BulletTimer()
    {
        Destroy(gameObject);
    }
}
