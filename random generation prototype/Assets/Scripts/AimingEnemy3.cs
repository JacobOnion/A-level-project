using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimingEnemy3 : MonoBehaviour
{
    public float accuracy;
    public float angle;
    public Vector2 lookDirection;
    public Queue<Vector2> lateRot = new Queue<Vector2>();
    private Rigidbody2D player;
    private Rigidbody2D self;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("player").GetComponent<Rigidbody2D>();
        self = gameObject.GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        lookDirection = player.position - self.position;
        lateRot.Enqueue(lookDirection);
    }

    private void FixedUpdate()
    {
        rotator();

    }

    protected void rotator()
    {
        lookDirection = player.position - self.position;

        lateRot.Enqueue(lookDirection);
        if (lateRot.Count > accuracy)
        {
            angle = Vector2.Angle(new Vector2(0f, 1f), lateRot.Peek());
            if (lateRot.Peek().x > 0)
            {
                angle *= -1;
                angle += 360; //turns the angle into a bearing

            }
            self.rotation = angle; //adds a frame delay equal to accuracy to the enemy rotation
            lateRot.Dequeue();
        }

    }

}