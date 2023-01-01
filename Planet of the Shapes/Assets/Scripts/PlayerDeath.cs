using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour
{
    public float health;
    public float timer;
    private RectTransform healthBar;
    private float maxWidth;
    private float maxHealth;
    public Canvas deathScreen;
    private RoomOrganiser roomOrganiser;
    void Start()
    {
        healthBar = GameObject.FindGameObjectWithTag("health bar").GetComponent<RectTransform>();
        maxWidth = healthBar.rect.width;
        maxHealth = health;
    }

    void Update()
    {
        if (health <= 0) //player dies
        {
            Time.timeScale = 0; //pauses all functions in the game
            deathScreen.enabled = true;
            RoomOrganiser.maxRooms = 4;
            Destroy(gameObject);
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
            health -= other.GetComponent<EnemyDestroyBullet>().damage; //Gets the damage value from the enemy class and subtracts that from health
        }
        else if (other.CompareTag("melee enemy") || other.CompareTag("laser enemy"))
        {
            health -= other.GetComponent<Enemy>().enemyDamage;
        }
        healthBar.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, (maxWidth * (health / maxHealth)));
    }
}
