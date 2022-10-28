using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootBullet : MonoBehaviour
{
    public GameObject bullet;
    private Transform pos;
    public float bulletPower;
    public float bulletDmg;
    public float fireRate;
    private float coolDown;
    
    void Awake()
    {
        pos = gameObject.GetComponent<Transform>();
        coolDown = fireRate;
        
    }

    // Update is called once per frame
    void Update()
    {
        coolDown -= Time.deltaTime;
        if (Input.GetButton("Fire1") && coolDown <= 0)
        {
            coolDown = fireRate;
            Shoot();
        }
    }

    void Shoot()
    {
        GameObject currentBullet =Instantiate(bullet, pos.position, pos.rotation);
        currentBullet.GetComponent<Rigidbody2D>().AddForce(pos.up * bulletPower, ForceMode2D.Impulse);
    }

}


