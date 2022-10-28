using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class LaserEnemy : TurretEnemy
{
    protected List<LineRenderer> lineRenderers = new List<LineRenderer>();
    public Volume volume;
    private Volume laserEffect;

    public LaserEnemy(float newHealth, float newEnemyDamage, float newFireRate, GameObject[] newGuns) : base(newHealth, newEnemyDamage, newFireRate, newGuns)
    {
    }

    private void Awake()
    {
        laserEffect = Instantiate(volume);
        lineRenderers = new List<LineRenderer>();
        volume.enabled = false;
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
    }

    protected void EnableLaser()
    {
        laserEffect.enabled = true;
        for(int i = 0; i < guns.Length; i++)
        {
            lineRenderers[i].enabled = true;
            RaycastHit2D hit = Physics2D.Raycast((Vector2)guns[i].transform.position, /*Quaternion.Euler(guns[i].transform.rotation.z, guns[i].transform.rotation.x, guns[i].transform.rotation.y).normalized * */guns[i].transform.up, Mathf.Infinity);
            Debug.Log(hit.point, guns[i]);
            lineRenderers[i].SetPosition(0, (Vector2)guns[i].transform.position);
            lineRenderers[i].SetPosition(1, hit.point);
        }
        Invoke("DisableLaser", 1f);
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
