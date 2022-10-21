using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretEnemy : Enemy
{
    public GameObject enemyBullet;
    public GameObject[] guns;
    public float enemyBulletForce;
    public float fireRate;
    protected float coolDown;
    public TurretEnemy(float newHealth, float newEnemyDamage, float newEnemyBulletForce, float newFireRate) : base(newHealth, newEnemyDamage)
    {
        enemyBulletForce = newEnemyBulletForce;
        fireRate = newFireRate;
    }

    private void Start()
    {
        coolDown = fireRate;
    }

    void Update()
    {
        Die();
        CoolDownTimer();
    }

    protected void CoolDownTimer()
    {
        coolDown -= Time.deltaTime;
        if (coolDown <= 0f)
        {
            coolDown = fireRate;
            shoot();
        }
    }

     protected void shoot()
    {
        for (int i = 0; i < guns.Length; i++)
        {
            Debug.Log("shoot");
            GameObject currentBullet = Instantiate(enemyBullet, guns[i].transform.position, guns[i].transform.rotation);
            currentBullet.GetComponent<EnemyDestroyBullet>().damage = enemyDamage;
            currentBullet.GetComponent<Rigidbody2D>().AddForce((guns[i].transform.up) * enemyBulletForce, ForceMode2D.Force);
        }
    }

}
