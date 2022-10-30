using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBullet : MonoBehaviour
{
    public ShootBullet shootBullet;
    // Start is called before the first frame update
    void Start()
    {
        shootBullet = GameObject.FindGameObjectWithTag("gun").GetComponent<ShootBullet>();
        Invoke("BulletTimer", 4f);
    }


    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("enemy") || other.gameObject.CompareTag("melee enemy") || other.gameObject.CompareTag("laser enemy"))
        {
            other.gameObject.GetComponent<Enemy>().damage(shootBullet.bulletDmg);
        }
        Destroy(gameObject);
    }

    void BulletTimer()
    {
        Destroy(gameObject);
    }
}
