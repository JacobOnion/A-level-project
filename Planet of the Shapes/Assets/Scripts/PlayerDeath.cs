using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour
{
    private Rigidbody2D rb;
    public float health;
    public float timer;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (health <= 0) //player dies
        {
            Time.timeScale = 0; //pauses all functions in the game
            timer -= Time.unscaledDeltaTime;
            if (timer <= 0f)
            {
                Time.timeScale = 1;
                SceneManager.LoadScene("Main Menu");
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        DamagePlayer(other.gameObject);
    }

    public void DamagePlayer(GameObject other)
    {
        if (other.CompareTag("enemy bullet"))
        {
            health -= other.GetComponent<EnemyDestroyBullet>().damage; //Gets the damage value from the enemy class and minuses that from health
        }
        else if (other.CompareTag("melee enemy") || other.CompareTag("laser enemy"))
        {
            health -= other.GetComponent<Enemy>().enemyDamage;
        }
    }
}
