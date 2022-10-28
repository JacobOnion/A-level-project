using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;
    private Transform pos;
    public float smoothTime;
    public float maxSpeed;
    public Vector3 currentVelocity;
    public Vector3 offset;
    


    private void Awake()
    {
        pos = gameObject.GetComponent<Transform>();
    }
    // Start is called before the first frame update
    void Start()
    {
        pos.position = offset;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 targetPosition = player.transform.position + offset;

        pos.position = Vector3.SmoothDamp(pos.position, targetPosition, ref currentVelocity, smoothTime, maxSpeed);
    }
}
