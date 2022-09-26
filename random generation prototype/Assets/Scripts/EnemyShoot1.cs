using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot1 : MonoBehaviour
{
    public GameObject enemyBullet;
    public float enemyBulletPower;
    void Start()
    {
        //StartCoroutine(Shoot());
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(Shoot());
    }

    IEnumerator Shoot()
    {
        GameObject currentBullet = Instantiate(enemyBullet, transform.position, transform.rotation);
        currentBullet.GetComponent<Rigidbody2D>().AddForce(new Vector2(transform.rotation.y, transform.rotation.x) * enemyBulletPower, ForceMode2D.Impulse);
        yield return new WaitForSeconds(3f);
    }
}
