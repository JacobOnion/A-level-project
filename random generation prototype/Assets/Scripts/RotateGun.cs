using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateGun : MonoBehaviour
{
    Vector3 mousePos;
    private Camera mainCamera;
    //private Rigidbody2D rb;
    //public GameObject gun;
    public float offset;
    private Transform player;
    // Start is called before the first frame update
    void Awake()
    {
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        player = GameObject.FindGameObjectWithTag("player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        Orbit();
    }


    void Orbit()
    {
        Vector2 pos = mousePos - player.position;
        float angle = Mathf.Atan2(pos.y, pos.x);
        transform.localPosition = new Vector3(Mathf.Cos(angle) * offset, Mathf.Sin(angle) * offset, 0);
        transform.rotation = Quaternion.Euler(0, 0, angle * Mathf.Rad2Deg - 90f);

    }
}
