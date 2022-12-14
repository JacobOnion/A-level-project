using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour
{
    private Rigidbody2D rb;
    public float health;
    public float timer;
    private RectTransform healthBar;
    private Rect ok;
    private float maxWidth;
    private float maxHealth;
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        healthBar = GameObject.FindGameObjectWithTag("health bar").GetComponent<RectTransform>();
        maxWidth = healthBar.rect.width;
        maxHealth = health;
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

        //healthBar.sizeDelta = new Vector2((maxWidth * (health / maxHealth)), healthBar.sizeDelta.y);
        healthBar.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, (maxWidth * (health / maxHealth)));
        
    }
}
