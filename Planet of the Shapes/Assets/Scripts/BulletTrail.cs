using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletTrail : MonoBehaviour
{
    private Vector2 startPos;
    public Vector2 endPos;
    public float speed;
    private void Start()
    {
        startPos = transform.position;
    }
    private void Update()
    {
        float progress = Time.deltaTime * speed;
        transform.position = Vector2.Lerp(startPos, endPos, progress);
    }
}