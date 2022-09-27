using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    GameObject enemy1;
    TurretEnemy shooter;

    void Start()
    {
        shooter = new TurretEnemy(20f, 5f, 2f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
