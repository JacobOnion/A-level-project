using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretEnemy : Enemy
{
    public GameObject[] guns;
    public float fireRate;
    protected float coolDown;
    public TurretEnemy(float newHealth, float newEnemyDamage, float newFireRate, GameObject[] newGuns) : base(newHealth, newEnemyDamage)
    {
        fireRate = newFireRate;
        guns = newGuns;

    }

    private void Start()
    {
        coolDown = fireRate;
    }

    void Update()
    {

    }

    protected void CoolDownTimer(string shoot)
    {
        coolDown -= Time.deltaTime;
        if (coolDown <= 0f)
        {
            coolDown = fireRate;
            Invoke(shoot, 0f);
        }
    }

    /*protected void shoot()
    {
        for (int i = 0; i < guns.Length; i++)
        {
            Debug.Log("shoot");
            GameObject currentBullet = Instantiate(enemyBullet, guns[i].transform.position, guns[i].transform.rotation);
            currentBullet.GetComponent<EnemyDestroyBullet>().damage = enemyDamage;
            currentBullet.GetComponent<Rigidbody2D>().AddForce((guns[i].transform.up) * enemyBulletForce, ForceMode2D.Force);
        }
    }*/

}
