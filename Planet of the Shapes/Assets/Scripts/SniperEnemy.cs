using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SniperEnemy : TurretEnemy
{
    private LineRenderer laser;
    private GameObject gun;
    public GameObject bulletTrail;
    private AimingEnemy3 rotate;
    private Transform pos;
    private bool scope;
    private PlayerDeath playerDeath;
    public SniperEnemy(float newHealth, float newEnemyDamage, float newFireRate, GameObject[] newGuns) : base(newHealth, newEnemyDamage, newFireRate, newGuns)
    {

    }

    void Start()
    {
        playerDeath = GameObject.FindGameObjectWithTag("player").GetComponent<PlayerDeath>();
        coolDown = 1.5f;
        gun = guns[0];
        laser = gun.transform.Find("Laser").gameObject.GetComponent<LineRenderer>();
        rotate = GetComponent<AimingEnemy3>();
        pos = gun.GetComponent<Transform>();
        scope = true;
    }

    private void Update()
    {
        Die();
    }

    void FixedUpdate()
    {
        CoolDownTimer("FreezeLaser");
        if (scope)
        {
            SetLaserPos();
        } 
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

    void FreezeLaser()
    {
        Invoke("ShootGun", 0.35f);
        laser.SetPosition(1, pos.position);
        rotate.aiming = false;
        scope = false;
    }

    void ShootGun()
    {
        RaycastHit2D shot = Physics2D.Raycast(gun.transform.position, gun.transform.up, Mathf.Infinity, ~LayerMask.GetMask("spawns"));

        if (shot.transform.gameObject.CompareTag("player"))
        {
            playerDeath.DamagePlayer(gameObject);
        }

        GameObject trail = Instantiate(bulletTrail, pos.position, pos.rotation);
        trail.GetComponent<BulletTrail>().endPos = shot.point;
        rotate.aiming = true;
        Invoke("CoolDown", 1f);
    }

    void CoolDown()
    {
        scope = true;
    }
}
