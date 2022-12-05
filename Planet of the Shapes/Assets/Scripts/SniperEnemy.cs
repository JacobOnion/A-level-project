using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SniperEnemy : TurretEnemy
{
    private LineRenderer laser;
    private GameObject gun;
    private Rigidbody2D rb;
    public GameObject bulletTrail;
    private AimingEnemy3 rotate;
    public SniperEnemy(float newHealth, float newEnemyDamage, float newFireRate, GameObject[] newGuns) : base(newHealth, newEnemyDamage, newFireRate, newGuns)
    {

    }

    void Start()
    {
        coolDown = 1f;

        gun = guns[0];
        laser = gun.transform.Find("Laser").gameObject.GetComponent<LineRenderer>();
        rb = gameObject.GetComponent<Rigidbody2D>();
        rotate = GetComponent<AimingEnemy3>();
        
    }


    void FixedUpdate()
    {
        CoolDownTimer("FreezeLaser");
        SetLaserPos(); 
        
    }
    void SetLaserPos()
    {
        Debug.Log("ok");
        laser.SetPosition(0, gun.transform.position);
        if (Physics2D.Raycast(gun.transform.position, gun.transform.up))
        {
            RaycastHit2D hit = Physics2D.Raycast(gun.transform.position, gun.transform.up, Mathf.Infinity, ~LayerMask.GetMask("spawns"));
            laser.SetPosition(1, hit.point);
        }
    }

    /*void FreezeLaser()
    {
        Invoke("ShootGun", 0.4f);
        rotate.aiming = false;
        Debug.Log("boom?");
    }

    void ShootGun()
    {
        Debug.Log("BOOM");
        RaycastHit2D shot = Physics2D.Raycast(gun.transform.position, gun.transform.up, Mathf.Infinity, ~LayerMask.GetMask("spawns"));
        GameObject trail = Instantiate(bulletTrail);
        trail.GetComponent<BulletTrail>().endPos = shot.point;
        rotate.aiming = true;
    }*/

}
