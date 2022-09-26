using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBullet : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("BulletTimer", 4f);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }

    void BulletTimer()
    {
        Destroy(gameObject);
    }
}
