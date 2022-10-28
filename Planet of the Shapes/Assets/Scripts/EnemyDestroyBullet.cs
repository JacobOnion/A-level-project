using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDestroyBullet : MonoBehaviour
{
    public float damage;
    void Start()
    {
        Invoke("BulletTimer", 4f);
    }


    private void OnCollisionEnter2D(Collision2D other)
    {
        //if (other.gameObject.CompareTag("enemy") || other.gameObject.CompareTag("enemy bullet") || other.gameObject.CompareTag("melee enemy"))
        //{
        //}
        //else
        //{
            Destroy(gameObject);
        //}

    }

    void BulletTimer()
    {
        Destroy(gameObject);
    }
}
