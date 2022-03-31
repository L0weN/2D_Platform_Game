using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnailScripts : MonoBehaviour
{
    public float moveSpeed = 1f;
    private Rigidbody2D myBody;
    private Animator anim;
    private bool moveLeft;

    public Transform down_Collision;

    void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Start()
    {
        moveLeft = true;
    }

    void Update()
    {
        if (moveLeft)
        {
            myBody.velocity = new Vector2(-moveSpeed, myBody.velocity.y);
        }
        else
        {
            myBody.velocity = new Vector2( moveSpeed, myBody.velocity.y);
        }
        CheckCollision();
    }

    void CheckCollision()
    {
        if (!Physics2D.Raycast(down_Collision.position ,Vector2.down, 0.1f))
        {
            ChangeDirection();
        }
    }

    void ChangeDirection()
    {
        moveLeft = !moveLeft;

        Vector3 tempScale = transform.localScale;

        if (moveLeft)
        {
            tempScale.x = Mathf.Abs(tempScale.x);
        }
        else
        {
            tempScale.x = -Mathf.Abs(tempScale.x);
        }

        transform.localScale = tempScale;
    }
}
