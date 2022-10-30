using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class LaserEnemy : TurretEnemy
{
    protected List<LineRenderer> lineRenderers = new List<LineRenderer>();
    public Volume volume;
    private Volume laserEffect;
    public float maxDistance;
    private PlayerDeath playerDeath;

    public LaserEnemy(float newHealth, float newEnemyDamage, float newFireRate, GameObject[] newGuns) : base(newHealth, newEnemyDamage, newFireRate, newGuns)
    {
    }

    private void Awake()
    {
        playerDeath = GameObject.FindGameObjectWithTag("player").GetComponent<PlayerDeath>();
        laserEffect = Instantiate(volume);
        lineRenderers = new List<LineRenderer>();
        volume.enabled = false;
        coolDown = 1.8f;
    }
    // Start is called before the first frame update
    void Start()
    {
        foreach (GameObject gun in guns)
        {
            LineRenderer lineRenderer = gun.transform.Find("Laser").gameObject.GetComponent<LineRenderer>();
            //Debug.Log(lineRenderer, lineRenderer);
            lineRenderers.Add(lineRenderer);
            lineRenderer.enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Die();
    }

    private void FixedUpdate()
    {
        CoolDownTimer("EnableLaser");
        if (laserEffect.enabled)
        {
            for (int i = 0; i < guns.Length; i++)
            {
                lineRenderers[i].enabled = true;
                if (Physics2D.Raycast(guns[i].transform.position, guns[i].transform.up))
                {
                    RaycastHit2D hit = Physics2D.Raycast(guns[i].transform.position, guns[i].transform.up, Mathf.Infinity, ~LayerMask.GetMask("spawns"));
                    DrawRay(guns[i].transform.position, hit.point, i);
                    if (hit.transform.gameObject.CompareTag("player"))
                    {
                        playerDeath.DamagePlayer(gameObject);
                    }
                    //Debug.Log(hit.collider, hit.collider.gameObject);
                }
                else
                {
                    DrawRay(guns[i].transform.position, guns[i].transform.up * maxDistance, i);
                }
            }
        }
    }

    protected void EnableLaser()
    {
        laserEffect.enabled = true;
        Invoke("DisableLaser", 2.2f);
    }

    protected void DrawRay(Vector2 startPos, Vector2 endPos, int num)
    {
        lineRenderers[num].SetPosition(0, startPos);
        lineRenderers[num].SetPosition(1, endPos);
    }

    protected void DisableLaser()
    {
        foreach (LineRenderer laser in lineRenderers)
        {
            laser.enabled = false;
        }
        laserEffect.enabled = false;
    }
}
