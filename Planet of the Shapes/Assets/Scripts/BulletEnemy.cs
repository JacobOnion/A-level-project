using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEnemy : TurretEnemy
{
    public float enemyBulletForce;
    public GameObject enemyBullet;

    public BulletEnemy(float newHealth, float newEnemyDamage, float newEnemyBulletForce, float newFireRate, GameObject[] newGuns) : base(newHealth, newEnemyDamage, newFireRate, newGuns)
    {
        enemyBulletForce = newEnemyBulletForce;
    }
    // Start is called before the first frame update
    void Start()
    {
        coolDown = fireRate;
    }

    // Update is called once per frame
    void Update()
    {
        Die();
    }
    
    private void FixedUpdate()
    {
        CoolDownTimer("BulletShoot");
    }

    protected void BulletShoot()
    {
        for (int i = 0; i < guns.Length; i++)
        {
            Debug.Log("shoot");
            GameObject currentBullet = Instantiate(enemyBullet, guns[i].transform.position, guns[i].transform.rotation); //creates new bullet
            currentBullet.GetComponent<EnemyDestroyBullet>().damage = enemyDamage;
            currentBullet.GetComponent<Rigidbody2D>().AddForce((guns[i].transform.up) * enemyBulletForce, ForceMode2D.Impulse); //applies a forward impulse to the bullet
        }
    }
}
