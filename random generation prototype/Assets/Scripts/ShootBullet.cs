using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootBullet : MonoBehaviour
{
    public GameObject bullet;
    private Transform pos;
    public float bulletPower;
    
    void Awake()
    {
        pos = gameObject.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        GameObject currentBullet =Instantiate(bullet, pos.position, pos.rotation);
        currentBullet.GetComponent<Rigidbody2D>().AddForce(pos.up * bulletPower, ForceMode2D.Impulse);
    }

}
