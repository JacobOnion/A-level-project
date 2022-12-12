using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBullet : MonoBehaviour
{
    public ShootBullet shootBullet;

    void Start()
    {
        shootBullet = GameObject.FindGameObjectWithTag("gun").GetComponent<ShootBullet>();
        Invoke("BulletTimer", 4f); //Destroys the bullet if it doesn't hit a collider after 4 seconds to save memory
    }


    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("enemy") || other.gameObject.CompareTag("melee enemy") || other.gameObject.CompareTag("laser enemy"))
        {
            other.gameObject.GetComponent<Enemy>().damage(shootBullet.bulletDmg); //subtracts bulletDmg from the enemy's health
        }
        
        Destroy(gameObject); //Bullet is destroyed on collision
    }

    void BulletTimer()
    {
        Destroy(gameObject);
    }
}
