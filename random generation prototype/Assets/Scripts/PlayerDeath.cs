using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour
{
    private Rigidbody2D rb;
    public float health;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (health <= 0)
        {
            SceneManager.LoadScene("LevelGeneration");
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("enemy bullet"))
        {
            health -= other.gameObject.GetComponent<EnemyDestroyBullet>().damage;
        }
        else if (other.gameObject.CompareTag("melee enemy"))
        {
            health -= other.gameObject.GetComponent<ChasingEnemy>().enemyDamage;
        }
    }
}
