using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SniperEnemy : TurretEnemy
{
    private LineRenderer laser;
    public SniperEnemy(float newHealth, float newEnemyDamage, float newFireRate, GameObject[] newGuns) : base(newHealth, newEnemyDamage, newFireRate, newGuns)
    {

    }

    void Start()
    {
        coolDown = 1f;
        foreach (GameObject gun in guns)
        {
            laser = gun.transform.Find("Line").gameObject.GetComponent<LineRenderer>();
        }
    }


    void FixedUpdate()
    {
        CoolDownTimer("ShootLaser");
        SetLaserPos();
    }
    void SetLaserPos()
    {
        
    }

}
